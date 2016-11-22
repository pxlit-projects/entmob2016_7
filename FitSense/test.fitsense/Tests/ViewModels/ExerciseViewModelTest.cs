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
    class ExerciseViewModelTest
    {
        //private IUserDataService userDataService;
        private ViewModelLocatorMock locatorMock;

        //private ExerciseViewModel GetViewModel()
        //{
        //    var viewmodel = new ExerciseViewModel(null, this.userDataService);
        //    return viewmodel;
        //}

        [TestInitialize]
        public void Init()
        {
            locatorMock = new ViewModelLocatorMock();
            //userDataService = new UserDataServiceMock();
        }

        [TestMethod]
        public void IsGoToCarouselSetTest()
        {
            //var viewmodel = GetViewModel();
            var viewmodel = locatorMock.ExerciseViewModel;
            var navigation = ServiceLocator.Current.GetInstance<INavigationService>() as NavigationServiceMock;

            Assert.IsNotNull(viewmodel.GoToSetCarouselCommand);

            viewmodel.GoToSetCarouselCommand.Execute(null);

            Assert.AreEqual(PageUrls.SETSCAROUSEL, navigation.NavigatedTo);
        }
    }
}