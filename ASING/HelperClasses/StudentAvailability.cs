
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASING.Data;
using ASING.Models;
using ASING.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ASING.HelperClasses
{
    public static class StudentAvailability
    {
        private static ApplicationDbContext _context;

        private const string eightToNine = "08-09";
        private const string nineToTen = "09-10";
        private const string TenToElleven = "10-11";
        private const string ElevenToTwelve = "11-12";
        private const string TwelveToThirteen = "12-13";
        private const string ThirteenToFourteen = "13-14";
        private const string FourteenToFifteen = "14-15";
        private const string FifteenToSixteen = "15-16";
        private const string SixteenToSeventeen = "16-17";
        private const string SeventeenToEighteen = "17-18";
        private const string EighteenToNineteen = "18-19";
        private const string NineteenToTwenty = "19-20";

        private static string[] allTimes = { eightToNine, nineToTen, TenToElleven, ElevenToTwelve, TwelveToThirteen,
            ThirteenToFourteen, FourteenToFifteen, FifteenToSixteen, SixteenToSeventeen, SeventeenToEighteen,
            EighteenToNineteen, NineteenToTwenty};


        public static string GetAvailableTimeComparisions(int studentId, int unitId, ApplicationDbContext dbContext)
        {
            _context = dbContext;
            Dictionary<int, HashSet<string>> dictCurrentStudentAvailableTimesByDay = GetStudentsAvailableTimes(studentId, _context);
            Dictionary<int, HashSet<string>> dictOtherStudentAvailableTimesByDay;
            List<StudentAvailabilityMatchViewModel> studentAvailabilityMatches = new List<StudentAvailabilityMatchViewModel>(); 

            var registrations = _context.Registrations.Where(r => r.UnitId == unitId && r.StudentId != studentId)
                .Include(r => r.UniversityUser);
            foreach (var registration in registrations)
            {
                StudentAvailabilityMatchViewModel studentAvailabilityMatch = new StudentAvailabilityMatchViewModel(); 
                dictOtherStudentAvailableTimesByDay = GetStudentsAvailableTimes(registration.StudentId, _context);
                studentAvailabilityMatch.StudentId = registration.StudentId;
                studentAvailabilityMatch.FullName = string.Concat(registration.UniversityUser.FirstName, " ", registration.UniversityUser.Surname);
                //Lets do Monday 
                HashSet<string> currentStudentMonday = new HashSet<string>(dictCurrentStudentAvailableTimesByDay[1]);
                int currentStudentMondayCount = currentStudentMonday.Count(); 
                HashSet<string> otherStudentMonday = new HashSet<string>(dictOtherStudentAvailableTimesByDay[1]);
                currentStudentMonday.IntersectWith(otherStudentMonday); 
                int intersectMondayCount = currentStudentMonday.Count();
                double mondayMatchScore = Math.Round((intersectMondayCount * 1.0 / currentStudentMondayCount) * 100, 2);
                studentAvailabilityMatch.MondayMatch = mondayMatchScore.ToString();

                //Lets do Tuesday 
                HashSet<string> currentStudentTuesday = new HashSet<string>(dictCurrentStudentAvailableTimesByDay[2]);
                int currentStudentTuesdayCount = currentStudentTuesday.Count();
                HashSet<string> otherStudentTuesday = new HashSet<string>(dictOtherStudentAvailableTimesByDay[2]);
                currentStudentTuesday.IntersectWith(otherStudentTuesday);
                int intersectTuesdayCount = currentStudentTuesday.Count();
                double tuesdayMatchSore = Math.Round((intersectTuesdayCount * 1.0 / currentStudentTuesdayCount) * 100, 2);
                studentAvailabilityMatch.TuesdayMatch = tuesdayMatchSore.ToString();

                //Lets do Wednesday 
                HashSet<string> currentStudentWednesday = new HashSet<string>(dictCurrentStudentAvailableTimesByDay[3]);
                int currentStudentWednesdayCount = currentStudentWednesday.Count();
                HashSet<string> otherStudentWednesday = new HashSet<string>(dictOtherStudentAvailableTimesByDay[3]);
                currentStudentWednesday.IntersectWith(otherStudentWednesday);
                int intersectWednesdayCount = currentStudentWednesday.Count();
                double wednesdayMatchScore = Math.Round((intersectWednesdayCount * 1.0 / currentStudentWednesdayCount) * 100, 2);
                studentAvailabilityMatch.WednesdayMatch = wednesdayMatchScore.ToString();

                //Lets do Thursday 
                HashSet<string> currentStudentThursday = new HashSet<string>(dictCurrentStudentAvailableTimesByDay[4]);
                int currentStudentThursdayCount = currentStudentThursday.Count();
                HashSet<string> otherStudentThursday = new HashSet<string>(dictOtherStudentAvailableTimesByDay[4]);
                currentStudentThursday.IntersectWith(otherStudentThursday);
                int intersectThursdayCount = currentStudentThursday.Count();
                double thursdayMatchScore = Math.Round((intersectThursdayCount * 1.0 / currentStudentThursdayCount) * 100, 2);
                studentAvailabilityMatch.ThursdayMatch = thursdayMatchScore.ToString();

                //Lets do Friday 
                HashSet<string> currentStudentFriday = new HashSet<string>(dictCurrentStudentAvailableTimesByDay[5]);
                int currentStudentFridayCount = currentStudentFriday.Count();
                HashSet<string> otherStudentFriday = new HashSet<string>(dictOtherStudentAvailableTimesByDay[5]);
                currentStudentFriday.IntersectWith(otherStudentFriday);
                int intersectFridayCount = currentStudentFriday.Count();
                double fridayMatchScore = Math.Round((intersectFridayCount * 1.0 / currentStudentFridayCount) * 100, 2);
                studentAvailabilityMatch.FridayMatch = fridayMatchScore.ToString();

                //Overall match score 
                studentAvailabilityMatch.OverallMatch = ((mondayMatchScore + tuesdayMatchSore + wednesdayMatchScore + thursdayMatchScore + fridayMatchScore) / 5).ToString();

                studentAvailabilityMatches.Add(studentAvailabilityMatch);
            }

            return ""; 
        }


        public static Dictionary<int, HashSet<string>> GetStudentsAvailableTimes(int studentId, ApplicationDbContext dbContext) {
            _context = dbContext;
            HashSet<string> availableTimeBlocks; //= new HashSet<string>(allTimes);
            Dictionary<int, HashSet<string>> dictStudentAvailableTimesByDay = new Dictionary<int, HashSet<string>>();
            Dictionary<int, HashSet<string>> dictStudentBusyTimesByDay = GetStudentsBusyTimes(studentId, _context);

            foreach (var day in _context.WorkDays)
            {
                availableTimeBlocks = new HashSet<string>(allTimes);
                HashSet<string> retrivedBusyTimesByDay = new HashSet<string>(dictStudentBusyTimesByDay[day.DayId]);
                availableTimeBlocks.ExceptWith(retrivedBusyTimesByDay);
                dictStudentAvailableTimesByDay.Add(day.DayId, availableTimeBlocks);
            }
            return dictStudentAvailableTimesByDay;
        }

        public static Dictionary<int, HashSet<string>> GetStudentsBusyTimes(int studentId, ApplicationDbContext dbContext)
        {
            _context = dbContext; 
            Dictionary<int, HashSet<string>> dictStudentBusyTimesByDay = new Dictionary<int, HashSet<string>>();
            Dictionary<int, HashSet<string>> dictTimetableByDay = GetStudentsTimetableTimes(studentId, _context);
            Dictionary<int, HashSet<string>> dictBlockedTimesByDay = GetStudentsBlockedTimes(studentId, _context);
            HashSet<string> timetableTimeTokenByDay;
            HashSet<string> blockedTimeTokenByDay;

            foreach (var day in _context.WorkDays)
            {
                timetableTimeTokenByDay = new HashSet<string>();
                blockedTimeTokenByDay = new HashSet<string>();
                if (dictTimetableByDay.ContainsKey(day.DayId))
                {
                    timetableTimeTokenByDay = dictTimetableByDay[day.DayId]; 
                }
                if (dictBlockedTimesByDay.ContainsKey(day.DayId))
                {
                    blockedTimeTokenByDay = dictBlockedTimesByDay[day.DayId]; 
                }
                timetableTimeTokenByDay.UnionWith(blockedTimeTokenByDay);
                dictStudentBusyTimesByDay.Add(day.DayId, timetableTimeTokenByDay);
            }

            return dictStudentBusyTimesByDay;
        }

       

        public static Dictionary<int, HashSet<string>> GetStudentsTimetableTimes(int studentId, ApplicationDbContext dbContext)
        {
            _context = dbContext;
            Dictionary<int, HashSet<string>> dictTimetableByDay = new Dictionary<int, HashSet<string>>();
            
            var registrationsForStudent = _context.Registrations.Where(r => r.StudentId == studentId);

            foreach (var registration in registrationsForStudent) 
            {
                var timetables = _context.Timetables.Where(t => t.UnitId == registration.UnitId);
                foreach (var day in _context.WorkDays)
                {
                    var dailyTimetables = timetables.Where(dt => dt.DayId == day.DayId).ToList();
                    List<TimeDetail> timeDetails = new List<TimeDetail>();
                    foreach (var dailyTimetable in dailyTimetables)
                    {
                        TimeDetail timeDetail = new TimeDetail();
                        timeDetail.ID = dailyTimetable.TimetableId;
                        timeDetail.StartTime = dailyTimetable.StartTime;
                        timeDetail.EndTime = dailyTimetable.EndTime;
                        timeDetails.Add(timeDetail); 
                    }
                    HashSet<string> timeTokens = GetTimeTokensFromTimetables(timeDetails);
                    if (!dictTimetableByDay.ContainsKey(day.DayId))
                    {
                        if (timeTokens != null && timeTokens.Count > 0)
                        {
                            dictTimetableByDay.Add(day.DayId, timeTokens);
                        }
                    }
                    else
                    {
                        HashSet<string> retrievedTimeTokens = new HashSet<string>(dictTimetableByDay[day.DayId]);
                        retrievedTimeTokens.UnionWith(timeTokens);
                        dictTimetableByDay[day.DayId] = retrievedTimeTokens; 
                    }

                }
            }

            return dictTimetableByDay;
        }

        public static Dictionary<int, HashSet<string>> GetStudentsBlockedTimes(int studentId, ApplicationDbContext dbContext)
        {
            _context = dbContext;
            Dictionary<int, HashSet<string>> dictBlockedTimesByDay = new Dictionary<int, HashSet<string>>();
            var blockedTimes = _context.BlockedTimes.Where(b => b.StudentId == studentId);

            foreach (var day in _context.WorkDays)
            {
                var dailyBlockedTimes = blockedTimes.Where(dt => dt.DayId == day.DayId).ToList();
                List<TimeDetail> timeDetails = new List<TimeDetail>();
                foreach (var dailyBlockedTime in dailyBlockedTimes)
                {
                    TimeDetail timeDetail = new TimeDetail();
                    timeDetail.ID = dailyBlockedTime.BlockedTimeId;
                    timeDetail.StartTime = dailyBlockedTime.StartTime;
                    timeDetail.EndTime = dailyBlockedTime.EndTime;
                    timeDetails.Add(timeDetail);
                }
                HashSet<string> timeTokens = GetTimeTokensFromTimetables(timeDetails);
                if (!dictBlockedTimesByDay.ContainsKey(day.DayId))
                {
                    if (timeTokens != null && timeTokens.Count > 0)
                    {
                        dictBlockedTimesByDay.Add(day.DayId, timeTokens);
                    }
                }
                else
                {
                    HashSet<string> retrievedTimeTokens = new HashSet<string>(dictBlockedTimesByDay[day.DayId]);
                    retrievedTimeTokens.UnionWith(timeTokens);
                    dictBlockedTimesByDay[day.DayId] = retrievedTimeTokens;
                }
            }
                return dictBlockedTimesByDay;
        }

        public static HashSet<string> GetTimeTokensFromTimetables(List<TimeDetail> dailyTimetables)
        {
            HashSet<string> timeTokensFromTimetables = new HashSet<string>();
            string fmt = "00.##";
            foreach (var dailyTimeTable in dailyTimetables)
            {
                int i = dailyTimeTable.StartTime;
                while (i < dailyTimeTable.EndTime)
                {
                    int addedHour = i+1; 
                    string timeToken = string.Concat(i.ToString(fmt), "-", (addedHour).ToString(fmt));
                    bool added = timeTokensFromTimetables.Add(timeToken);
                    i = i + 1; 
                }

            }
            return timeTokensFromTimetables;

        }
    }
}
