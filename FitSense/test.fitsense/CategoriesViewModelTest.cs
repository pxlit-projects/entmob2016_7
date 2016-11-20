using fitsense.models;
using FitSense.Dependencies;
using FitSense.ViewModels;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.ObjectModel;
using test.fitsense.mocks;

namespace test.fitsense
{
    [TestClass]
    public class CategoriesViewModelTest
    {
        private IUserDataService userDataService;

        private CategoriesViewModel GetViewModel()
        {
            var viewmodel = new CategoriesViewModel(null, this.userDataService);
            return viewmodel;
        }

        [TestInitialize]
        public void Init()
        {
            userDataService = new UserDataServiceMock();
        }

        [TestMethod]
        public void AreCategoriesLoaded()
        {
            var viewModel = GetViewModel();
            ObservableCollection<Category> categories;
            var expectedCategories = userDataService.GetAllCategories();

            //act
            categories = viewModel.Categories;

            //assert
            CollectionAssert.AreEqual(expectedCategories, categories);
        }
    }
}
