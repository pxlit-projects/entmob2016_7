using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitsense.Models;

namespace FitSense.DAL
{
    public class ExerciseRepository : IExerciseRepository
    {
        public List<Exercise> GetExercisesFromCategory(Category category)
        {
            if (category != null)
            {
               return DummyData.exercises.Where(ex => ex.CategoryID == category.ID).ToList();
                
            }

            else
                return new List<Exercise>();
        }
    }
}
