using ASING.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ASING.ViewModels
{
    public class TimeDetailsViewModel
    {
        public int StudentId { get; set; }
        [DisplayName("Day")]
        public int DayId { get; set; }
        [DisplayName("Start Time")]
        public int StartTime { get; set; }
        [DisplayName("End Time")]
        public int EndTime { get; set; }
        public List<BlockedTime> BlockedTimes { get; set; } = new List<BlockedTime>();
        public List<Timetable> Timetables { get; set; } = new List<Timetable>(); 
    }
}
