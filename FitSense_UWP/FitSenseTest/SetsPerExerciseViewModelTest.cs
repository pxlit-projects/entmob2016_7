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
    public class SetsPerExerciseViewModelTest
    {
        private IFitDataService fitDataService;
        private INavigationService navigationService;

        private SetsPerExerciseViewModel GetViewModel()
        {
            return new SetsPerExerciseViewModel(this.fitDataService, this.navigationService);
        }

        [TestInitialize]
        public void Init()
        {
            fitDataService = new MockFitDataService();
            navigationService = new MockNavigationService();
        }

        [TestMethod]
        public void IsExerciseLoaded()
        {
            var viewModel = GetViewModel();

            Assert.IsNotNull(viewModel.CurrentExercise);
        }

        [TestMethod]
        public void LoadAllSets()
        {
            var viewModel = GetViewModel();
            //Arrange
            ObservableCollection<Set> sets;
            var expectedSets = fitDataService.GetSetsFromExercise(viewModel.CurrentExercise);

            //act
            sets = viewModel.Sets;

            //assert
            CollectionAssert.AreEqual(expectedSets, sets);
        }
    }
}

