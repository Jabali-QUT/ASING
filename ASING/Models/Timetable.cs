using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASING.Models
{
    public class Timetable
    {
        [Key]
        public int TimetableId { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
        public int DayId { get; set; }
        public WorkDay WorkDay { get; set; }
        public int ClassTypeId { get; set; }
        public ClassType ClassType { get; set; }
        public DateTime StartTime { get; set; } 
        public DateTime EndTtime { get; set; }    
    }
}
