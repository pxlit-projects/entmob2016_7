using fitsense.DAL.dependencies;
using fitsense.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitsense.DAL
{
    public class ExerciseRepository : IExerciseRepository
    {
        public List<Exercise> GetExercisesFromCategory(Category category)
        {
            if (category != null)
            {
                return DummyData.exercises.Where(ex => ex.CategoryID == category.CategoryID).ToList();
            }
            else
            {
                return new List<Exercise>();
            }
        }
    }
}
