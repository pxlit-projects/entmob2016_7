using fitsense.models;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using test_fitsense.mocks;
using uwp_fitsense.dependencies;
using uwp_fitsense.messages;
using uwp_fitsense.utility;
using uwp_fitsense.viewmodel;

namespace test_fitsense
{
    [TestClass]
    public class CategoriesPageViewModelTest
    {
        private IFitDataService fitDataService;

        private CategoriesPageViewModel GetViewModel()
        {
            var viewmodel = new CategoriesPageViewModel(this.fitDataService, null);
            return viewmodel;
        }

        [TestInitialize]
        public void Init()
        {
            fitDataService = new MockFitDataService();
        }

        [TestMethod]
        public void LoadAllCategories()
        {
            //Arrange
            ObservableCollection<Category> categories;
            var expectedCategories = fitDataService.GetAllCategoriesAsync().Result;

            //act
            var viewModel = GetViewModel();
            categories = viewModel.Categories;

            //assert
            CollectionAssert.AreEqual(expectedCategories, categories);
        }

        [TestMethod]
        public void IsSwitchPageCommandSet()
        {
            var viewmodel = GetViewModel();
            Assert.IsNotNull(viewmodel.SwitchPageCommand);
        }

        [TestMethod]
        public void IsAddCategoryCommandSet()
        {
            var viewmodel = GetViewModel();
            Assert.IsNotNull(viewmodel.AddCategoryCommand);
        }

        [TestMethod]
        public void IsCurrentPageMessageChangedReceived()
        {
            var viewmodel = GetViewModel();

            var initialValue = viewmodel.CurrentPage;
            var expectedType = typeof(MockViewModel);

            //send over a message
            Messenger.Default.Send<ChangePage>(new ChangePage() { Page = expectedType });

            Assert.AreEqual(expectedType, viewmodel.CurrentPage);
        }

        [TestMethod]
        public void IsPropertyChangedFired()
        {
            var viewmodel = GetViewModel();
            List<string> receivedEvents = new List<string>();

            viewmodel.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                receivedEvents.Add(e.PropertyName);
            };
            viewmodel.Categories = new ObservableCollection<Category>();
            viewmodel.CurrentPage = null;
            viewmodel.SelectedCategory = new Category();
            Assert.AreEqual(3, receivedEvents.Count);
            Assert.AreEqual("Categories", receivedEvents[0]);
            Assert.AreEqual("CurrentPage", receivedEvents[1]);
            Assert.AreEqual("SelectedCategory", receivedEvents[2]);
        }
    }
}