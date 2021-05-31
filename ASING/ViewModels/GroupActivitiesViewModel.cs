using ASING.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASING.ViewModels
{
    public class GroupActivitiesViewModel
    {
        public string GroupName { get; set; }
        public List<GroupEventViewModel> GroupEvents { get; set; } = new List<GroupEventViewModel>(); 

        public List<GroupActivityMembership> PendingMemberships = new List<GroupActivityMembership>(); 

    }
}
