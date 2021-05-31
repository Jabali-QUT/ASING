using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASING.Data;
using ASING.Models;

namespace ASING.Controllers
{
    public class GroupActivitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GroupActivitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GroupActivities
        public async Task<IActionResult> Index(int groupId, int studentId)
        {
            var groupActivities = _context.GroupActivities.Include(g => g.Group)
                .Include(g => g.UniversityUser)
                .Include(g => g.GroupActivityMemberships)
                .Where(g => g.GroupId == groupId).ToListAsync();


            return View(await groupActivities);
        }

        // GET: GroupActivities/Details/5
        public async Task<IActionResult> Details(int? id)

        {
            if (id == null)
            {
                return NotFound();
            }

            var groupActivity = await _context.GroupActivities
                .Include(g => g.Group)
                .Include(g => g.UniversityUser)
                .Include(g => g.GroupActivityMemberships)
                .FirstOrDefaultAsync(m => m.GoupActivityId == id);
            if (groupActivity == null)
            {
                return NotFound();
            }

            return View(groupActivity);
        }

        // GET: GroupActivities/Create
        public IActionResult Create()
        {
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupId");
            ViewData["OwnerId"] = new SelectList(_context.UniversityUsers, "UniversityId", "UniversityId");
            return View();
        }

        // POST: GroupActivities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GoupActivityId,GroupId,Description,ActivityDate,Isrecurring,FrequencyId,OwnerId")] GroupActivity groupActivity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groupActivity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupId", groupActivity.GroupId);
            ViewData["OwnerId"] = new SelectList(_context.UniversityUsers, "UniversityId", "UniversityId", groupActivity.OwnerId);
            return View(groupActivity);
        }

        // GET: GroupActivities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupActivity = await _context.GroupActivities.FindAsync(id);
            if (groupActivity == null)
            {
                return NotFound();
            }
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupId", groupActivity.GroupId);
            ViewData["OwnerId"] = new SelectList(_context.UniversityUsers, "UniversityId", "UniversityId", groupActivity.OwnerId);
            return View(groupActivity);
        }

        // POST: GroupActivities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GoupActivityId,GroupId,Description,ActivityDate,Isrecurring,FrequencyId,OwnerId")] GroupActivity groupActivity)
        {
            if (id != groupActivity.GoupActivityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupActivity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupActivityExists(groupActivity.GoupActivityId))
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
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupId", groupActivity.GroupId);
            ViewData["OwnerId"] = new SelectList(_context.UniversityUsers, "UniversityId", "UniversityId", groupActivity.OwnerId);
            return View(groupActivity);
        }

        // GET: GroupActivities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupActivity = await _context.GroupActivities
                .Include(g => g.Group)
                .Include(g => g.UniversityUser)
                .FirstOrDefaultAsync(m => m.GoupActivityId == id);
            if (groupActivity == null)
            {
                return NotFound();
            }

            return View(groupActivity);
        }

        // POST: GroupActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groupActivity = await _context.GroupActivities.FindAsync(id);
            _context.GroupActivities.Remove(groupActivity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupActivityExists(int id)
        {
            return _context.GroupActivities.Any(e => e.GoupActivityId == id);
        }
    }
}
