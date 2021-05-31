using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASING.ViewModels
{
    public class GroupEventParticipationViewModel
    {
        public int GroupActivityMembershipId { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
    }
}
