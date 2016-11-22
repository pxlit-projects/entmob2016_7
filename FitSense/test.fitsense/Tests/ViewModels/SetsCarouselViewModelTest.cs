using FitSense.Constants;
using FitSense.Dependencies;
using FitSense.ViewModels;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.ServiceLocation;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.Linq;
using test.fitsense.mocks;

namespace test.fitsense
{
    [TestClass]
    public class SetsCarouselViewModelTest
    {
        private ViewModelLocatorMock locatorMock;

        private async void sendMessage()
        {
            IMessenger messenger = Messenger.Default;
            var userDataService = ServiceLocator.Current.GetInstance<IDataService>();
            var categories = await userDataService.GetAllCategoriesAsync();
            var category = categories.FirstOrDefault();
            var exercise = userDataService.GetExercisesFromCategoryAsync(category);
            messenger.Send(exercise, Messages.ExerciseUpdated);
        }

        [TestInitialize]
        public void Init()
        {
            locatorMock = new ViewModelLocatorMock();
            //userDataService = new UserDataServiceMock();
        }

        [TestMethod]
        public void IsMessageReceived()
        {
            //var viewmodel = GetViewModel();
            var viewmodel = locatorMock.SetsCarouselViewModel;
            sendMessage();
            Assert.IsNotNull(viewmodel.Exercise);
        }

        [TestMethod]
        public void IsDataNotNull()
        {
            //var viewmodel = GetViewModel();
            var viewmodel = locatorMock.SetsCarouselViewModel;
            sendMessage();
            Assert.IsNotNull(viewmodel.SetViews);
        }
    }
}