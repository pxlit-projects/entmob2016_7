using fitsense.DAL.dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fitsense.models;

namespace test.fitsense.mocks.Repository
{
    class ExerciseRepositoryMock : IExerciseRepository
    {
        public List<Exercise> Exercises;

        public async Task<List<Exercise>> GetExercisesFromCategoryAsync(Category category, string baseUrl)
        {
            if (category != null)
                return await Task.Run(() => Exercises.Where(exercise => exercise.CategoryID == category.CategoryID).ToList());
            return null;
        }
    }
}
