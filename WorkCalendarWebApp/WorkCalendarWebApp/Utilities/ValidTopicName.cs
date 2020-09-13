using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WorkCalendarWebApp.Data;

namespace WorkCalendarWebApp.Utilities
{
    public class ValidTopicName : ValidationAttribute
    {
        public static List<Topic> allTopics;
        public override bool IsValid(object value)
        {
            var topics = allTopics.Where(n => n.TopicName == value.ToString()) ;
            return !topics.Any();
        }
    }
}
