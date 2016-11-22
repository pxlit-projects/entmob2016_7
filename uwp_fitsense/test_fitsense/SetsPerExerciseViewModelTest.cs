using fitsense.models;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_fitsense.mocks;
using uwp_fitsense.dependencies;
using uwp_fitsense.messages;
using uwp_fitsense.utility;
using uwp_fitsense.viewmodel;

namespace test_fitsense
{
    [TestClass]
    public class SetsPerExerciseViewModelTest
    {
        private IFitDataService fitDataService;

        private SetsPerExerciseViewModel GetViewModel()
        {
            var viewmodel = new SetsPerExerciseViewModel(this.fitDataService, null);
            var category = fitDataService.GetAllCategoriesAsync().Result.FirstOrDefault();
            var exercise = fitDataService.GetExercisesFromCategoryAsync(category).Result.FirstOrDefault();
            Messenger.Default.Send<SendExercise>(new SendExercise() { Exercise = exercise });
            return viewmodel;
        }

        [TestInitialize]
        public void Init()
        {
            fitDataService = new MockFitDataService();
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
            var expectedSets = fitDataService.GetSetsFromExerciseAsync(viewModel.CurrentExercise).Result;

            //act
            sets = viewModel.Sets;

            //assert
            CollectionAssert.AreEqual(expectedSets, sets);
        }

        [TestMethod]
        public void ChartDataNotNull()
        {
            var viewmodel = GetViewModel();
            viewmodel.Initializing.Wait();
            viewmodel.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                if(e.PropertyName.Equals("Sets"))
                {
                    if (viewmodel.Sets.Count > 0)
                    {
                        viewmodel.SelectedSet = viewmodel.Sets[0];
                        Assert.IsNotNull(viewmodel.ActiveChart);
                    }            
                }
            };       
        }

        [TestMethod]
        public void IsPropertyChangedFired()
        {
            var viewmodel = GetViewModel();
            List<string> receivedEvents = new List<string>();

            viewmodel.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                receivedEvents.Add(e.PropertyName);
            };
            viewmodel.CurrentExercise = new Exercise();
            //viewmodel.Sets = new ObservableCollection<Set>();// -> set when exercise is changed         
            viewmodel.SelectedSet = new Set();
            viewmodel.ActiveChart = new List<ChartRecord>(); //-> set when selected set is changed
            viewmodel.Initializing.Wait();
            Assert.IsTrue(receivedEvents.Contains("CurrentExercise"));
            Assert.IsTrue(receivedEvents.Contains("Sets"));
            Assert.IsTrue(receivedEvents.Contains("SelectedSet"));
            Assert.IsTrue(receivedEvents.Contains("ActiveChart"));
        }
    }
}
