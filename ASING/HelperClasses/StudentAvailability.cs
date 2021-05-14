
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



        public static string GetStudentsAvailableTime() {
            List<string> allTimeBlocks = new List<string>(allTimes);
            //this should just work out the available times  
            //provide a dictionary of day ID as key and list of available times
            //find all timetables and blocked times 
            //add those timetables and blocked times to a list  
            //do an except to get the free time blocks list 
            //add this to a dictionary a return that diction 

            return "";
        }

        public static string GetStudentsBusyTimes()
        {
            
            return "";
        }

        public static string GetStudentsTimetableTimes(int studentId, ApplicationDbContext dbContext)
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
                    HashSet<string> timeTokens = GetTimeTokensFromTimetables(dailyTimetables);
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



            return "";
        }

        public static string GetStudentsBlockedTimes()
        {
            return "";
        }

        public static HashSet<string> GetTimeTokensFromTimetables(List<Timetable> dailyTimetables)
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
