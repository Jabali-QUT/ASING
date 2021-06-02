using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASING.ViewModels
{
    public class GroupActivityMembershipViewModel
    {
        public int GroupActivityMembershipId { get; set; }
        public int GroupId { get; set; }
        public int StudentId { get; set; }
        public string Summary { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

    }
}
