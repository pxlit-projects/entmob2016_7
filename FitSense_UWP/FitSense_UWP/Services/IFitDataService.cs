using FitSense.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSense_UWP.Services
{
    public interface IFitDataService
    {
        //Category
        void DeleteCategory(Category category);
        List<Category> GetAllCategories();
        Category GetCategoryDetail(int id);
        void UpdateCategory(Category category);

        //Exercise
        void DeleteExercise(Exercise exercise);
        List<Exercise> GetAllExercises();
        Exercise GetExerciseDetail(int id);
        void UpdateExercuse(Exercise exercise);
        List<Exercise> GetExercisesFromCategory(Category category);

        //Set
        List<Set> GetSetsFromExercise(Exercise exercise);
    }
}
