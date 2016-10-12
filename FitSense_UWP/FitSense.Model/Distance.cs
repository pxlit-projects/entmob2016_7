using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSense.Model
{
    public class Distance : SensorModel
    {
        public DateTime Time { get; set; }
        public int AmountOfSteps { get; set; }
        public int Height { get; set; }
    }
}
