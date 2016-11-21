using FitSense.Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fitsense.models;
using FitSense.ViewModels;

namespace test.fitsense.mocks.ServiceMocks
{
    class UserDataServiceMock : IUserDataService
    {
        public User LoggedInUser { get; set; }

        public List<Category> Categories { get; set; }
        public List<Exercise> Exercises { get; set; }

        public Task<List<Category>> GetAllCategoriesAsync()
        {
            return new Task<List<Category>>(() => Categories);
        }

        public Task<List<Exercise>> GetExercisesFromCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<List<Set>> GetSetsFromExerciseAsync(Exercise exercise)
        {
            throw new NotImplementedException();
        }

        public Task<List<SetViewModel>> GetSetViewModelsFromExerciseAsync(Exercise exercise, INavigationService navigationService)
        {
            throw new NotImplementedException();
        }

        public Task LoginAsync(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public User SearchUser(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
