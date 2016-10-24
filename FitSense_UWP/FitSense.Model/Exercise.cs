﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSense.Model
{
    public class Exercise : SensorModel
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public int CategoryID { get; set; }
        public bool Selected { get; set; }
        public List<Set> Sets { get; set; }
    }
}
