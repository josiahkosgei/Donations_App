using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Donations_Api.Areas.Identity.Data
{
    /// <summary>
    /// For Instantiating Parameterless PizzaPalaceDbContext Indirectly from the Business Logic
    /// </summary>
    public class Donations_ApiDbContextFactory : IDesignTimeDbContextFactory<Donations_ApiIdentityDbContext>
    {
        public Donations_ApiIdentityDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Donations_ApiIdentityDbContext>();

            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=Donations_BackEnd;Trusted_Connection=True;");

            return new Donations_ApiIdentityDbContext(optionsBuilder.Options);
        }
    }
}
