using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkCalendarWebApp.Data;
using WorkCalendarWebApp.Models;
using WorkCalendarWebApp.ViewModel;

namespace WorkCalendarWebApp.Controllers
{
    public class ObjectivesController : Controller
    {
        private readonly DbModelContext _context;

        public ObjectivesController(DbModelContext context)
        {
            _context = context;
        }

        // GET: Objectives
        public async Task<IActionResult> Index()
        {
            return View(await _context.Objective.ToListAsync());
        }

        // GET: Objectives/Create
        public IActionResult Create()
        {
            var teamsAndSubtopics = new TeamsAndSubtopics()
            {
                Objective = new ActualObjective(),
                TeamOptions = _context.Team.Select(x => new SelectListItem()
                { Value = x.Id.ToString(), Text = x.TeamName + " | " + x.WorkerID}).ToList(),
                SubtopicOptions = _context.Subtopic.Select(x => new SelectListItem()
                { Value = x.Id.ToString(), Text = x.TopicName + " | " + x.SubtopicName}).ToList()
            };

            return View(teamsAndSubtopics);
        }

        // POST: Objectives/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SelectedTeamId,SelectedSubtopicId")] TeamsAndSubtopics teamsAndSubtopics)
        {
            var team = await _context.Team.FindAsync(teamsAndSubtopics.SelectedTeamId);
            var subtopic = await _context.Subtopic.FindAsync(teamsAndSubtopics.SelectedSubtopicId);

            Objective objective = new Objective()
            {
                TeamName = team.TeamName,
                WorkerID = team.WorkerID,
                TopicName = subtopic.TopicName,
                SubtopicName = subtopic.SubtopicName
            };

            if ((teamsAndSubtopics.SelectedSubtopicId) != 0 && (teamsAndSubtopics.SelectedTeamId != 0))
            {
                _context.Add(objective);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(objective);
        }

        // GET: Objectives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objective = await _context.Objective.FindAsync(id);

            if (objective == null)
            {
                return NotFound();
            }

            _context.Objective.Remove(objective);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Objectives/Complete/5
        public async Task<IActionResult> Complete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objective = await _context.Objective.FindAsync(id);

            if (objective == null)
            {
                return NotFound();
            }

            objective.IsLearnt = true;

            try
            {
                _context.Objective.Update(objective);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObjectiveExists(objective.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ObjectiveExists(int id)
        {
            return _context.Objective.Any(e => e.Id == id);
        }
    }
}
