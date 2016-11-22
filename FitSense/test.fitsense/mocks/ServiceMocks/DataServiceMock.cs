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
    class DataServiceMock : IDataService
    {
        public User LoggedInUser { get; set; }

        public List<Category> Categories { get; set; }
        public List<Exercise> Exercises { get; set; }
        public List<Set> Sets { get; set; }
        public List<SetViewModel> SetViewModels { get; set; }

        public DataServiceMock()
        {
            Categories = new List<Category>()
            {
                new Category()
                {
                    Name = "Arms"
                }
            };
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await Task.Run(() => Categories);
        }

        public Task<List<Exercise>> GetExercisesFromCategoryAsync(Category category)
        {
            return new Task<List<Exercise>>(() => Exercises);
        }

        public Task<List<Set>> GetSetsFromExerciseAsync(Exercise exercise)
        {
            return new Task<List<Set>>(() => Sets);
        }

        public Task<List<SetViewModel>> GetSetViewModelsFromExerciseAsync(Exercise exercise, INavigationService navigationService)
        {
            return new Task<List<SetViewModel>>(() => SetViewModels);
        }

        public Task LoginAsync(string userName, string password)
        {
            return new Task(() => LoggedInUser = new User { Name = userName, Password = password });
        }

        public User SearchUser(string userName)
        {
            return new User { Name = userName };
        }
    }
}
