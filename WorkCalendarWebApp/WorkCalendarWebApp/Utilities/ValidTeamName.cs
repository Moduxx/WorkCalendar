using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WorkCalendarWebApp.Data;

namespace WorkCalendarWebApp.Utilities
{
    public class ValidTeamName : ValidationAttribute
    {
        public static List<Team> allTeams;
        public override bool IsValid(object value)
        {
            if (allTeams.Any())
            {
                var teams = allTeams.Where(n => n.TeamName == value.ToString());
                return !teams.Any();
            }
            return true;
        }
    }
}
