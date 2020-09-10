using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkCalendarWebApp.Models
{
    public class Subtopic
    {
        public string SubtopicName { get; set; }
        public Topic Topic { get; set; }
        public string AdditionalInfo { get; set; }
    }
}
