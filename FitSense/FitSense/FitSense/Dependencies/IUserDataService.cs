using fitsense.models;
using FitSense.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSense.Dependencies
{
    public interface IUserDataService
    {
        User LoggedInUser { get; set; }

        User SearchUser(string userName);
        Task LoginAsync(string userName, string password);
        Task<List<Category>> GetAllCategoriesAsync();
        Task<List<Exercise>> GetExercisesFromCategoryAsync(Category category);
        Task<List<Set>> GetSetsFromExerciseAsync(Exercise exercise);
        Task<List<SetViewModel>> GetSetViewModelsFromExerciseAsync(Exercise exercise, INavigationService navigationService);
    }
}
