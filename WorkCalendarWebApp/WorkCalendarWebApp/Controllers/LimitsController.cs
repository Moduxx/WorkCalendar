using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkCalendarWebApp.Data;

namespace WorkCalendarWebApp.Controllers
{
    [Authorize]
    public class LimitsController : Controller
    {
        private readonly DbModelContext _context;

        public LimitsController(DbModelContext context)
        {
            _context = context;
        }

        // GET: Limits
        public async Task<IActionResult> Index()
        {
            return View(await _context.Limit.ToListAsync());
        }

        // GET: Limits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var limit = await _context.Limit.FindAsync(id);
            if (limit == null)
            {
                return NotFound();
            }
            return View(limit);
        }

        // POST: Limits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TeamName,MaxDaysInARow,MaxDaysPerMonth,MaxDaysPerYear,MaxTopicsPerDay,MaxDaysPerQuarter")] Limit limit)
        {
            if (id != limit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(limit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LimitExists(limit.Id))
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
            return View(limit);
        }

        private bool LimitExists(int id)
        {
            return _context.Limit.Any(e => e.Id == id);
        }
    }
}
