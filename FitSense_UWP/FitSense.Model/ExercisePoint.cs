using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSense.Model
{
    public class ExercisePoint : SensorModel
    {
        public int ExercisePointID { get; set; }
        public int ChangeX { get; set; }
        public int ChangeY { get; set; }
        public int ChangeZ { get; set; }
        public int ExersiceID { get; set; }
    }
}
