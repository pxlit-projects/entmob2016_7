using fitsense.DAL.dependencies;
using fitsense.models;
using System.Collections.Generic;
using System.Linq;

namespace test.fitsense.dal.mocks
{
    public class MockExerciseRepository : IExerciseRepository
    {
        public List<Exercise> GetExercisesFromCategory(Category category)
        {
            if(category != null)
                return TestData.exercises.Where(exercise => exercise.CategoryID == category.CategoryID).ToList();
            return null;
        }
    }
}
