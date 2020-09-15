using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkCalendarWebApp.Models;

namespace WorkCalendarWebApp.ViewModel
{
    public class ObjectivesAndEvents
    {
        public ActualEvent Event { get; set; }
        public IEnumerable<SelectListItem> ObjectiveOptions { get; set; }
        public int SelectedObjectiveId { get; set; }
    }
}
