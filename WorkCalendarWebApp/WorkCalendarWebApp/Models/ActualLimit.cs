using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkCalendarWebApp.Models
{
    public class ActualLimit
    {
        public string TeamName { get; set; }
        public int MaxDaysInARow { get; set; }
        public int MaxDaysPerMonth { get; set; }
        public int MaxDaysPerYear { get; set; }
        public int MaxTopicsPerDay { get; set; }
        public int MaxDaysPerQuarter { get; set; }
    }
}
