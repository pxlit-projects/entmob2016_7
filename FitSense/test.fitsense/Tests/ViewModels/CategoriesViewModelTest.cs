using fitsense.models;
using FitSense.Dependencies;
using FitSense.ViewModels;
using Microsoft.Practices.ServiceLocation;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using test.fitsense.mocks;

namespace test.fitsense
{
    [TestClass]
    public class CategoriesViewModelTest
    {
        private ViewModelLocatorMock locatorMock;
        //private IUserDataService userDataService;

        //private CategoriesViewModel GetViewModel()
        //{
        //    var viewmodel = new CategoriesViewModel(null, this.userDataService);
        //    return viewmodel;
        //}

        [TestInitialize]
        public void Init()
        {
            locatorMock = new ViewModelLocatorMock();
            //userDataService = new UserDataServiceMock();
        }

        [TestMethod]
        public async void AreCategoriesLoaded()
        {
            //var viewModel = GetViewModel();
            var viewModel = locatorMock.CategoriesViewModel;
            ObservableCollection<Category> categories;
            var expectedCategories = await ServiceLocator.Current.GetInstance<IUserDataService>().GetAllCategoriesAsync();

            //act
            categories = viewModel.Categories;

            //assert
            CollectionAssert.AreEqual(expectedCategories, categories);
        }
    }
}
