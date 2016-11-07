using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitsense.Models;

namespace FitSense.DAL
{
    public class SetRepository : ISetRepository
    {
        public List<Set> GetSetsFromExercise(Exercise exercise)
        {
            return DummyData.sets.Where(set => set.ExerciseID == exercise.ID).ToList();
        }
    }
}
