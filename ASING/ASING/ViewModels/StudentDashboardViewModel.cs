using ASING.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASING.ViewModels
{
    public class StudentDashboardViewModel
    {
        public UniversityUser UniversityUser { get; set; }
        public List<UnitDetailsViewModel> UnitDetails { get; set; } = new List<UnitDetailsViewModel>(); 
        public Dictionary<int, HashSet<string>> BusyTimes { get; set; }
        public List<WorkDay> WorkDays { get; set; } = new List<WorkDay>(); 



    }
}
