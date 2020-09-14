using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkCalendarWebApp.Data
{
    public class DbModelContext : DbContext
    {
        public DbModelContext(DbContextOptions<DbModelContext> options)
            : base(options)
        {

        }

        public DbSet<Team> Team { get; set; }
        public DbSet<Topic> Topic { get; set; }
        public DbSet<Subtopic> Subtopic { get; set; }
        public DbSet<Limit> Limit { get; set; }
        public DbSet<Objective> Objective { get; set; }
        public DbSet<Event> Event { get; set; }
    }
}
