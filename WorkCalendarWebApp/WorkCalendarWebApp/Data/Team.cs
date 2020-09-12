using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WorkCalendarWebApp.Areas.Identity.Data;

namespace WorkCalendarWebApp.Data
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Team Name")]
        public string TeamName { get; set; }
        [Column(TypeName = "nvarchar(450)")]
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Worker Name")]
        public string WorkerID { get; set; }
        [DisplayName("Is Team Leader?")]
        public Boolean IsTeamLeader { get; set; }
    }
}
