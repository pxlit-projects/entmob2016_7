using fitsense.models;
using FitSense.Constants;
using FitSense.Dependencies;
using FitSense.ViewModels;
using Microsoft.Practices.ServiceLocation;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using test.fitsense.mocks;
using test.fitsense.mocks.ServiceMocks;

namespace test.fitsense
{
    [TestClass]
    public class CategoriesViewModelTest
    {
        private ViewModelLocatorMock locatorMock;
        
        [TestInitialize]
        public void Init()
        {
            locatorMock = new ViewModelLocatorMock();
            //userDataService = new UserDataServiceMock();
        }

        [TestMethod]
        public void AreCategoriesLoadedTest()
        {
            //var viewModel = GetViewModel();
            var categories = new List<Category>() { new Category() { Name = "Arms" } };
            var dataService = ServiceLocator.Current.GetInstance<IDataService>() as DataServiceMock;
            dataService.Categories = categories;


            var viewModel = locatorMock.CategoriesViewModel;
            viewModel.Initialization.Wait();
            
            Assert.AreEqual(categories[0].Name, viewModel.Categories[0].Name);
        }

        [TestMethod]
        public void NavigationToExerciseTest()
        {
            var viewmodel = locatorMock.CategoriesViewModel;
            var navigation = ServiceLocator.Current.GetInstance<INavigationService>() as NavigationServiceMock;

            Assert.IsNotNull(viewmodel.CategorySelectedCommand);

            viewmodel.CategorySelectedCommand.Execute(new Category());

            Assert.AreEqual(PageUrls.EXERCISESVIEW, navigation.NavigatedTo);
        }
    }
}
