using Donations_Api.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Donations_Api.Areas.Identity.Data
{
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
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Seed();
        }
    }
}
