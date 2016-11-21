using fitsense.DAL.dependencies;
using fitsense.models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test.fitsense.dal.mocks
{
    public class MockExerciseRepository : IExerciseRepository
    {
        public async Task<List<Exercise>> GetExercisesFromCategoryAsync(Category category, string baseUrl)
        {
            if (category != null)
                return await Task.Run(() => TestData.exercises.Where(exercise => exercise.CategoryID == category.CategoryID).ToList());
            return null;
        }
    }
}
