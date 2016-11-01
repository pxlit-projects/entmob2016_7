using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitsense.Models
{
    public class Category : SensorModel
    {
        public string Name { get; set; }
        public List<Exercise> Exercises { get; set; }
    }
}
