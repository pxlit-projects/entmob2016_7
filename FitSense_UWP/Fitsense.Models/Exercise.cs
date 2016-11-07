using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitsense.Models
{
    public class Exercise : SensorModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public Category Category {get;set;}
        public bool Selected { get; set; }

        public virtual List<ExercisePoint> ExercisePoints { get; set; }
        public virtual List<Set> Sets { get; set; }
    }
}
