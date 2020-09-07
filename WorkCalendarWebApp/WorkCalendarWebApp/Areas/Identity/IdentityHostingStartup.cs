using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorkCalendarWebApp.Areas.Identity.Data;
using WorkCalendarWebApp.Data;

[assembly: HostingStartup(typeof(WorkCalendarWebApp.Areas.Identity.IdentityHostingStartup))]
namespace WorkCalendarWebApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<CalendarWebAppContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("CalendarWebAppContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => 
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                })
                    .AddEntityFrameworkStores<CalendarWebAppContext>();
            });
        }
    }
}