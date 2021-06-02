using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASING.Models
{
    public class WorkDay
    {
        [Key]
        public int DayId { get; set; }
        public string DayName { get; set; }
    }
}
