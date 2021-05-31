﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASING.HelperClasses
{
    public class Constants
    {
        public enum Status
        {
            Invited  = 1, 
            Requested = 2,
            Accepted = 3 

        }

        public enum Frequency
        {
            None = 0,
            Daily = 1, 
            Weekly = 2
        }
    }
}
