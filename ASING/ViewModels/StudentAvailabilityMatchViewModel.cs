using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASING.ViewModels
{
    public class StudentAvailabilityMatchViewModel
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public string MondayMatch { get; set; }
        public string TuesdayMatch { get; set; }
        public string WednesdayMatch { get; set; }
        public string ThursdayMatch { get; set; }
        public string FridayMatch { get; set; }
        public string OverallMatch { get; set; }

    }
}
