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
        SensorRepository repository;

        public FitDataService(SensorRepository repository)
        {
            this.repository = repository; 
        }

        public List<Category> GetAllCategories()
        {
            return repository.GetAllCategories();
        }

        public List<Exercise> GetExercisesFromCategory(Category category)
        {

            return repository.GetExercisesFromCategory(category);
        }

        public List<Set> GetSetsFromExercise(Exercise exercise)
        {
            return repository.GetSetsFromExercise(exercise);
        }

        public Set ToggleSelectedSetVisibility(Set set)
        {
            set.ShowCompletedSets = !set.ShowCompletedSets;
            return set;
        }

        public List<CompletedSet> GetCompletedSetsFromSet(Set set)
        {
            return repository.GetCompletedSetsFromSet(set);
        }
    }
}
