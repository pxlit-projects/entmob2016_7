using fitsense.models;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using test_fitsense.mocks;
using uwp_fitsense.dependencies;
using uwp_fitsense.extensions;
using uwp_fitsense.viewmodel;

namespace test_fitsense
{
    [TestClass]
    public class ExercisesViewModelTest
    {
        private IFitDataService fitDataService;
        private INavigationService navigationService;

        private async Task<ExercisesViewModel> GetViewModelAsync()
        {
            var result = await fitDataService.GetAllCategoriesAsync();
            var viewmodel = new ExercisesViewModel(this.fitDataService, this.navigationService)
            {
                // simulate messaging service by setting the category
                SelectedCategory = result.ToArray()[0]
            };
            // because the data isn't loaded (due to the way it loads the constructor first)
            //we have to reload the data
            await viewmodel.LoadDataAsync();
            return viewmodel;
        }

        [TestInitialize]
        public void Init()
        {
            fitDataService = new MockFitDataService();
            //dialogService = new MockDialogService();
        }

        // messaging during testing?
        /*[TestMethod]
        public void IsCategoryLoaded()
        {
            var viewModel = GetViewModel();

            Assert.IsNotNull(viewModel.SelectedCategory);
        }*/

        [TestMethod]
        public void LoadAllExercises()
        {
            var viewModel = GetViewModelAsync().Result;
            //Arrange
            ObservableCollection<Exercise> exercises;
            var expectedExercises = fitDataService.GetExercisesFromCategoryAsync(viewModel.SelectedCategory).Result;

            //act
            exercises = viewModel.Exercises;

            //assert
            CollectionAssert.AreEqual(expectedExercises, exercises);
        }
    }
}

