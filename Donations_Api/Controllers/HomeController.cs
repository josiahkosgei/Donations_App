using Donations_Api.Areas.Identity.Data;
using Donations_Api.Entities;
using Donations_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Donations_Api.Controllers
{
    /// <summary>
    /// The 3rd party system To View Transactions
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Donations_ApiIdentityDbContext _context;
        Donations_ApiDbContextFactory _dbContextFactory = new Donations_ApiDbContextFactory();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = _dbContextFactory.CreateDbContext(null);
        }
        //Get all Transactions
        public async Task<IActionResult> IndexAsync()
        {
            var transactions = new List<Transaction>();
            using (var context = _dbContextFactory.CreateDbContext(null))
            {
                transactions = await context.Transactions.ToListAsync();
            }
            return View(transactions);
        }
        // Handle Controller Errors

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
