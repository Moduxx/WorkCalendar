using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkCalendarWebApp.Models
{
    public class ActualEvent
    {
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public ActualObjective Objective { get; set; }
        public string AdditionalInfo { get; set; }
    }
}
