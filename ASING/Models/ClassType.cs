using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASING.Models
{
    public class ClassType
    {
        [Key]
        public int ClassTypeId { get; set; }
        public string ClassTypeDescription { get; set; }
    }
}
