using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASING.Data;
using ASING.Models;
using ASING.HelperClasses;
using ASING.ViewModels;

namespace ASING.Controllers
{
    public class GroupsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GroupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Groups
        public async Task<IActionResult> Index()
        {
            return View(await _context.Groups.ToListAsync());
        }

        // GET: Groups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @group = await _context.Groups
                .FirstOrDefaultAsync(m => m.GroupId == id);
            if (@group == null)
            {
                return NotFound();
            }

            return View(@group);
        }

        // GET: Groups/Create
        public IActionResult Create(int id)
        {
            var studentId = 1; 
            var studentAvailableTimeComparisionsViewModel = new StudentAvailableTimeComparisionsViewModel();
            studentAvailableTimeComparisionsViewModel.UnitId = id;
            studentAvailableTimeComparisionsViewModel.StudentId = studentId;
            studentAvailableTimeComparisionsViewModel.StudentAvailabilityMatchLists = StudentAvailability.GetAvailableTimeComparisions(studentId, id, _context); 
            return View(studentAvailableTimeComparisionsViewModel);
        }

        // POST: Groups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentAvailableTimeComparisionsViewModel studentAvailableTimeComparisionsViewModel)
        {
            if (ModelState.IsValid)
            {
                Group group = new Group(); 
                int id = 1;
                group.IsOpen = true;
                group.MaxNumber = 5;
                group.MinNumber = 3;
                //group.UnitId = ViewBag.GroupId; 
                group.OwnerId = studentAvailableTimeComparisionsViewModel.StudentId;
                group.UnitId = studentAvailableTimeComparisionsViewModel.UnitId;
                group.Name = studentAvailableTimeComparisionsViewModel.GroupName;
                _context.Add(@group);
                await _context.SaveChangesAsync();
                int groupId = group.GroupId;

                GroupMembership groupOwnerMembership = new GroupMembership();
                groupOwnerMembership.GroupId = groupId;
                groupOwnerMembership.StudentId = studentAvailableTimeComparisionsViewModel.StudentId;
                groupOwnerMembership.UnitId = group.UnitId;
                _context.Add(groupOwnerMembership);
                await _context.SaveChangesAsync();

                foreach (var studentAvailabilityMatchViewModel in studentAvailableTimeComparisionsViewModel.StudentAvailabilityMatchLists)
                {
                    if (studentAvailabilityMatchViewModel.IsSelected)
                    {
                        GroupMembership groupMembership = new GroupMembership();
                        groupMembership.GroupId = groupId;
                        groupMembership.StudentId = studentAvailabilityMatchViewModel.StudentId;
                        groupMembership.UnitId = group.UnitId;
                        _context.Add(groupMembership);
                        await _context.SaveChangesAsync();
                    }
                }

                
                

                return RedirectToAction("Details", "UniversityUsers", new { id });
            } 
            return View(studentAvailableTimeComparisionsViewModel);
        }

        // GET: Groups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @group = await _context.Groups.FindAsync(id);
            if (@group == null)
            {
                return NotFound();
            }
            return View(@group);
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GroupId,Name,IsOpen,MaxNumber,MinNumber")] Group @group)
        {
            if (id != @group.GroupId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@group);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupExists(@group.GroupId))
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
            return View(@group);
        }

        // GET: Groups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @group = await _context.Groups
                .FirstOrDefaultAsync(m => m.GroupId == id);
            if (@group == null)
            {
                return NotFound();
            }

            return View(@group);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @group = await _context.Groups.FindAsync(id);
            _context.Groups.Remove(@group);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupExists(int id)
        {
            return _context.Groups.Any(e => e.GroupId == id);
        }
    }
}
