using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entity.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Songyang",
                    Email = "songyang@test.com",
                    UserName = "songyang@test.com",
                    Address = new Address
                    {
                        FirstName = "Songyang",
                        LastName = "Tian",
                        Street = "10 The Street",
                        City = "Hamilton",
                        State = "NZ",
                        Zipcode = "3210"
                    }
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}