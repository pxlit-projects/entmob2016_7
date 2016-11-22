using fitsense.DAL.dependencies;
using fitsense.models;
using FitSense.Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.fitsense.dal.mocks;
using FitSense.ViewModels;

namespace test.fitsense.mocks
{
    //class UserDataServiceMockOld : IDataService
    //{
        //private static UserRepositoryMock userRepository = new UserRepositoryMock();
        //private ICategoryRepository categoryRepository = new MockCategoryRepository();
        //private IExerciseRepository exerciseRepository = new MockExerciseRepository();
        //private ISetRepository setRepository = new MockSetRepository();
        //public User LoggedInUser { get; set; }

        ////User IUserDataService.LoggedInUser
        ////{
        ////    get
        ////    {
        ////        return userRepository.SearchUser("Daniël");
        ////    }
        ////    set { }
        ////}

        //public Task LoginAsync(string userName, string password)
        //{
        //    return Task.Factory.StartNew(() =>
        //    {
        //        LoggedInUser = new User { Name = userName };
        //    });
        //}

        //public User SearchUser(string userName)
        //{
        //    return userRepository.SearchUser(userName);
        //}

        //User IDataService.SearchUser(string userName)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<List<Category>> GetAllCategories()
        //{
        //    var categories = await categoryRepository.GetCategoriesAsync();
        //    return categories.ToList();
        //}

        //public async Task<List<Exercise>> GetExercisesFromCategory(Category category)
        //{
        //    var exercises = await exerciseRepository.GetExercisesFromCategoryAsync(category);
        //}

        //public async Task<List<Set>> GetSetsFromExercise(Exercise exercise)
        //{
        //    return await setRepository.GetSetsFromExerciseAsync(exercise);
        //}

        //public List<SetViewModel> GetSetViewModelsFromExercise(Exercise exercise, INavigationService navigationService)
        //{
        //    var setViews = new List<SetViewModel>();
        //    if (exercise != null)
        //    {
        //        List<Set> sets = GetSetsFromExercise(exercise);
        //        foreach (Set set in sets)
        //        {
        //            setViews.Add(new SetViewModel(navigationService, this)
        //            {
        //                Exercise = exercise,
        //                Set = set
        //            });
        //        }
        //    }
        //    return setViews;
        //}

        //public Task<List<SetViewModel>> GetSetViewModelsFromExerciseAsync(Exercise exercise, INavigationService navigationService)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<List<Category>> GetAllCategoriesAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<List<Exercise>> GetExercisesFromCategoryAsync(Category category)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<List<Set>> GetSetsFromExerciseAsync(Exercise exercise)
        //{
        //    throw new NotImplementedException();
        //}
    //}
}
