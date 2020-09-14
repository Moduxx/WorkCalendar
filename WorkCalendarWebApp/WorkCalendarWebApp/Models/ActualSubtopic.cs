using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkCalendarWebApp.Models
{
    public class ActualSubtopic
    {
        public string SubtopicName { get; set; }
        public ActualTopic Topic { get; set; }
        public string AdditionalInfo { get; set; }
    }
}
