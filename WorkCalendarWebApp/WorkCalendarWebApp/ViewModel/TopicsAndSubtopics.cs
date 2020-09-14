using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkCalendarWebApp.Data;

namespace WorkCalendarWebApp.ViewModel
{
    public class TopicsAndSubtopics
    {
        public Topic Topic { get; set; }
        public List<Subtopic> Subtopics { get; set; }
        public Subtopic Subtopic { get; set; }
    }
}
