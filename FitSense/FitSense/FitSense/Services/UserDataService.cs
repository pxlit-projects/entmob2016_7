using FitSense.Dependencies;
using FitSense.Models;
using FitSense.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fitsense.models;
using fitsense.DAL;
using fitsense.DAL.dependencies;
using FitSense.ViewModels;

namespace FitSense.Services
{
    public class UserDataService : IUserDataService
    {
        private static UserRepository userRepository = new UserRepository();
        private ICategoryRepository categoryRepository;
        private IExerciseRepository exerciseRepository;
        private ISetRepository setRepository;

        public User LoggedInUser { get; set; }

        User IUserDataService.LoggedInUser
        {
            get
            {
                return userRepository.SearchUser("Daniël");
            }

            set
            {
                
            }
        }

        public UserDataService(ICategoryRepository categoryRepository, IExerciseRepository exerciseRepository, ISetRepository setRepository)
        {
            this.categoryRepository = categoryRepository;
            this.exerciseRepository = exerciseRepository;
            this.setRepository = setRepository;
        }

        public Task LoginAsync(string userName, string password)
        {
            return Task.Factory.StartNew(() =>
            {
                LoggedInUser = new User { Name = userName };
            });
        }

        public User SearchUser(string userName)
        {
            return userRepository.SearchUser(userName);
        }

        User IUserDataService.SearchUser(string userName)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAllCategories()
        {
            return categoryRepository.GetCategories().ToList();
        }

        public List<Exercise> GetExercisesFromCategory(Category category)
        {
            return exerciseRepository.GetExercisesFromCategory(category);
        }

        public List<Set> GetSetsFromExercise(Exercise exercise)
        {
            return setRepository.GetSetsFromExercise(exercise);
        }

        public List<SetViewModel> GetSetViewModelsFromExercise(Exercise exercise, INavigationService navigationService)
        {
            var setViews = new List<SetViewModel>();
            if (exercise != null)
            {
                List<Set> sets = GetSetsFromExercise(exercise);
                foreach (Set set in sets)
                {
                    setViews.Add(new SetViewModel(navigationService, this)
                    {
                        Exercise = exercise,
                        Set = set
                    });
                }
            }
            return setViews;
        }
    }
}
