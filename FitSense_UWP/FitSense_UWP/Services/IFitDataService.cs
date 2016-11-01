using Fitsense.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSense_UWP.Services
{
    public interface IFitDataService
    {
        List<Category> GetAllCategories();
        List<Exercise> GetExercisesFromCategory(Category category);
        List<Set> GetSetsFromExercise(Exercise exercise);
        Set ToggleSelectedSetVisibility(Set set);
        List<CompletedSet> GetCompletedSetsFromSet(Set set);

    }
}
