using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSense.Model
{
    public class Exercise : SensorModel
    {
        public int ExerciseID { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public int CategoryID { get; set; }
    }
}
