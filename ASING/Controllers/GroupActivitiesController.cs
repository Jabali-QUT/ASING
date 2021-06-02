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
using ASING.HelperClasses;
using System.Text;
using static ASING.HelperClasses.Constants;

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
            //var groupActivities = _context.GroupActivities.Include(g => g.Group)
            //    .Include(g => g.UniversityUser)
            //    .Include(g => g.GroupActivityMemberships)
            //    .Where(g => g.GroupId == groupId).ToListAsync();

            var group = _context.Groups.Where(g => g.GroupId == groupId).FirstOrDefault();
            var groupActivities = _context.GroupActivities.Include(ga => ga.UniversityUser).Where(ga => ga.GroupId == groupId).ToList();
            var pendingMemberships = _context.GroupActivityMemberships.Where(g => g.StudentId == studentId && g.StatusId != (int)Status.Accepted && g.GroupId == groupId).ToList(); 
            GroupActivitiesViewModel groupActivitiesVM = new GroupActivitiesViewModel();

            groupActivitiesVM.GroupName = group.Name;
            groupActivitiesVM.GroupId = group.GroupId;
            groupActivitiesVM.StudentId = studentId;

            foreach (var pendingMembership in pendingMemberships)
            {
                GroupActivityMembershipViewModel groupActivityMembershipVM = new GroupActivityMembershipViewModel();
                var tempGroupActivity = _context.GroupActivities.Where(g => g.GoupActivityId == pendingMembership.GoupActivityId).FirstOrDefault();
                groupActivityMembershipVM.GroupActivityMembershipId = pendingMembership.GroupActivityMembershipId;
                groupActivityMembershipVM.GroupId = pendingMembership.GroupId;
                groupActivityMembershipVM.StudentId = pendingMembership.StudentId;
                groupActivityMembershipVM.Summary = tempGroupActivity.Summary;
                groupActivityMembershipVM.Location = tempGroupActivity.Location;
                groupActivityMembershipVM.StartTime = tempGroupActivity.StartTime;
                groupActivityMembershipVM.EndTime = tempGroupActivity.EndTime; 
                groupActivitiesVM.PendingMemberships.Add(groupActivityMembershipVM);
            }

            foreach (var groupActivity in groupActivities)
            {
                GroupEventViewModel groupEventVM = new GroupEventViewModel();
                groupEventVM.GroupActivityId = groupActivity.GoupActivityId;
                groupEventVM.EventDescription = groupActivity.Description;
                groupEventVM.StartTime = groupActivity.StartTime;
                groupEventVM.EndTime = groupActivity.EndTime;
                groupEventVM.Isrecurring = groupActivity.Isrecurring;
                groupEventVM.Frequency = groupActivity.FrequencyName;
                groupEventVM.CreatedBy = groupActivity.UniversityUser.Fullname;
                var groupEventParticipations = _context.GroupActivityMemberships.Include(g => g.UniversityUser).Where(g => g.GoupActivityId == groupActivity.GoupActivityId && g.GroupId == groupId).ToList();
                foreach (var groupEventParticipation in groupEventParticipations)
                {
                    GroupEventParticipationViewModel groupEventParticipationVM = new GroupEventParticipationViewModel();
                    groupEventParticipationVM.GroupActivityMembershipId = groupEventParticipation.GroupActivityMembershipId;
                    groupEventParticipationVM.StudentId = groupEventParticipation.StudentId;
                    groupEventParticipationVM.StudentName = groupEventParticipation.UniversityUser.Fullname;
                    groupEventParticipationVM.StatusId = groupEventParticipation.StatusId;
                    groupEventParticipationVM.StatusName = groupEventParticipation.StatusName;
                    groupEventVM.GroupEventParticipation.Add(groupEventParticipationVM); 
                }

                groupActivitiesVM.GroupEvents.Add(groupEventVM);

            }
            return View(groupActivitiesVM);
        }

        public async Task<IActionResult> AcceptGroupActivityMembership(int groupActivityMembershipId, int groupId, int studentId)
        {
            var groupActivityMembership = _context.GroupActivityMemberships.Where(g => g.GroupActivityMembershipId == groupActivityMembershipId).FirstOrDefault();
            groupActivityMembership.StatusId = (int)Status.Accepted;
            _context.Update(groupActivityMembership);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "GroupActivities", new { groupId, studentId });
        }

        public async Task<IActionResult> DenyGroupActivityMembership(int groupActivityMembershipId, int groupId, int studentId)
        {
            var groupActivityMembership = await _context.GroupActivityMemberships.FindAsync(groupActivityMembershipId);
            _context.GroupActivityMemberships.Remove(groupActivityMembership);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "GroupActivities", new { groupId, studentId });
        }


        [HttpGet("download")]
        public IActionResult DownloadCalendar(int groupId)
        {
            var groupActivities = _context.GroupActivities.Where(g => g.GroupId == groupId).ToList();
            var calendarString = ActivityCalendar.DownloadCalendar(groupActivities);
            var fileContents = Encoding.ASCII.GetBytes(calendarString);
            var contentType = "text/calendar";
            var fileDownloadName = "GroupActivity.ics";
            return File(fileContents, contentType, fileDownloadName);

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
        public IActionResult Create(int groupId, int studentId)
        {
            var groupActivity = new GroupActivity();
            groupActivity.GroupId = groupId;
            groupActivity.OwnerId = studentId; 
            return View(groupActivity);
        }

        // POST: GroupActivities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GroupActivity groupActivity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groupActivity);
                await _context.SaveChangesAsync();
                int groupActivityId = groupActivity.GoupActivityId;
                var studentIdsInGroup = _context.GroupMemberships.Where(g => g.GroupId == groupActivity.GroupId).Select(m => m.StudentId).ToList();

                foreach (var studentId in studentIdsInGroup)
                {
                    GroupActivityMembership groupActivityMembership = new GroupActivityMembership();
                    groupActivityMembership.GroupId = groupActivity.GroupId;
                    groupActivityMembership.GoupActivityId = groupActivityId;
                    groupActivityMembership.StudentId = studentId;
                    groupActivityMembership.StatusId = groupActivity.OwnerId == studentId ? (int)Status.Accepted : (int)Status.Invited;
                    _context.Add(groupActivityMembership);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction("Index", new { groupId = groupActivity.GroupId, studentId = groupActivity.OwnerId });
            }

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
