using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASING.Models
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }
        public string Name { get; set; }
        public bool IsOpen { get; set; }
        public int MaxNumber { get; set; }
        public int MinNumber { get; set; }
        
        [ForeignKey("UniversityUser")]
        public int OwnerId { get; set; } 
        public UniversityUser UniversityUser { get; set; }

        public int UnitId { get; set; }
        public Unit Unit { get; set; }

        public ICollection<GroupMembership> GroupMemberships { get; set; }

    }
}
