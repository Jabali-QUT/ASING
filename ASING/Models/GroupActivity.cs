using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static ASING.HelperClasses.Constants;

namespace ASING.Models
{
    public class GroupActivity
    {
        [Key]
        public int GoupActivityId { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        
        [DisplayName("Recurring")]
        public bool Isrecurring { get; set; }
        [DisplayName("Frequency")]
        public int FrequencyId { get; set; }
        
        [NotMapped]
        public string FrequencyName
        {
            get { return (Enum.GetName(typeof(Frequency), FrequencyId)); }
        }

        [ForeignKey("UniversityUser")]
        public int OwnerId { get; set; }
        public UniversityUser UniversityUser { get; set; }
        public ICollection<GroupActivityMembership> GroupActivityMemberships { get; set; }

    }
}
