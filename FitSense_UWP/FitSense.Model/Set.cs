using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSense.Model
{
    public class Set : SensorModel
    {
        public int Reps { get; set; }
        public int ExerciseID { get; set; }
        public int Points { get; set; }
        public int MaxTime { get; set; }
    }
}
