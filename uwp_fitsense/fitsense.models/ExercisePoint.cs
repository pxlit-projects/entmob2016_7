﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitsense.models
{
    public class ExercisePoint
    {
        public int ChangeX { get; set; }
        public int ChangeY { get; set; }
        public int ChangeZ { get; set; }
        public int ExerciseID { get; set; }
        public Exercise Exercise { get; set; }
    }
}
