using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSense.Model
{
    public class User : SensorModel
    {
        public int UserID { get; set; }
        public String Name { get; set; }
        public String Password { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
    }
}
