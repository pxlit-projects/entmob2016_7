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
    public class SetViewModelTest
    {
        //private IUserDataService userDataService;
        private ViewModelLocatorMock locatorMock;

        //private SetViewModel GetViewModel()
        //{
        //    var viewmodel = new SetViewModel(null, this.userDataService);
        //    return viewmodel;
        //}

        [TestInitialize]
        public void Init()
        {
            //userDataService = new UserDataServiceMock();
            locatorMock = new ViewModelLocatorMock();
        }

        [TestMethod]
        public void StartSetCommandTest()
        {
            //var viewmodel = GetViewModel();
            var viewmodel = locatorMock.SetViewModel;
            var navigation = ServiceLocator.Current.GetInstance<INavigationService>() as NavigationServiceMock;

            Assert.IsNotNull(viewmodel.StartSet);

            viewmodel.StartSet.Execute(null);

            Assert.AreEqual(PageUrls.ACTIVESET, navigation.NavigatedTo);
        }
    }
}