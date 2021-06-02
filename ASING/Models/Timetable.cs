using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static ASING.HelperClasses.Constants;

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
        public int StartTime { get; set; } 
        public int EndTime { get; set; }

        [NotMapped]
        public string DayName
        {
            get { return (Enum.GetName(typeof(Days), DayId)); }
        }
    }
}
