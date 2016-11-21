using fitsense.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uwp_fitsense.dependencies
{
    public interface IFitDataService
    {
        Task<List<Category>> GetAllCategoriesAsync();
        Task AddCategoryAsync(Category category);
        Task<List<Exercise>> GetExercisesFromCategoryAsync(Category category);
        Task<List<Set>> GetSetsFromExerciseAsync(Exercise exercise);
        Set ToggleSelectedSetVisibility(Set set);
        Task<List<CompletedSet>> GetCompletedSetsFromSetAsync(Set set);
    }
}
