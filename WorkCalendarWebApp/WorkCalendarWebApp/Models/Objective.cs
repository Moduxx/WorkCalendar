using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WorkCalendarWebApp.Models
{
    public class Objective
    {
        public Team Team { get; set; }
        public Subtopic Subtopic { get; set; }
        public Boolean IsLearnt { get; set; }
        public Event Event { get; set; }
    }
}
