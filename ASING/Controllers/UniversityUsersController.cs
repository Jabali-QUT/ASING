using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASING.Data;
using ASING.Models;
using ASING.ViewModels;

namespace ASING.Controllers
{
    public class UniversityUsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UniversityUsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UniversityUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.UniversityUsers.ToListAsync());
        }

        // GET: UniversityUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var universityUser = await _context.UniversityUsers
                .FirstOrDefaultAsync(m => m.UniversityId == id);
            if (universityUser == null)
            {
                return NotFound();
            }

            var registrations = await _context.Registrations.Where(r => r.StudentId == id).ToListAsync();
            var studentDashboardVM = new StudentDashboardViewModel();
            studentDashboardVM.UniversityUser = universityUser; 
   
            foreach (var registration in registrations)
            {
                var groupMembership = await _context.GroupMemberships.Where(gm => gm.StudentId == id && gm.UnitId == registration.UnitId).ToListAsync(); 
                int? groupId = groupMembership.Count> 0 ? groupMembership.FirstOrDefault().GroupId: null;
                var group = groupId != null ? await _context.Groups.FindAsync(groupId):null;

                var allGroupMembers = groupId != null ? await _context.GroupMemberships.Where(gm => gm.GroupId == groupId).ToListAsync() : null;
                var unit = await _context.Units.FindAsync(registration.UnitId);

                //create the unit details VM 
                var unitDetailsVM = new UnitDetailsViewModel();
                unitDetailsVM.UnitId = registration.UnitId; 
                unitDetailsVM.UnitName = unit.Name;
                unitDetailsVM.GroupName = group != null ? group.Name: String.Empty;
                unitDetailsVM.OwnerId = group != null ? group.OwnerId: 0; 
                unitDetailsVM.GroupMemberships = allGroupMembers;

                //add to students
                studentDashboardVM.UnitDetails.Add(unitDetailsVM);

            }

            return View(studentDashboardVM);
        } 



        // GET: UniversityUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UniversityUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UniversityId,FirstName,Surname,Profile")] UniversityUser universityUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(universityUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(universityUser);
        }

        // GET: UniversityUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var universityUser = await _context.UniversityUsers.FindAsync(id);
            if (universityUser == null)
            {
                return NotFound();
            }
            return View(universityUser);
        }

        // POST: UniversityUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UniversityId,FirstName,Surname,Profile")] UniversityUser universityUser)
        {
            if (id != universityUser.UniversityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(universityUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UniversityUserExists(universityUser.UniversityId))
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
            return View(universityUser);
        }

        // GET: UniversityUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var universityUser = await _context.UniversityUsers
                .FirstOrDefaultAsync(m => m.UniversityId == id);
            if (universityUser == null)
            {
                return NotFound();
            }

            return View(universityUser);
        }

        // POST: UniversityUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var universityUser = await _context.UniversityUsers.FindAsync(id);
            _context.UniversityUsers.Remove(universityUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UniversityUserExists(int id)
        {
            return _context.UniversityUsers.Any(e => e.UniversityId == id);
        }
    }
}
