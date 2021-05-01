using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }


    }
}
