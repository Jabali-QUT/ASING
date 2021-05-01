using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASING.Models
{
    public class Registration
    {
        [Key]
        public int RegistrationId { get; set; }
        [ForeignKey("UniversityUser")]
        public int StudentId { get; set; }
        public UniversityUser UniversityUser { get; set; }   
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
    }
}
