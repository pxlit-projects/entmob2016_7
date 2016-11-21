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
        private IUserDataService userDataService;

        private SetViewModel GetViewModel()
        {
            var viewmodel = new SetViewModel(null, this.userDataService);
            return viewmodel;
        }

        [TestInitialize]
        public void Init()
        {
            userDataService = new UserDataServiceMock();
        }

        [TestMethod]
        public void IsCommandLoaded()
        {
            var viewmodel = GetViewModel();
            Assert.IsNotNull(viewmodel.StartSet);
        }
    }
}