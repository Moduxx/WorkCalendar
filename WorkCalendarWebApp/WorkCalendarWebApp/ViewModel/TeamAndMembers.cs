using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkCalendarWebApp.Areas.Identity.Data;
using WorkCalendarWebApp.Data;

namespace WorkCalendarWebApp.ViewModel
{
    public class TeamAndMembers
    {
        public Team Team { get; set; }
        public List<Team> Teams { get; set; }
        public string TeamLeader { get; set; }
    }
}
