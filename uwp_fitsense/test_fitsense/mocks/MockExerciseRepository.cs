using fitsense.DAL.dependencies;
using fitsense.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_fitsense.mocks
{
    public class MockExerciseRepository : IExerciseRepository
    {
        public List<Exercise> GetExercisesFromCategory(Category category)
        {
            return TestData.exercises.Where(exercise => exercise.CategoryID == category.CategoryID).ToList();
        }
    }
}
