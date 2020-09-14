using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WorkCalendarWebApp.Areas.Identity.Data;
using WorkCalendarWebApp.Data;
using WorkCalendarWebApp.Utilities;
using WorkCalendarWebApp.ViewModel;

namespace WorkCalendarWebApp.Controllers
{
    [Authorize]
    public class TeamsController : Controller
    {
        private readonly DbModelContext _context;
        private readonly UserManager<ApplicationUser> _userContext;

        public static int? _currentTeamId;

        public TeamsController(DbModelContext context, UserManager<ApplicationUser> userContext)
        {
            _context = context;
            _userContext = userContext;
        }

        // GET: Teams
        public async Task<IActionResult> Index()
        {
            var teamsToShow = await _context.Team.ToListAsync();

            ValidTeamName.allTeams = teamsToShow;

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
        public async Task<IActionResult> Create([Bind("TeamName")] Team team)
        {
            bool teamNameExists = false;
            var allTeams = await _context.Team.ToListAsync();
            var teamsWithTheSameName = allTeams.FindAll(n => n.TeamName == team.TeamName);
            if (teamsWithTheSameName.Any())
            {
                teamNameExists = true;
            }

            if ((team.TeamName != "") && (teamNameExists == false))
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

            ValidTeamName.allTeams = await _context.Team.ToListAsync();

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
                    // Update team members info
                    var oldTeamName = await _context.Team.FindAsync(id);
                    var allTeams = await _context.Team.ToListAsync();
                    var teamMembers = allTeams.FindAll(n => n.TeamName == oldTeamName.TeamName);
                    foreach (var teamMember in teamMembers)
                    {
                        teamMember.TeamName = team.TeamName;
                        _context.Update(teamMember);
                    }

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

            _currentTeamId = id;

            var team = await _context.Team
                .FirstOrDefaultAsync(m => m.Id == id);
            if (team == null)
            {
                return NotFound();
            }

            ValidTeamName.allTeams = new List<Team>();

            // Setup view model
            var allTeamMembers = await _context.Team.ToListAsync();
            var currentTeamMembers = allTeamMembers.FindAll(m => m.TeamName == team.TeamName);
            var teamLeader = currentTeamMembers.FirstOrDefault(n => n.IsTeamLeader == true);

            var teamAndMembers = new TeamAndMembers()
            {
                Team = team,
                Teams = currentTeamMembers,
                TeamLeader = teamLeader.WorkerID
            };

            // Users for drop down list
            var allUsers = _userContext.Users;
            foreach (var currTeamMember in currentTeamMembers)
            {
                allUsers = allUsers.Where(y => y.UserName != currTeamMember.WorkerID);
            }
            ViewBag.Users = allUsers;

            return View(teamAndMembers);
        }

        // POST: Teams/Manage/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Manage(int id, [Bind("Id,WorkerID")] Team team)
        {
            var teamMember = await _context.Team.FindAsync(id);

            var users = _userContext.Users;
            var oneUser = users.FirstOrDefault(x => x.Id == team.WorkerID);

            team.TeamName = teamMember.TeamName;
            team.WorkerID = oneUser.UserName;

            if (team.WorkerID != "")
            {
                _context.Add(team);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Manage));
            }
            var teamForView = await _context.Team
                .ToListAsync();
            var teamMembers = teamForView.FindAll(n => n.TeamName == team.TeamName);
            var teamLeader = teamMembers.FirstOrDefault(m => m.IsTeamLeader == true);
            var teamAndMembers = new TeamAndMembers()
            {
                Team = team,
                Teams = teamMembers,
                TeamLeader = teamLeader.WorkerID
            };
            return View(teamAndMembers);
        }

        // GET: Teams/RemoveMember/3
        public async Task<IActionResult> RemoveMember(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamMember = await _context.Team.FindAsync(id);

            if (teamMember == null)
            {
                return NotFound();
            }

            _context.Team.Remove(teamMember);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Manage), "Teams", new { id = _currentTeamId });
        }

        private bool TeamExists(int id)
        {
            return _context.Team.Any(e => e.Id == id);
        }
    }
}
