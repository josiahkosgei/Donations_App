using Donations_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Pesapal.APIHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Donations_App.Controllers
{
    /// <summary>
    /// Process Donor Information
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Confirm()
        {

            ViewData["PesapalUrl"] = TempData["PesapalUrl"];
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// Post Method For Donation Form
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Donate(DonationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var pesapalUrl = PostDonationToPesaPal(model);
                TempData["PesapalUrl"] = pesapalUrl;
                return RedirectToAction("Confirm");
            }
            return View();
        }
        /// <summary>
        /// Payment Details Callback
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> ProcessDonationAsync()
        {

            try
            {
                string reference = Request.Query["pesapal_merchant_reference"].ToString();
                string pesapal_tracking_id = Request.Query["pesapal_transaction_tracking_id"].ToString();

                Uri pesapalQueryUri = new Uri("https://pesapal.com/API/querypaymentdetails");

                IBuilder builder = new APIPostParametersBuilder()
                                 .ConsumerKey(_configuration.GetSection("Configs").GetSection("consumerKey").Value)
                                 .ConsumerSecret(_configuration.GetSection("Configs").GetSection("consumerSecret").Value)
                                 .OAuthVersion(EOAuthVersion.VERSION1)
                                 .SignatureMethod(ESignatureMethod.HMACSHA1)
                                 .SimplePostHttpMethod(EHttpMethod.GET)
                                 .SimplePostBaseUri(pesapalQueryUri);

                APIHelper<IBuilder> helper = new APIHelper<IBuilder>(builder);


                string result = helper.PostGetQueryPaymentDetails(pesapal_tracking_id, reference);

                string[] resultParts = result.Split(new char[] { '=' });
                string paymentDetails = resultParts[1];
                string[] paymentDetailsParts = paymentDetails.Split(new char[] { ',' });

                string pesapalTrackingId = paymentDetailsParts[0];
                string paymentMethod = paymentDetailsParts[1];
                string paymentStatus = paymentDetailsParts[2];
                string refnce = paymentDetailsParts[3];

                //Deserialize TempData
                var _PesapalDirectOrderInfo = JsonConvert.DeserializeObject<PesapalDirectOrderInfo>((string)TempData["_PesapalDirectOrderInfo"]);

                //Build a key pair values for Posting to 3rd Part API
                var parameters = new Dictionary<string, string> {
                    { "pesapalTrackingId", pesapalTrackingId },
                    { "paymentMethod", paymentMethod },
                    { "paymentStatus", paymentStatus },
                    { "reference", _PesapalDirectOrderInfo.Reference },
                    { "BuyerName", _PesapalDirectOrderInfo.FirstName +" "+ _PesapalDirectOrderInfo.LastName},
                    { "Email", _PesapalDirectOrderInfo.Email },
                    { "Amount", _PesapalDirectOrderInfo.Amount },
                    { "PhoneNumber", _PesapalDirectOrderInfo.PhoneNumber },

                };
                ViewData["paymentStatus"] = paymentStatus;

                await PostToBackEndAsync(parameters);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return View();
        }

        /// <summary>
        ///Post Donation To PesaPal and Process the response
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        protected string PostDonationToPesaPal(DonationViewModel model)
        {
            Uri pesapalPostUri = new Uri("https://pesapal.com/API/PostPesapalDirectOrderV4");
            Uri pesapalCallBackUri = new Uri(_configuration.GetSection("Configs").GetSection("callback_url").Value);

            // Setup builder
            APIHelper<IBuilder> helper = new APIHelper<IBuilder>(new APIPostParametersBuilderV2()
                    .ConsumerKey(_configuration.GetSection("Configs").GetSection("consumerKey").Value)
                    .ConsumerSecret(_configuration.GetSection("Configs").GetSection("consumerSecret").Value)
                    .OAuthVersion(EOAuthVersion.VERSION1)
                    .SignatureMethod(ESignatureMethod.HMACSHA1)
                    .SimplePostHttpMethod(EHttpMethod.GET)
                    .SimplePostBaseUri(pesapalPostUri)
                    .OAuthCallBackUri(pesapalCallBackUri));

            // Populate line items
            var lineItem =
                new LineItem
                {
                    Particulars = "Donation",
                    UniqueId = Guid.NewGuid().ToString(),
                    Quantity = 1,
                    UnitCost = model.Amount

                };

            lineItem.SubTotal = (lineItem.Quantity * lineItem.UnitCost);
            List<LineItem> lineItems = new List<LineItem> { };
            lineItems.Add(lineItem);


            // Compose the donation
            var webOrder = new PesapalDirectOrderInfo()
            {
                Amount = lineItems.Sum(x => x.SubTotal).ToString(),
                Description = "Donation",
                Type = "MERCHANT",
                Reference = Guid.NewGuid().ToString(),
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.Mobile,
                LineItems = lineItems
            };

            //Serialize Store donation Details Temporarily
            TempData["_PesapalDirectOrderInfo"] = JsonConvert.SerializeObject(webOrder);
            // Post the donation to PesaPal
            return helper.PostGetPesapalDirectOrderUrl(webOrder);
        }

        /// <summary>
        /// Post all transactions to a 3rd party API
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task PostToBackEndAsync(Dictionary<string, string> parameters)
        {
            using (HttpClient client = new HttpClient())
            {

                StringContent content = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, "application/json");
                try
                {
                    using (var response = await client.PostAsync("https://localhost:44328/api/ProcessDonations", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                }
            }
        }
    }
}
