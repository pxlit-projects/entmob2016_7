using FitSense.Dependencies;
using FitSense.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fitsense.models;
using fitsense.DAL;
using fitsense.DAL.dependencies;
using FitSense.ViewModels;
using fitsense.DAL.Constants;

namespace FitSense.Services
{
    public class DataService : IDataService
    {
        //private static UserRepository userRepository = new UserRepository();
        private IUserRepository userRepository;
        private ICategoryRepository categoryRepository;
        private IExerciseRepository exerciseRepository;
        private ISetRepository setRepository;

        public User LoggedInUser { get; set; }

        //User IUserDataService.LoggedInUser
        //{
        //    get
        //    {
        //        return userRepository.SearchUser("Daniël");
        //    }

        //    set
        //    {
                
        //    }
        //}

        public DataService(IUserRepository userRepository, ICategoryRepository categoryRepository, IExerciseRepository exerciseRepository, ISetRepository setRepository)
        {
            this.userRepository = userRepository;
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
        
        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            var result = await categoryRepository.GetCategoriesAsync(ApiUrl.BASEURL);
            return result.ToList();
        }

        public async Task<List<Exercise>> GetExercisesFromCategoryAsync(Category category)
        {
            return await exerciseRepository.GetExercisesFromCategoryAsync(category, ApiUrl.BASEURL);
        }

        public async Task<List<Set>> GetSetsFromExerciseAsync(Exercise exercise)
        {
            return await setRepository.GetSetsFromExerciseAsync(exercise, ApiUrl.BASEURL);
        }

        public async Task<List<SetViewModel>> GetSetViewModelsFromExerciseAsync(Exercise exercise, INavigationService navigationService)
        {
            var setViews = new List<SetViewModel>();
            if (exercise != null)
            {
               
                List<Set> sets = await setRepository.GetSetsFromExerciseAsync(exercise, ApiUrl.BASEURL);
                //List<Set> sets = GetSetsFromExercise(exercise);
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
