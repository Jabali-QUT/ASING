using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASING.ViewModels
{
    public class UnitGroupDetailsViewModel
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string GroupOverallMatch { get; set; }
        public List<StudentAvailabilityMatchViewModel> GroupStudentAvailabilityMatchLists { get; set; }
    }
}
