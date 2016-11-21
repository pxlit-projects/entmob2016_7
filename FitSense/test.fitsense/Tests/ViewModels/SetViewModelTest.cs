using FitSense.Dependencies;
using FitSense.ViewModels;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.Linq;
using test.fitsense.mocks;

namespace test.fitsense
{
    [TestClass]
    class SetViewModelTest
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
        public void IsCommandLoaded()
        {
            //var viewmodel = GetViewModel();
            var viewmodel = locatorMock.SetViewModel;
            Assert.IsNotNull(viewmodel.StartSet);
        }
    }
}