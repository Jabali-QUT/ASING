using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASING.Models
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }
        public string Name { get; set; }
        public bool IsOpen { get; set; }
        public int MaxNumber { get; set; }
        public int MinNumber { get; set; }
    
    }
}
