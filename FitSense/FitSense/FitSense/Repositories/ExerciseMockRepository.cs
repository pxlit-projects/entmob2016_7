using fitsense.DAL.dependencies;
using fitsense.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace fitsense.DAL
{
    public class ExerciseMockRepository : IExerciseRepository
    {
        public async Task<List<Exercise>> GetExercisesFromCategoryAsync(Category category, string baseUrl)
        {
            return await Task.Run(() => DummyData.exercises.Where(ex => ex.CategoryID == category.CategoryID).ToList());
        }
    }
}
