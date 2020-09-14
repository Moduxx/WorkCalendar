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
            var objectivesAndEvents = new ObjectivesAndEvents()
            {
                Event = new ActualEvent()
                {
                    StartDateTime = DateTime.Today,
                    EndDateTime = DateTime.Today
                },
                ObjectiveOptions = _context.Objective.Select(x => new SelectListItem()
                { Value = x.Id.ToString(), Text = x.TeamName + " | " + x.WorkerID + " | "  + x.TopicName + " | " + x.SubtopicName}).ToList(),
            };

            return View(objectivesAndEvents);
        }

        [Route("GetEvents")]
        [HttpGet]
        public IActionResult GetEvents()
        {
            var events = _context.Event.Select(e => new
            {
                subject = e.TopicName,
                description = e.SubtopicName,
                start = e.StartDateTime,
                end = e.EndDateTime
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

        [Route("findall")]
        public IActionResult FindAllEvents()
        {
            var events = _context.Event.Select(e => new
            {
                id = e.Id,
                title = e.TopicName + " | " + e.SubtopicName,
                description = e.AdditionalInfo,
                startDate = e.StartDateTime.ToString("dd/MM/yyyy"),
                endDate = e.EndDateTime.ToString("dd/MM/yyyy"),
            }).ToList();

            return new JsonResult(events);
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
