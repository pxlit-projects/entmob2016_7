using FitSense_UWP.Services;
using FitSense_UWP.ViewModel;
using FitSenseTest.mocks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSenseTest
{
    [TestClass]
    public class LoginViewModelTest
    {
        INavigationService navigationService;
        private LoginViewModel GetViewModel()
        {
            return new LoginViewModel(this.navigationService);
        }

        [TestInitialize]
        public void Init()
        {
            navigationService = new MockNavigationService();
        }

        [TestMethod]
        public void IsLoginCommandLoaded()
        {
            var viewModel = GetViewModel();

            Assert.IsNotNull(viewModel.LoginCommand);
        }
    }
}
