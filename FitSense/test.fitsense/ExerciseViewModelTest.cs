using FitSense.Constants;
using FitSense.Dependencies;
using FitSense.ViewModels;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.Linq;
using test.fitsense.mocks;

namespace test.fitsense
{
    [TestClass]
    class ExerciseViewModelTest
    {
        private IUserDataService userDataService;

        private ExerciseViewModel GetViewModel()
        {
            var viewmodel = new ExerciseViewModel(null, this.userDataService);
            return viewmodel;
        }

        [TestInitialize]
        public void Init()
        {
            userDataService = new UserDataServiceMock();
        }

        [TestMethod]
        public void IsGoToCarouselSet()
        {
            var viewmodel = GetViewModel();
            Assert.IsNotNull(viewmodel.GoToSetCarouselCommand);
        }
    }
}