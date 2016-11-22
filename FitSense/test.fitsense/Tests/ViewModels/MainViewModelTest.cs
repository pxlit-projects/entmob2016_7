using FitSense.Constants;
using FitSense.Dependencies;
using Microsoft.Practices.ServiceLocation;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.fitsense.mocks;

namespace test.fitsense
{
    [TestClass]
    public class MainViewModelTest
    {
        private ViewModelLocatorMock locatorMock;

        [TestInitialize]
        public void init()
        {
            locatorMock = new ViewModelLocatorMock();
        }

        [TestMethod]
        public void ConnectCommandTest()
        {
            var viewmodel = locatorMock.Main;
            var navMock = ServiceLocator.Current.GetInstance<INavigationService>() as NavigationServiceMock;

            viewmodel.ConnectCommand.Execute(null);
            Assert.AreEqual(PageUrls.SENSORCONNECTVIEW, navMock.NavigatedTo);
        }

        [TestMethod]
        public void CategoriesCommandTest()
        {
            var viewmodel = locatorMock.Main;
            var navMock = ServiceLocator.Current.GetInstance<INavigationService>() as NavigationServiceMock;

            viewmodel.GoToCategoriesCommand.Execute(null);
            Assert.AreEqual(PageUrls.CATEGORIESVIEW, navMock.NavigatedTo);
        }


    }
}
