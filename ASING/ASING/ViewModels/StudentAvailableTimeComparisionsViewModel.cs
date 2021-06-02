using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASING.ViewModels
{
    public class StudentAvailableTimeComparisionsViewModel
    {
        public int StudentId { get; set; }
        public int UnitId { get; set; }
        public string GroupName { get; set; }
        public List<StudentAvailabilityMatchViewModel> StudentAvailabilityMatchLists { get; set; }
    }
}
