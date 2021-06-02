using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASING.ViewModels
{
    public class GroupEventViewModel
    {
        public int GroupActivityId { get; set; }
        public string EventDescription { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Isrecurring { get; set; }
        public string Frequency { get; set; }
        public string CreatedBy { get; set; }
        public List<GroupEventParticipationViewModel> GroupEventParticipation { get; set; } = new List<GroupEventParticipationViewModel>();
    }
}
