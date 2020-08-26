using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Donations_Api.Areas.Identity.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "Admin".ToUpper() });
            var admin = new IdentityUser
            {
               
                UserName = "Admin",
                NormalizedUserName = "MASTERADMIN",
                Email = "Admin@Admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = new Guid().ToString("D"),
            };

            admin.PasswordHash = PassGenerate(admin);

            modelBuilder.Entity<IdentityUser>().HasData(admin);
            
        }
        public static string PassGenerate(IdentityUser user)
        {
            var passHash = new PasswordHasher<IdentityUser>();
            return passHash.HashPassword(user, "Qwe@123");
        }
    }
}
