using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LymcWeb.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [ForeignKey("User")]
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("Boat")]
        [Display(Name = "Reserved Boat")]
        public int ReservedBoat { get; set; }
        public virtual Boat Boat { get; set; }
    }
}
