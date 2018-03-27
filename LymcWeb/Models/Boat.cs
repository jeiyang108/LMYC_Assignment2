using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LymcWeb.Models
{
    public class Boat
    {
        [Key]
        public int BoatId { get; set; }
        [Display(Name = "Boat Name")]
        public string BoatName { get; set; }
        public string Picture { get; set; }
        [Display(Name = "Length (feet)")]
        public int LengthInFeet { get; set; }
        public string Make { get; set; }
        public int Year { get; set; }
        [Display(Name = "Created On")]
        public DateTime RecordCreationDate { get; set; }
        [ForeignKey("User")]
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
