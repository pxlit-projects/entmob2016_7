using fitsense.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fitsense.DAL.dependencies
{
    public interface IExerciseRepository
    {
        Task<List<Exercise>> GetExercisesFromCategoryAsync(Category category, string baseUrl);
    }
}
