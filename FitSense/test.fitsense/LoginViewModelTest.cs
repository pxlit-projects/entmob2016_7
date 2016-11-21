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
using Xamarin.Forms;

namespace test.fitsense
{
    [TestClass]
    public class LoginViewModelTest
    {
        private IUserDataService userDataService;
        private INavigationService navigationService;

        
        [TestInitialize]
        public void Init()
        {
            
            userDataService = new UserDataServiceMock();
            navigationService = new NavigationServiceMock();
            //DependencyService.Register<IConnectivity>();

            DependencyService.Register<IConnectivity, ConnectivityMock>();
        }

        [TestMethod]
        public void CanLoginTest()
        {
            LoginViewModel vm = new LoginViewModel(navigationService, userDataService);
            Assert.IsFalse(vm.CanLogin);

            vm.Username = "someone";
            Assert.IsFalse(vm.CanLogin);

            vm.Password = "password";
            Assert.IsTrue(vm.CanLogin);
        }

        [TestMethod]
        public void LoginTest()
        {
            LoginViewModel vm = new LoginViewModel(navigationService, userDataService);
            vm.Username = "someone";
            vm.Password = "password";

            

            IMessenger messenger = Messenger.Default;
            messenger.Register<LoginViewModel>(this, FitSense.Constants.Messages.LoginSucces, (sender) =>
            {
                Assert.IsTrue(true);
            });

            vm.LoginCommand.Execute(null);
        }













    }
}
