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

    }
}
