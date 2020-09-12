using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WorkCalendarWebApp.Data;
using WorkCalendarWebApp.ViewModel;

namespace WorkCalendarWebApp.Controllers
{
    [Authorize]
    public class TeamsController : Controller
    {
        private readonly DbModelContext _context;

        public TeamsController(DbModelContext context)
        {
            _context = context;
        }

        // GET: Teams
        public async Task<IActionResult> Index()
        {
            var teamsToShow = await _context.Team.ToListAsync();
            return View(teamsToShow.FindAll(m => m.WorkerID == User.Identity.Name));
        }

        // GET: Teams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Team
                .FirstOrDefaultAsync(m => m.Id == id);
            if (team == null)
            {
                return NotFound();
            }

            var allTeamMembers = await _context.Team.ToListAsync();
            var currentTeamMembers = allTeamMembers.FindAll(m => m.TeamName == team.TeamName);
            var teamLeader = currentTeamMembers.FirstOrDefault(n => n.IsTeamLeader == true);

            var teamAndMembers = new TeamAndMembers()
            {
                Team = team,
                Teams = currentTeamMembers,
                TeamLeader = teamLeader.WorkerID
            };

            return View(teamAndMembers);
        }

        // GET: Teams/Create
        public IActionResult Create()
        {
            return View(new Team());
        }

        // POST: Teams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TeamName")] Team team)
        {
            if (team.TeamName != "")
            {
                team.WorkerID = User.Identity.Name;
                team.IsTeamLeader = true;
                _context.Add(team);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(team);
        }

        // GET: Teams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Team.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            return View(team);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TeamName,WorkerID,IsTeamLeader")] Team team)
        {
            if (id != team.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(team);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamExists(team.Id))
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
            return View(team);
        }

        // GET: Teams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Team
                .FirstOrDefaultAsync(m => m.Id == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var team = await _context.Team.FindAsync(id);
            _context.Team.Remove(team);

            var allMembers = await _context.Team.ToListAsync();
            var teamMembers = allMembers.FindAll(m => m.TeamName == team.TeamName);

            if (teamMembers.Any())
            {
                foreach (var member in teamMembers)
                {
                    _context.Team.Remove(member);
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Teams/Manage/5
        public async Task<IActionResult> Manage(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Team
                .FirstOrDefaultAsync(m => m.Id == id);
            if (team == null)
            {
                return NotFound();
            }

            var allTeamMembers = await _context.Team.ToListAsync();
            var currentTeamMembers = allTeamMembers.FindAll(m => m.TeamName == team.TeamName);
            var teamLeader = currentTeamMembers.FirstOrDefault(n => n.IsTeamLeader == true);

            var teamAndMembers = new TeamAndMembers()
            {
                Team = team,
                Teams = currentTeamMembers,
                TeamLeader = teamLeader.WorkerID
            };

            return View(teamAndMembers);
        }

        private bool TeamExists(int id)
        {
            return _context.Team.Any(e => e.Id == id);
        }
    }
}
