using fitsense.models;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_fitsense.mocks;
using uwp_fitsense.dependencies;
using uwp_fitsense.viewmodel;

namespace test_fitsense
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
            fitDataService = new MockFitDataService();
            //dialogService = new MockDialogService();
        }

        [TestMethod]
        public void IsCategoryLoaded()
        {
            var viewModel = GetViewModel();

            Assert.IsNotNull(viewModel.SelectedCategory);
        }

        [TestMethod]
        public void LoadAllExercises()
        {
            var viewModel = GetViewModel();
            //Arrange
            ObservableCollection<Exercise> exercises;
            var expectedExercises = fitDataService.GetExercisesFromCategory(viewModel.SelectedCategory);

            //act
            exercises = viewModel.Exercises;

            viewModel.PropertyChanged += ViewModel_PropertyChanged;

            //assert
            CollectionAssert.AreEqual(expectedExercises, exercises);
        }

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}

