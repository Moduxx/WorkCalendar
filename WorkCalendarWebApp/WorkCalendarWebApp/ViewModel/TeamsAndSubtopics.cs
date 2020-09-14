using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkCalendarWebApp.Data;
using WorkCalendarWebApp.Models;

namespace WorkCalendarWebApp.ViewModel
{
    public class TeamsAndSubtopics
    {
        public ActualObjective Objective { get; set; }
        public IEnumerable<SelectListItem> TeamOptions { get; set; }
        public int SelectedTeamId { get; set; }
        public IEnumerable<SelectListItem> SubtopicOptions { get; set; }
        public int SelectedSubtopicId { get; set; }
    }
}
