using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkCalendarWebApp.Utilities
{
    public class ValidDateTime : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime currentDateTime = DateTime.Now;
            DateTime inputBoxDateTime = Convert.ToDateTime(value);
            if (inputBoxDateTime < currentDateTime)
            {
                return false;
            }
            return true;
        }
    }
}
