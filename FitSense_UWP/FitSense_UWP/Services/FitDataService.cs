using FitSense.DAL;
using Fitsense.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace FitSense_UWP.Services
{
    class FitDataService : IFitDataService
    {
        ICategoryRepository categoryRepository;
        IExerciseRepository exerciseRepository;
        ISetRepository setRepository;
        ICompletedSetRepository completedSetRepository;

        public FitDataService(ICategoryRepository categoryRepository, 
            IExerciseRepository exerciseRepository, 
            ISetRepository setRepository, 
            ICompletedSetRepository completedSetRepository)
        {
            this.categoryRepository = categoryRepository;
            this.exerciseRepository = exerciseRepository;
            this.setRepository = setRepository;
            this.completedSetRepository = completedSetRepository;
        }

        public List<Category> GetAllCategories()
        {
            return categoryRepository.GetCategories();
        }

        public List<Exercise> GetExercisesFromCategory(Category category)
        {

            return exerciseRepository.GetExercisesFromCategory(category);
        }

        public List<Set> GetSetsFromExercise(Exercise exercise)
        {
            return setRepository.GetSetsFromExercise(exercise);
        }

        public Set ToggleSelectedSetVisibility(Set set)
        {
            set.ShowCompletedSets = !set.ShowCompletedSets;
            return set;
        }

        public List<CompletedSet> GetCompletedSetsFromSet(Set set)
        {
            return completedSetRepository.GetCompletedSetsFromSet(set);
        }
    }
}
