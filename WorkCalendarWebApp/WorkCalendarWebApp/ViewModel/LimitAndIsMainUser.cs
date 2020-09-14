using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkCalendarWebApp.Data;

namespace WorkCalendarWebApp.ViewModel
{
    public class LimitAndIsMainUser
    {
        public Limit Limit { get; set; }
        public List<Limit> Limits { get; set; }
        public bool IsMainUser { get; set; }
    }
}
