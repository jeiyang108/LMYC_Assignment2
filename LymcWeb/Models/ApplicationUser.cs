using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LymcWeb.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {

        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        //public string Address { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        public string Country { get; set; }
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }
        [Display(Name = "Sailing Experience")]
        public string SailingExperience { get; set; }
    }
}
