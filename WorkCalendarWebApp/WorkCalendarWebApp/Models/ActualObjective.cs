using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WorkCalendarWebApp.Models
{
    public class ActualObjective
    {
        [DisplayName("Select Team Name | Team Member")]
        public ActualTeam Team { get; set; }
        [DisplayName("Select Topic Name | Subtopic Name")]
        public ActualSubtopic Subtopic { get; set; }
        public Boolean IsLearnt { get; set; }
    }
}
