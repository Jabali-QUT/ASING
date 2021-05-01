using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASING.Models
{
    public class Unit
    {
        [Key]
        public int UnitId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool GroupsAllowed { get; set; }
        public bool IsAssesementGroup { get; set; }
        public ICollection<Timetable> Timetables { get; set; }


    }
}
