using fitsense.models;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using test_fitsense.mocks;
using uwp_fitsense.dependencies;
using uwp_fitsense.extensions;
using uwp_fitsense.messages;
using uwp_fitsense.utility;
using uwp_fitsense.viewmodel;

namespace test_fitsense
{
    [TestClass]
    public class ExercisesViewModelTest
    {
        private IFitDataService fitDataService;

        private ExercisesViewModel GetViewModel()
        {
            return new ExercisesViewModel(this.fitDataService, null);
        }

        [TestInitialize]
        public void Init()
        {
            fitDataService = new MockFitDataService();
        }

        [TestMethod]
        public void IsMessageReceived()
        {
            //arrange
            var viewmodel = GetViewModel();
            var initialValue = viewmodel.SelectedCategory;
            var expectedCategory = new Category() { Name = "TestCategory" };

            //act
            Messenger.Default.Send<UpdateSelectedCategory>(new UpdateSelectedCategory() { Category = expectedCategory});

            //assert
            Assert.AreEqual(expectedCategory, viewmodel.SelectedCategory);
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
            viewmodel.SelectedCategory = new Category();
            viewmodel.Exercises = new ObservableCollection<Exercise>();
            viewmodel.SelectedExercise = new Exercise();
            viewmodel.ActiveChart = new List<ChartRecord>();
            Assert.AreEqual(1, receivedEvents.Count);
            Assert.AreEqual("SelectedCategory", receivedEvents[0]);
            Assert.AreEqual("Exercises", receivedEvents[1]);
            Assert.AreEqual("SelectedExercise", receivedEvents[2]);
            Assert.AreEqual("ActiveChart", receivedEvents[3]);
        }

        [TestMethod]
        public void LoadAllExercises()
        {
            var viewModel = GetViewModel();
            //Arrange
            ObservableCollection<Exercise> exercises;
            var expectedExercises = fitDataService.GetExercisesFromCategoryAsync(viewModel.SelectedCategory).Result;

            //act
            exercises = viewModel.Exercises;

            //assert
            CollectionAssert.AreEqual(expectedExercises, exercises);
        }

        [TestMethod]
        public void AreCommandsSet()
        {
            var viewmodel = GetViewModel();
            Assert.IsNotNull(viewmodel.GoToSetPerExercisePageCommand);
            Assert.IsNotNull(viewmodel.ActivateChartCommand);
        }
    }
}

