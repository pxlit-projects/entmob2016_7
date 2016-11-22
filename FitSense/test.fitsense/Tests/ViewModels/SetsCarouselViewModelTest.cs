using fitsense.DAL.dependencies;
using fitsense.models;
using FitSense.Constants;
using FitSense.Dependencies;
using FitSense.ViewModels;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.ServiceLocation;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.Collections.Generic;
using System.Linq;
using test.fitsense.mocks;
using test.fitsense.mocks.Repository;

namespace test.fitsense
{
    [TestClass]
    public class SetsCarouselViewModelTest
    {
        private ViewModelLocatorMock locatorMock;

        //private async void sendMessage()
        //{
        //    var userDataService = ServiceLocator.Current.GetInstance<IDataService>();
        //    var categories = await userDataService.GetAllCategoriesAsync();
        //    var category = categories.FirstOrDefault();
        //    var exercise = userDataService.GetExercisesFromCategoryAsync(category);
        //}

        [TestInitialize]
        public void Init()
        {
            locatorMock = new ViewModelLocatorMock();
            //userDataService = new UserDataServiceMock();
        }

        [TestMethod]
        public void IsMessageReceived()
        {
            locatorMock.replaceDataServiceMock();

            Set set = new Set() { ExerciseID = 1, SetID = 1 };
            Exercise exercise = new Exercise() { ExerciseID = 1 };
            var exerciseRepository = ServiceLocator.Current.GetInstance<IExerciseRepository>() as ExerciseRepositoryMock;
            var setRepository = ServiceLocator.Current.GetInstance<ISetRepository>() as SetRepositoryMock;
            exerciseRepository.Exercises = new List<Exercise>() { exercise };
            setRepository.Sets = new List<Set>() { set };

            var viewmodel = locatorMock.SetsCarouselViewModel;
            //sendMessage();

            IMessenger messenger = Messenger.Default;
            messenger.Send(exercise, Messages.ExerciseUpdated);


            viewmodel.Initialization.Wait();
            Assert.IsNotNull(viewmodel.Exercise);
        }

        [TestMethod]
        public void IsDataNotNull()
        {
            locatorMock.replaceDataServiceMock();

            Set set = new Set() { ExerciseID = 1, SetID = 1 };
            Exercise exercise = new Exercise() { ExerciseID = 1 };
            var exerciseRepository = ServiceLocator.Current.GetInstance<IExerciseRepository>() as ExerciseRepositoryMock;
            var setRepository = ServiceLocator.Current.GetInstance<ISetRepository>() as SetRepositoryMock;
            exerciseRepository.Exercises = new List<Exercise>() { exercise };
            setRepository.Sets = new List<Set>() { set };

            var viewmodel = locatorMock.SetsCarouselViewModel;
            //sendMessage();

            IMessenger messenger = Messenger.Default;
            messenger.Send(exercise, Messages.ExerciseUpdated);


            viewmodel.Initialization.Wait();

            Assert.IsNotNull(viewmodel.SetViews);
        }
    }
}