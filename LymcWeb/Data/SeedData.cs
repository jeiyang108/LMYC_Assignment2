using LymcWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LymcWeb.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                if (!context.Users.Any(u => u.UserName == "a"))
                {
                    var adminUser = new ApplicationUser
                    {
                        UserName = "a",
                        Email = "a@a.a",
                        FirstName = "Admin",
                        LastName = "Admin",
                        Street = "2373 Venture Place",
                        City = "Save Lake",
                        Province = "AB",
                        PostalCode = "T0G 2A2",
                        Country = "Canada",
                        //Address = "123 Admin St",
                        MobileNumber = "604-234-5678",
                        SailingExperience = "Expert"
                    };

                    await userManager.CreateAsync(adminUser, "P@$$w0rd");
                    //string id = await userManager.FindByNameAsync(adminUser.UserName);
                    await EnsureRole(serviceProvider, adminUser.Id, "Admin");
                }

                if (!context.Users.Any(u => u.UserName == "m"))
                {
                    var userMember = new ApplicationUser
                    {
                        UserName = "m",
                        Email = "m@m.m",
                        FirstName = "Member",
                        LastName = "One",
                        Street = "2147 Galts Ave",
                        City = "Red Deer",
                        Province = "AB",
                        PostalCode = "T4N 2A6",
                        Country = "Canada",
                        //Address = "123 Member St",
                        MobileNumber = "604-234-5678",
                        SailingExperience = "Beginner"
                    };

                    await userManager.CreateAsync(userMember, "P@$$w0rd");
                    //string id = await userManager.FindByNameAsync(adminUser.UserName);
                    await EnsureRole(serviceProvider, userMember.Id, "Member");
                }

                InitializeBoat(context);
                InitializeReservation(context);
            }
        }

        public static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider, string id, string role)
        {
            IdentityResult identityResult = null;
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if(!await roleManager.RoleExistsAsync(role))
            {
                identityResult = await roleManager.CreateAsync(new IdentityRole(role));
            }

            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
            var user = await userManager.FindByIdAsync(id);

            identityResult = await userManager.AddToRoleAsync(user, role);
            return identityResult;
        }

        public static void InitializeBoat(ApplicationDbContext db)
        {
            if (db.Boat.Any())
            {
                return;
            }

            List<Boat> boats = new List<Boat>
            {
                new Boat
                {
                    BoatName = "Jeremiah Thomas",
                    Picture = "http://www.boattown.com/assets/img/final/home/new-arrivals.jpg",
                    LengthInFeet = 54,
                    Make = "BoatSellet Ltd.",
                    Year = 1998,
                    RecordCreationDate = DateTime.Today,
                    CreatedBy = db.Users.FirstOrDefault(u => u.UserName == "a").Id
                },
                new Boat
                {
                    BoatName = "Mary Jane No.1",
                    Picture = "https://static.pexels.com/photos/163236/luxury-yacht-boat-speed-water-163236.jpeg",
                    LengthInFeet = 54,
                    Make = "BoatLovers Ltd.",
                    Year = 1998,
                    RecordCreationDate = DateTime.Today,
                    CreatedBy = db.Users.FirstOrDefault(u => u.UserName == "a").Id
                },
                new Boat
                {
                    BoatName = "Mary Jane No.2",
                    Picture = "https://static.pexels.com/photos/163236/luxury-yacht-boat-speed-water-163236.jpeg",
                    LengthInFeet = 58,
                    Make = "BoatLovers Ltd.",
                    Year = 2003,
                    RecordCreationDate = DateTime.Today,
                    CreatedBy = db.Users.FirstOrDefault(u => u.UserName == "a").Id
                },
                new Boat
                {
                    BoatName = "Best Boat Ever",
                    Picture = "http://www.boattown.com/assets/img/final/home/new-arrivals.jpg",
                    LengthInFeet = 59,
                    Make = "BoatLovers Ltd.",
                    Year = 2004,
                    RecordCreationDate = DateTime.Today,
                    CreatedBy = db.Users.FirstOrDefault(u => u.UserName == "a").Id
                },
                new Boat
                {
                    BoatName = "Shooting Star",
                    Picture = "http://gasequipment.com.au/wp-content/uploads/2016/03/Boat-for-Blogpost.jpg",
                    LengthInFeet = 120,
                    Make = "Einstein Ltd.",
                    Year = 2008,
                    RecordCreationDate = DateTime.Today,
                    CreatedBy = db.Users.FirstOrDefault(u => u.UserName == "a").Id
                },

            };

            db.Boat.AddRange(boats);
            db.SaveChanges();
        }

        private static void InitializeReservation(ApplicationDbContext db)
        {
            if (!db.Reservation.Any())
            {
                List<Reservation> resos = new List<Reservation>
                {
                    new Reservation
                    {
                        StartDate = DateTime.Today,
                        EndDate = DateTime.Today.AddDays(1),
                        CreatedBy = db.Users.FirstOrDefault(u => u.UserName == "m").Id,
                        ReservedBoat = db.Boat.FirstOrDefault(b => b.BoatName == "Mary Jane No.1").BoatId,
                    },
                    new Reservation
                    {
                        StartDate = DateTime.Today.AddDays(3),
                        EndDate = DateTime.Today.AddDays(6),
                        CreatedBy = db.Users.FirstOrDefault(u => u.UserName == "m").Id,
                        ReservedBoat = db.Boat.FirstOrDefault(b => b.BoatName == "Jeremiah Thomas").BoatId,
                    },
                };
                db.Reservation.AddRange(resos);
                db.SaveChanges();
            }
        }
    }
}
