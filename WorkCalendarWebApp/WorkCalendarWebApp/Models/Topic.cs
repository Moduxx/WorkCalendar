using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkCalendarWebApp.Models
{
    public class Topic
    {
        public string TopicName { get; set; }
        public string AdditionalInfo { get; set; }

        ICollection<Subtopic> Subtopics { get; set; }
    }
}
