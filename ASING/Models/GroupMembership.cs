using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static ASING.HelperClasses.Constants;

namespace ASING.Models
{
    public class GroupMembership
    {
        [Key]
        public int GroupMembershipId { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }

        [ForeignKey("UniversityUser")]
        public int StudentId { get; set; }
        public UniversityUser UniversityUser { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
        public int StatusId { get; set; }
        [NotMapped]
        public string StatusName
        {
            get { return (Enum.GetName(typeof(Status), StatusId)); } 
        }

    }
}
