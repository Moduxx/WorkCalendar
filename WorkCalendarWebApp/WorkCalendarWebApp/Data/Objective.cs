﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WorkCalendarWebApp.Data
{
    public class Objective
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
        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Topic Name")]
        public string TopicName { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Subtopic Name")]
        public string SubtopicName { get; set; }
        [DisplayName("Is Completed")]
        public Boolean IsLearnt { get; set; }
    }
}
