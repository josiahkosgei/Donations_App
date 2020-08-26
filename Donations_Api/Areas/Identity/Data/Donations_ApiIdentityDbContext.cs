using Donations_Api.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Donations_Api.Areas.Identity.Data
{
    /// <summary>
    /// For Defining the Repository pattern of our App
    /// </summary>
    public class Donations_ApiIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public Donations_ApiIdentityDbContext(DbContextOptions<Donations_ApiIdentityDbContext> options)
            : base(options)
        {
        }
        public DbSet<Transaction> Transactions { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Seed();
        }
    }
}
