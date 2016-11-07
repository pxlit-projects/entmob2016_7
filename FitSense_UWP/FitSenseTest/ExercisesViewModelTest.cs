using Fitsense.Models;
using FitSense_UWP.Services;
using FitSense_UWP.ViewModel;
using FitSenseTest.mocks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSenseTest
{
    [TestClass]
    public class ExercisesViewModelTest
    {
        private IFitDataService fitDataService;
        private INavigationService navigationService;

        private ExercisesViewModel GetViewModel()
        {
            return new ExercisesViewModel(this.fitDataService, this.navigationService);
        }

        [TestInitialize]
        public void Init()
        {
            fitDataService = new FitDataServiceMock();
            //dialogService = new MockDialogService();
        }

        [TestMethod]
        public void IsCategoryLoaded()
        {
            var viewModel = GetViewModel();

            Assert.IsNotNull(viewModel.SelectedCategory);
        }

        [TestMethod]
        public void LoadAllCategories()
        {
            var viewModel = GetViewModel();
            //Arrange
            ObservableCollection<Exercise> exercises;
            var expectedExercises = fitDataService.GetExercisesFromCategory(viewModel.SelectedCategory);

            //act
            exercises = viewModel.Exercises;

            //assert
            CollectionAssert.AreEqual(expectedExercises, exercises);
        }
    }
}

