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
        private ViewModelLocatorMock locatorMock;

        [TestInitialize]
        public void Init()
        {
            locatorMock = new ViewModelLocatorMock();
            //DependencyService.Register<IConnectivity>();

            //DependencyService.Register<IConnectivity, ConnectivityMock>();
        }

        [TestMethod]
        public void CanLoginTest()
        {
            LoginViewModel vm = locatorMock.Login;
            Assert.IsFalse(vm.CanLogin);
            Assert.AreEqual<string>("Please enter a username." + "Please enter a password.", vm.ValidationErrors);

            vm.Username = "someone";
            Assert.IsFalse(vm.CanLogin);
            Assert.AreEqual<string>("Please enter a password.", vm.ValidationErrors);

            vm.Password = "password";
            Assert.IsTrue(vm.CanLogin);
            Assert.AreEqual<string>(string.Empty, vm.ValidationErrors);
        }
        
    }
}
