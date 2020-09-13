using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using WorkCalendarWebApp.Data;
using WorkCalendarWebApp.Utilities;
using WorkCalendarWebApp.ViewModel;

namespace WorkCalendarWebApp.Controllers
{
    [Authorize]
    public class TopicsController : Controller
    {
        private readonly DbModelContext _context;
        public static int? TopicIdForSubtopics;

        public TopicsController(DbModelContext context)
        {
            _context = context;
        }

        // GET: Topics
        public async Task<IActionResult> Index()
        {
            var topics = await _context.Topic.ToListAsync();
            ValidTopicName.allTopics = topics;
            return View(topics);
        }

        // GET: Topics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var topic = await _context.Topic
                .FirstOrDefaultAsync(m => m.Id == id);
            if (topic == null)
            {
                return NotFound();
            }
            var subtopic = await _context.Subtopic
                .ToListAsync();
            var topicsAndSubtopics = new TopicsAndSubtopics()
            {
                Topic = topic,
                Subtopics = subtopic.FindAll(n => n.TopicName == topic.TopicName)
            };

            return View(topicsAndSubtopics);
        }

        // GET: Topics/Create
        public IActionResult Create()
        {
            return View(new Topic());
        }

        // POST: Topics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TopicName,AdditionalInfo")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(topic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(topic);
        }

        // GET: Topics/Create
        public async Task<IActionResult> AddSubtopics(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TopicIdForSubtopics = id;

            var topic = await _context.Topic.FindAsync(id);
            if (topic == null)
            {
                return NotFound();
            }
            var subtopic = await _context.Subtopic
                .ToListAsync();
            var topicsAndSubtopics = new TopicsAndSubtopics()
            {
                Topic = topic,
                Subtopics = subtopic.FindAll(n => n.TopicName == topic.TopicName),
                Subtopic = new Subtopic()
            };

            return View(topicsAndSubtopics);
        }

        // POST: Topics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSubtopics(int id, [Bind("Id,SubtopicName,AdditionalInfo")] Subtopic subtopic)
        {
            var topic = await _context.Topic
                .FirstOrDefaultAsync(m => m.Id == id);
            subtopic.TopicName = topic.TopicName;

            if ((subtopic.TopicName != "") && (subtopic.SubtopicName != ""))
            {
                _context.Add(subtopic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AddSubtopics));
            }
            var subtopicsForView = await _context.Subtopic
                .ToListAsync();
            var topicsAndSubtopics = new TopicsAndSubtopics()
            {
                Topic = topic,
                Subtopics = subtopicsForView.FindAll(n => n.TopicName == topic.TopicName)
            };
            return View(topicsAndSubtopics);
        }

        // GET: Topics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topic = await _context.Topic.FindAsync(id);
            if (topic == null)
            {
                return NotFound();
            }
            var subtopic = await _context.Subtopic
                .ToListAsync();
            var topicsAndSubtopics = new TopicsAndSubtopics()
            {
                Topic = topic,
                Subtopics = subtopic.FindAll(n => n.TopicName == topic.TopicName)
            };

            return View(topicsAndSubtopics);
        }

        // POST: Topics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TopicName,AdditionalInfo")] Topic topic)
        {
            if (id != topic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(topic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TopicExists(topic.Id))
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
            return View(topic);
        }

        // GET: Topics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topic = await _context.Topic
                .FirstOrDefaultAsync(m => m.Id == id);
            if (topic == null)
            {
                return NotFound();
            }

            return View(topic);
        }

        // POST: Topics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var topic = await _context.Topic.FindAsync(id);
            _context.Topic.Remove(topic);

            var subtopics = await _context.Subtopic.ToListAsync();
            var subtopicList = subtopics.FindAll(n => n.TopicName == topic.TopicName);

            if (subtopicList.Any())
            {
                foreach (var subtopic in subtopicList)
                {
                    _context.Subtopic.Remove(subtopic);
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Topics/DeleteSubtopic/3
        public async Task<IActionResult> DeleteSubtopic(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subtopic = await _context.Subtopic.FindAsync(id);
            _context.Subtopic.Remove(subtopic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(AddSubtopics), "Topics", new { id = TopicIdForSubtopics});
        }

        private bool TopicExists(int id)
        {
            return _context.Topic.Any(e => e.Id == id);
        }
    }
}
