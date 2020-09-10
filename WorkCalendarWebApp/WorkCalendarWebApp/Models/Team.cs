using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkCalendarWebApp.Areas.Identity.Data;

namespace WorkCalendarWebApp.Models
{
    public class Team
    {
        public string TeamName { get; set; }
        public ApplicationUser User { get; set; }
        public Boolean IsTeamLeader { get; set; }
    }
}
