using LymcWeb.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LymcWeb.Models
{
    public class DummyData
    {
        //public static void Initialize(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        //{
        //    InitializeRoles(db);
        //    InitializeUsers(db, userManager);
        //    InitializeBoat(db);
        //    InitializeReservation(db);
        //}

        //private static void InitializeReservation(ApplicationDbContext db)
        //{
        //    if (!db.Reservation.Any())
        //    {
        //        List<Reservation> resos = new List<Reservation>
        //        {
        //            new Reservation
        //            {
        //                StartDate = DateTime.Today,
        //                EndDate = DateTime.Today.AddDays(1),
        //                CreatedBy = db.Users.FirstOrDefault(u => u.UserName == "m").Id,
        //                ReservedBoat = db.Boat.FirstOrDefault(b => b.BoatName == "Mary Jane No.1").BoatId,
        //            },
        //            new Reservation
        //            {
        //                StartDate = DateTime.Today.AddDays(3),
        //                EndDate = DateTime.Today.AddDays(6),
        //                CreatedBy = db.Users.FirstOrDefault(u => u.UserName == "m").Id,
        //                ReservedBoat = db.Boat.FirstOrDefault(b => b.BoatName == "Jeremiah Thomas").BoatId,
        //            },
        //        };
        //        db.Reservation.AddRange(resos);
        //        db.SaveChanges();
        //    }
        //}

        //public static void InitializeUsers(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        //{
            
        //    if (!db.Users.Any(u => u.UserName == "a"))
        //    {
        //        var user = new ApplicationUser
        //        {
        //            UserName = "a",
        //            Email = "a@a.a",
        //            FirstName = "Admin",
        //            LastName = "Admin",
        //            Street = "2373 Venture Place",
        //            City = "Save Lake",
        //            Province = "AB",
        //            PostalCode = "T0G 2A2",
        //            Country = "Canada",
        //            //Address = "123 Admin St",
        //            MobileNumber = "604-234-5678",
        //            SailingExperience = "Expert"
        //        };

        //        userManager.CreateAsync(user, "P@$$w0rd");

        //        userManager.AddToRoleAsync(user, "Admin");
        //    }

        //    if (!db.Users.Any(u => u.UserName == "m"))
        //    {
        //        var user = new ApplicationUser
        //        {
        //            UserName = "m",
        //            Email = "m@m.m",
        //            FirstName = "Member",
        //            LastName = "One",
        //            Street = "2147 Galts Ave",
        //            City = "Red Deer",
        //            Province = "AB",
        //            PostalCode = "T4N 2A6",
        //            Country = "Canada",
        //            //Address = "123 Member St",
        //            MobileNumber = "604-234-5678",
        //            SailingExperience = "Beginner"
        //        };

        //        userManager.CreateAsync(user, "P@$$w0rd");

        //        userManager.AddToRoleAsync(user, "Member");
        //    }
        //}

        //public static void InitializeRoles(ApplicationDbContext db)
        //{
        //    if (db.Roles.Any())
        //        return;

        //    db.Roles.Add(new IdentityRole { Name = "Admin" });
        //    db.Roles.Add(new IdentityRole { Name = "Member" });
        //    db.SaveChanges();
        //}

        //public static void InitializeBoat(ApplicationDbContext db)
        //{
        //    if (db.Boat.Any())
        //    {
        //        return;
        //    }

        //    List<Boat> boats = new List<Boat>
        //    {
        //        new Boat
        //        {
        //            BoatName = "Jeremiah Thomas",
        //            Picture = "http://www.boattown.com/assets/img/final/home/new-arrivals.jpg",
        //            LengthInFeet = 54,
        //            Make = "BoatSellet Ltd.",
        //            Year = 1998,
        //            RecordCreationDate = DateTime.Today,
        //            CreatedBy = db.Users.FirstOrDefault(u => u.UserName == "a").Id
        //        },
        //        new Boat
        //        {
        //            BoatName = "Mary Jane No.1",
        //            Picture = "https://static.pexels.com/photos/163236/luxury-yacht-boat-speed-water-163236.jpeg",
        //            LengthInFeet = 54,
        //            Make = "BoatLovers Ltd.",
        //            Year = 1998,
        //            RecordCreationDate = DateTime.Today,
        //            CreatedBy = db.Users.FirstOrDefault(u => u.UserName == "a").Id
        //        },
        //        new Boat
        //        {
        //            BoatName = "Mary Jane No.2",
        //            Picture = "https://static.pexels.com/photos/163236/luxury-yacht-boat-speed-water-163236.jpeg",
        //            LengthInFeet = 58,
        //            Make = "BoatLovers Ltd.",
        //            Year = 2003,
        //            RecordCreationDate = DateTime.Today,
        //            CreatedBy = db.Users.FirstOrDefault(u => u.UserName == "a").Id
        //        },
        //        new Boat
        //        {
        //            BoatName = "Best Boat Ever",
        //            Picture = "http://www.boattown.com/assets/img/final/home/new-arrivals.jpg",
        //            LengthInFeet = 59,
        //            Make = "BoatLovers Ltd.",
        //            Year = 2004,
        //            RecordCreationDate = DateTime.Today,
        //            CreatedBy = db.Users.FirstOrDefault(u => u.UserName == "a").Id
        //        },
        //        new Boat
        //        {
        //            BoatName = "Shooting Star",
        //            Picture = "http://gasequipment.com.au/wp-content/uploads/2016/03/Boat-for-Blogpost.jpg",
        //            LengthInFeet = 120,
        //            Make = "Einstein Ltd.",
        //            Year = 2008,
        //            RecordCreationDate = DateTime.Today,
        //            CreatedBy = db.Users.FirstOrDefault(u => u.UserName == "a").Id
        //        },

        //    };

        //    db.Boat.AddRange(boats);
        //    db.SaveChanges();
        //}


    }
}
