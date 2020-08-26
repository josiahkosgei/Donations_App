using System.Threading.Tasks;
using Donations_Api.Areas.Identity.Data;
using Donations_Api.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Donations_Api.Controllers
{
    /// <summary>
    /// The 3rd party API to process Transactions
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ProcessdonationsController : ControllerBase
    {
        private readonly ILogger<ProcessdonationsController> _logger;
        private readonly Donations_ApiIdentityDbContext _context;
        Donations_ApiDbContextFactory _dbContextFactory = new Donations_ApiDbContextFactory();
        public ProcessdonationsController(ILogger<ProcessdonationsController> logger)
        {
            _logger = logger;
            _context = _dbContextFactory.CreateDbContext(null);
        }
        /// <summary>
        /// Creates Transaction with given parameters
        /// </summary>
        /// <response code="200">If everything was ok</response>
        [HttpPost]
        public async Task<IActionResult> CreateTransactionAsync([FromBody] Transaction transaction)
        {
            using (var context = _dbContextFactory.CreateDbContext(null))
            {
                context.Transactions.Add(transaction);
                context.SaveChanges();
                
            }
            return Ok(transaction);
        }
    }
}
