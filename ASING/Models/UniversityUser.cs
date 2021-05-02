using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASING.Models
{
    public class UniversityUser
    {

        [Key] 
        public int UniversityId { get; set; }
        public string FirstName { get; set; }
        public string  Surname { get; set; }
        public string Profile { get; set; }

    }
}
