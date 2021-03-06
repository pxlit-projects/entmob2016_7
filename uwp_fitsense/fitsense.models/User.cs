﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitsense.models
{
    public class User
    {
        public int UserID { get; set; }
        public String Name { get; set; }
        public String Password { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }

        public virtual List<CompletedSet> CompletedSets { get; set; }
    }
}
