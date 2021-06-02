using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static ASING.HelperClasses.Constants;

namespace ASING.Models
{
    public class BlockedTime
    {
        [Key]
        public int BlockedTimeId { get; set; }
        
        [ForeignKey("UniversityUser")]
        public int StudentId { get; set; }
        public UniversityUser UniversityUser { get; set; }
        public int DayId { get; set; }
        public WorkDay WorkDay { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }

        [NotMapped]
        public string DayName 
        { get { return (Enum.GetName(typeof(Days), DayId)); } 
        }

    }
}
