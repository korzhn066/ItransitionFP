using FinalProject.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Infrastructure.Data.Seeds
{
    internal static class ApplicationUserSeeder
    {
        internal static void SeedApplicationUsers(this ModelBuilder builder)
        {
            var users = new List<ApplicationUser>() {
                new ApplicationUser()
                {
                    Id = "1e445865-a24d-4543-a6c6-9443d048cdb9",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN".ToUpper(),
                    Status = Domain.Enums.UserStatus.Unblock
                },
                new ApplicationUser()
                {
                    Id = "2e445865-a24d-4543-a6c6-9443d048cdb9",
                    UserName = "user",
                    NormalizedUserName = "USER".ToUpper(),
                    Status = Domain.Enums.UserStatus.Unblock
                },
            };

            var hasher = new PasswordHasher<ApplicationUser>();

            users[0].PasswordHash = hasher.HashPassword(users[0], "admin");
            users[1].PasswordHash = hasher.HashPassword(users[1], "user");

            builder.Entity<ApplicationUser>().HasData(users);
        }
    }
}
