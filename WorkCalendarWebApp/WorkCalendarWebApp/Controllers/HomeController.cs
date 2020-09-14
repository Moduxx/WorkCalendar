using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using WorkCalendarWebApp.Data;
using WorkCalendarWebApp.Models;
using WorkCalendarWebApp.ViewModel;

namespace WorkCalendarWebApp.Controllers
{
    [Authorize]
    [Route("event")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbModelContext _context;

        public HomeController(ILogger<HomeController> logger, DbModelContext context)
        {
            _logger = logger;
            _context = context;
        }

        [Route("")]
        [Route("~/")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Create")]
        public IActionResult Create()
        {
            var allObjectives = _context.Objective.ToList().Where(m => m.IsLearnt == false);
            var objectivesAndEvents = new ObjectivesAndEvents()
            {
                Event = new ActualEvent()
                {
                    StartDateTime = DateTime.Today,
                    EndDateTime = DateTime.Today
                },
                ObjectiveOptions = allObjectives.Select(x => new SelectListItem()
                { Value = x.Id.ToString(), Text = x.TeamName + " | " + x.WorkerID + " | "  + x.TopicName + " | " + x.SubtopicName}).ToList(),
            };

            return View(objectivesAndEvents);
        }

        [Route("GetEvents")]
        [HttpGet]
        public IActionResult GetEvents()
        {
            var allEvents = _context.Event.ToList().Where(n => n.WorkerID == User.Identity.Name);
            var events = allEvents.Select(e => new
            {
                eventID = e.Id,
                subject = e.TopicName,
                description = e.SubtopicName,
                start = e.StartDateTime,
                end = e.EndDateTime,
                addinfo = e.AdditionalInfo
            }).ToList();

            return new JsonResult(events);
        }


        // POST: event/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        public async Task<IActionResult> Create([Bind("Event,SelectedObjectiveId")] ObjectivesAndEvents objectivesAndEvents)
        {
            var objective = await _context.Objective.FindAsync(objectivesAndEvents.SelectedObjectiveId);

            Event calendarEvent = new Event()
            {
                StartDateTime = objectivesAndEvents.Event.StartDateTime,
                EndDateTime = objectivesAndEvents.Event.EndDateTime,
                TeamName = objective.TeamName,
                WorkerID = objective.WorkerID,
                TopicName = objective.TopicName,
                SubtopicName = objective.SubtopicName,
                AdditionalInfo = objectivesAndEvents.Event.AdditionalInfo
            };

            if ((objectivesAndEvents.SelectedObjectiveId) != 0 && (calendarEvent.StartDateTime != null) && (calendarEvent.EndDateTime != null))
            {
                _context.Add(calendarEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(calendarEvent);
        }

        [HttpPost]
        [Route("DeleteEvent")]
        public JsonResult DeleteEvent(int eventID)
        {
            var status = false;

            var currentEvent = _context.Event.Find(eventID);
            if (currentEvent != null)
            {
                _context.Remove(currentEvent);
                _context.SaveChanges();
                status = true;
            }

            return new JsonResult(status);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
