using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASING.Data;
using ASING.Models;
using static ASING.HelperClasses.Constants;

namespace ASING.Controllers
{
    public class GroupMembershipsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GroupMembershipsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> AcceptGroupMembershipAsync(int studentId, int groupMembershipId)
        {
            int Id = studentId;
            var groupMembership = _context.GroupMemberships.Where(g => g.GroupMembershipId == groupMembershipId).FirstOrDefault();
            groupMembership.StatusId = (int)Status.Accepted;
            _context.Update(groupMembership);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "UniversityUsers", new { Id });
        }

        public async Task<IActionResult> DenyGroupMembership(int studentId, int groupMembershipId)
        {
            int Id = studentId;
            var groupMembership = await _context.GroupMemberships.FindAsync(groupMembershipId);
            _context.GroupMemberships.Remove(groupMembership);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "UniversityUsers", new { Id });
        }


        // GET: GroupMemberships
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.GroupMemberships.Include(g => g.Group).Include(g => g.Unit).Include(g => g.UniversityUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GroupMemberships/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupMembership = await _context.GroupMemberships
                .Include(g => g.Group)
                .Include(g => g.Unit)
                .Include(g => g.UniversityUser)
                .FirstOrDefaultAsync(m => m.GroupMembershipId == id);
            if (groupMembership == null)
            {
                return NotFound();
            }

            return View(groupMembership);
        }

        // GET: GroupMemberships/Create
        public IActionResult Create()
        {
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupId");
            ViewData["UnitId"] = new SelectList(_context.Units, "UnitId", "UnitId");
            ViewData["StudentId"] = new SelectList(_context.UniversityUsers, "UniversityId", "UniversityId");
            return View();
        }

        // POST: GroupMemberships/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupMembershipId,GroupId,StudentId,UnitId,StatusId")] GroupMembership groupMembership)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groupMembership);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupId", groupMembership.GroupId);
            ViewData["UnitId"] = new SelectList(_context.Units, "UnitId", "UnitId", groupMembership.UnitId);
            ViewData["StudentId"] = new SelectList(_context.UniversityUsers, "UniversityId", "UniversityId", groupMembership.StudentId);
            return View(groupMembership);
        }

        // GET: GroupMemberships/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupMembership = await _context.GroupMemberships.FindAsync(id);
            if (groupMembership == null)
            {
                return NotFound();
            }
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupId", groupMembership.GroupId);
            ViewData["UnitId"] = new SelectList(_context.Units, "UnitId", "UnitId", groupMembership.UnitId);
            ViewData["StudentId"] = new SelectList(_context.UniversityUsers, "UniversityId", "UniversityId", groupMembership.StudentId);
            return View(groupMembership);
        }

        // POST: GroupMemberships/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GroupMembershipId,GroupId,StudentId,UnitId,StatusId")] GroupMembership groupMembership)
        {
            if (id != groupMembership.GroupMembershipId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupMembership);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupMembershipExists(groupMembership.GroupMembershipId))
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
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupId", groupMembership.GroupId);
            ViewData["UnitId"] = new SelectList(_context.Units, "UnitId", "UnitId", groupMembership.UnitId);
            ViewData["StudentId"] = new SelectList(_context.UniversityUsers, "UniversityId", "UniversityId", groupMembership.StudentId);
            return View(groupMembership);
        }

        // GET: GroupMemberships/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupMembership = await _context.GroupMemberships
                .Include(g => g.Group)
                .Include(g => g.Unit)
                .Include(g => g.UniversityUser)
                .FirstOrDefaultAsync(m => m.GroupMembershipId == id);
            if (groupMembership == null)
            {
                return NotFound();
            }

            return View(groupMembership);
        }

        // POST: GroupMemberships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groupMembership = await _context.GroupMemberships.FindAsync(id);
            _context.GroupMemberships.Remove(groupMembership);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupMembershipExists(int id)
        {
            return _context.GroupMemberships.Any(e => e.GroupMembershipId == id);
        }
    }
}
