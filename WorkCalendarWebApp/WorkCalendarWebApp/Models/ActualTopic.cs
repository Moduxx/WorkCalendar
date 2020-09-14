using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkCalendarWebApp.Models
{
    public class ActualTopic
    {
        public string TopicName { get; set; }
        public string AdditionalInfo { get; set; }

        ICollection<ActualSubtopic> Subtopics { get; set; }
    }
}
