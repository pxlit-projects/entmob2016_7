using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_fitsense.mocks;
using uwp_fitsense.dependencies;
using uwp_fitsense.viewmodel;

namespace test_fitsense
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
