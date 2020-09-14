using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WorkCalendarWebApp.Models
{
    public class ActualEvent
    {
        [DisplayName("Enter Start Date and Time")]
        public DateTime StartDateTime { get; set; }
        [DisplayName("Enter End Date and Time")]
        public DateTime EndDateTime { get; set; }
        [DisplayName("Select Objective")]
        public ActualObjective Objective { get; set; }
        [DisplayName("Event Comments")]
        public string AdditionalInfo { get; set; }
    }
}
