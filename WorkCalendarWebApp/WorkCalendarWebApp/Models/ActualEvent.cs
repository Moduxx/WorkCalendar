using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using WorkCalendarWebApp.Utilities;

namespace WorkCalendarWebApp.Models
{
    public class ActualEvent
    {
        [Required(ErrorMessage = "This field is required")]
        [ValidDateTime(ErrorMessage = "Events can only be scheduled in the future!")]
        [DisplayName("Enter Start Date and Time")]
        public DateTime StartDateTime { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [ValidDateTime(ErrorMessage = "Events can only be scheduled in the future!")]
        [DisplayName("Enter End Date and Time")]
        public DateTime EndDateTime { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Select Objective")]
        public ActualObjective Objective { get; set; }
        [DisplayName("Event Comments")]
        public string AdditionalInfo { get; set; }
    }
}
