using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WorkCalendarWebApp.Data
{
    public class Subtopic
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Topic Name")]
        public string TopicName { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Subtopic Name")]
        public string SubtopicName { get; set; }
        [DisplayName("Additional Information")]
        public string AdditionalInfo { get; set; }
    }
}
