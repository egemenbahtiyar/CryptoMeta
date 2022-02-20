using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMeta.Identitiy
{
    public static class SeedIdentity
    {
        public static async Task Seed(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            var username = configuration["Data:AdminUser:username"];
            var firstname = configuration["Data:AdminUser:firstname"];
            var lastname = configuration["Data:AdminUser:lastname"];
            var password = configuration["Data:AdminUser:password"];
            var email = configuration["Data:AdminUser:email"];
            var role = configuration["Data:AdminUser:role"];

            if (await userManager.FindByNameAsync(username) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(role));
                var user = new User()
                {
                    UserName = username,
                    FirstName = firstname,
                    LastName = lastname,
                    PasswordHash = password,
                    Email = email,
                };
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }
    }
}
