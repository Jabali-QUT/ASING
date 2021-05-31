using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [NotMapped]
        public string Fullname
        {
            get { return string.Concat(FirstName, " ", Surname); }
        }
}
}
