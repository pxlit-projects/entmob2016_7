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
    public class SetsPerExerciseViewModelTest
    {
        private IFitDataService fitDataService;
        private INavigationService navigationService;

        private SetsPerExerciseViewModel GetViewModel()
        {
            var category = fitDataService.GetAllCategories().ToList().FirstOrDefault();
            var exercise = fitDataService.GetExercisesFromCategory(category).FirstOrDefault();
            var viewmodel = new SetsPerExerciseViewModel(this.fitDataService, this.navigationService)
            {
                CurrentExercise = exercise
            };
            viewmodel.LoadData();
            return viewmodel;
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

        [TestMethod]
        public void ChartDataNotNull()
        {
            // force a selected set change => triggers chart update
            var viewmodel = GetViewModel();
            if (viewmodel.Sets.Count > 0)
                viewmodel.SelectedSet = viewmodel.Sets[0];
            Assert.IsNotNull(viewmodel.ActiveChart);        
        }
    }
}
