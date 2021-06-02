using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASING.ViewModels
{
    public class StudentJoinGroupViewModel
    {
        public int UnitId { get; set; }
        public int StudentId { get; set; }
        public List<UnitGroupDetailsViewModel> UnitGroupDetails { get; set; } = new List<UnitGroupDetailsViewModel>();
    }
}
