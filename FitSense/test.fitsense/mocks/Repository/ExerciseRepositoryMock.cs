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

        public Task<List<Exercise>> GetExercisesFromCategoryAsync(Category category, string baseUrl)
        {
            return new Task<List<Exercise>>(() => 
            Exercises.FindAll((e) => 
            e.Category.CategoryID == category.CategoryID));
        }
    }
}
