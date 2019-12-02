using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AuthorizationExercise.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.WebSockets.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AuthorizationExercise.Data
{
    public class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, string testUserPw)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // For sample purposes seed both with the same password.
                // Password is set with the following:
                // dotnet user-secrets set SeedUserPW <pw>
                // The admin user can do anything

                var adminNisseID = await EnsureUser(serviceProvider, testUserPw, "administratorNisse@hotgays.com");
                await EnsureRole(serviceProvider, adminNisseID, NisseConstants.AdministratorNisse);
                var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();
                var result = await userManager.AddClaimAsync( await userManager.FindByIdAsync(adminNisseID), new Claim("CprNumber", "pismigiørettak"));

                // allowed user can create and edit contacts that they create
                var moderatorNisseID = await EnsureUser(serviceProvider, testUserPw, "moderatorNisse@hotgays.com");
                await EnsureRole(serviceProvider, moderatorNisseID, NisseConstants.ModeratorNisse); 
                await userManager.AddClaimAsync(await userManager.FindByIdAsync(moderatorNisseID),
                    new Claim(ClaimTypes.DateOfBirth, DateTime.Today.ToString()));

                var moderatorNisseID2 = await EnsureUser(serviceProvider, testUserPw, "1@hotgays.com");
                await EnsureRole(serviceProvider, moderatorNisseID, NisseConstants.ModeratorNisse);
                await userManager.AddClaimAsync(await userManager.FindByIdAsync(moderatorNisseID2),
                    new Claim(ClaimTypes.DateOfBirth, DateTime.Today.AddYears(-54).ToString()));

                var moderatorNisseID3 = await EnsureUser(serviceProvider, testUserPw, "2@hotgays.com");
                await EnsureRole(serviceProvider, moderatorNisseID, NisseConstants.ModeratorNisse);
                await userManager.AddClaimAsync(await userManager.FindByIdAsync(moderatorNisseID3),
                    new Claim(ClaimTypes.DateOfBirth, DateTime.Today.AddYears(-13).ToString()));


                var noobNisseid = await EnsureUser(serviceProvider, testUserPw, "noobNisse@hotgays.com");
                await EnsureRole(serviceProvider, noobNisseid, NisseConstants.NoobNisse);

                SeedDB(context, adminNisseID);
            }
        }

        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider, string userId, string role)
        {
            IdentityResult identityResult = null;
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if (roleManager == null) 
            {
                throw new Exception(
                    "shit is fucked in the rolemanager in the SeedData.cs class. Please send help, Kaare is torturing me. Free Hong Kong Revolution of Our Time. Epstein Didn't Kill Himself'");
            }

            if (! await roleManager.RoleExistsAsync(role))
            {
                identityResult = await roleManager.CreateAsync(new IdentityRole(role));
            }

            var userManager = serviceProvider.GetService < UserManager<IdentityUser>>();

            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new Exception("The testUserPW password was probably not stronk enough! Also free Hong Kong Revolution of Our Time, and Eppstein didn't kill himself!");
            }

            identityResult = await userManager.AddToRoleAsync(user, role);

            return identityResult;

        }

        private static async Task<string> EnsureUser(IServiceProvider serviceProvider, string testUserPw, string userName)
        {
            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

            var user = await userManager.FindByNameAsync(userName);
            if (user == null)
            {
                user = new IdentityUser {UserName = userName};
                await userManager.CreateAsync(user, testUserPw);
            }

            return user.Id;
        }

        public static void SeedDB(ApplicationDbContext context, string adminId)
        {
            if (context.Nisse.Any() && context.HotGayDads.Any())
            {
                return;
                // Db has already been seeded.
            }

            context.HotGayDads.AddRange(
            new HotGayDad{
                Name = "Mike Sexyboi",
                PhoneNumber = "61 86 11 84",
                Rate = "Meget billig"
            },
            new HotGayDad
            {
                Name = "Muslim Al-Ali",
                PhoneNumber = "42 76 32 05",
                Rate = "100 kr i timen."
            },
            new HotGayDad
            {
                Name = "Victor West-Larsen",
                PhoneNumber = "27 59 71 95",
                Rate = "5000 kr for et godt skrald"
            },
            new HotGayDad
                {
                    Name = "Kasper Hoffmann",
                    PhoneNumber = "28 39 32 30",
                    Rate = "4000 kr ca. Men kan prutte om det."
                }
            );

            context.Nisse.AddRange(
                new Nisse
                {
                    Name = "Kaare",
                    Email = "kaare@hotgays.com",
                    OwnerID = adminId
                },
                new Nisse
                {
                    Name = "Anders",
                    Email = "hotgaydads@hotgays.com",
                    OwnerID = adminId

                },
                new Nisse
                {
                    Name = "Johannes",
                    Email = "GayLord@hotgays.com",
                    OwnerID = adminId
                });

            context.SaveChanges();

        }
    }
}
