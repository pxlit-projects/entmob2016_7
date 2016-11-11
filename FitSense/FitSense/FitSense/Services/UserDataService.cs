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

namespace FitSense.Services
{
    public class UserDataService : IUserDataService
    {
        private static UserRepository userRepository = new UserRepository();
        //private static DummyRepository dummyRepository = new Dumm
        private CategoryRepository categoryRepository;
        private ExerciseRepository exerciseRepository;
        private SetRepository setRepository;

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

        public UserDataService(CategoryRepository categoryRepository, ExerciseRepository exerciseRepository, SetRepository setRepository)
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
    }
}
