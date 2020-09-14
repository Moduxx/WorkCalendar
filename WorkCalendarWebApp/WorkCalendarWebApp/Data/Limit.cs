using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WorkCalendarWebApp.Data
{
    public class Limit
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Limitation Name")]
        public string TeamName { get; set; }
        [DisplayName("Max amount of days in a row")]
        public int MaxDaysInARow { get; set; }
        [DisplayName("Max amount of days per month")]
        public int MaxDaysPerMonth { get; set; }
        [DisplayName("Max amount of days per year")]
        public int MaxDaysPerYear { get; set; }
        [DisplayName("Max amount of topics per day")]
        public int MaxTopicsPerDay { get; set; }
        [DisplayName("Max amount of days per quarter")]
        public int MaxDaysPerQuarter { get; set; }
    }
}
