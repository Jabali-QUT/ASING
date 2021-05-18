using ASING.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASING.ViewModels
{
    public class UnitDetailsViewModel
    {
        public int UnitId { get; set; }
        public string UnitName { get; set; } 
        public string GroupName { get; set; }
        public int  OwnerId { get; set; }
        public List<GroupMembership> GroupMemberships { get; set; } = new List<GroupMembership>(); 
    }
}
