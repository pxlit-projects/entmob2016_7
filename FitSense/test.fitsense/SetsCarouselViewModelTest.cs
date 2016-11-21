using FitSense.Constants;
using FitSense.Dependencies;
using FitSense.ViewModels;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.fitsense.mocks;

namespace test.fitsense
{
    class SetsCarouselViewModelTest
    {
        private IUserDataService userDataService;

        private SetsCarouselViewModel GetViewModel()
        {
            var viewmodel = new SetsCarouselViewModel(null, this.userDataService);
            IMessenger messenger = Messenger.Default;
            var category = userDataService.GetAllCategories().FirstOrDefault();
            var exercise = userDataService.GetExercisesFromCategory(category);
            messenger.Send(exercise, Messages.ExerciseUpdated);
            return viewmodel;
        }

        [TestInitialize]
        public void Init()
        {
            userDataService = new UserDataServiceMock();
        }

        [TestMethod]
        public void IsMessageReceived()
        {
            var viewmodel = GetViewModel();
            Assert.IsNotNull(viewmodel.Exercise);
        }

        [TestMethod]
        public void IsDataLoaded()
        {
            var viewmodel = GetViewModel();
            Assert.IsNotNull(viewmodel.SetViews);
        }
    }
}