using fitsense.models;
using FitSense.Constants;
using FitSense.Dependencies;
using FitSense.ViewModels;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.ServiceLocation;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.fitsense.mocks;
using test.fitsense.mocks.ServiceMocks;

namespace test.fitsense
{
    [TestClass]
    public class ExercisesViewModelTest
    {
        private ViewModelLocatorMock locatorMock;

        private async void sendMessage()
        {
            Messenger.Reset();
            var categories = await ServiceLocator.Current.GetInstance<IDataService>().GetAllCategoriesAsync();
            IMessenger messenger = Messenger.Default;
            messenger.Send(categories.FirstOrDefault(), Messages.CategoryUpdated);
        }

        [TestInitialize]
        public void Init()
        {
            locatorMock = new ViewModelLocatorMock();
        }

        [TestMethod]
        public void AreExercisesSetTest()
        {
            Category category = new Category() { Name = "Arms" };
            var dataservice = ServiceLocator.Current.GetInstance<IDataService>() as DataServiceMock;
            dataservice.Exercises = new List<Exercise>()
            {
                new Exercise()
                {
                    Name = "something", Category = category
                }
            };
            dataservice.Categories = new List<Category>() { category };
            var viewmodel = locatorMock.ExercisesViewModel;
            sendMessage();
            Assert.IsNotNull(viewmodel.ExercisesViews);
        }

        [TestMethod]
        public void IsCategorySetTest()
        {
            Messenger.Reset();
            Category category = new Category { Name = "Arms" };

            var viewmodel = locatorMock.ExercisesViewModel;
            //viewmodel.Initialization.Wait();

            IMessenger messenger = Messenger.Default;
            messenger.Send(category, Messages.CategoryUpdated);

            Assert.IsNotNull(viewmodel.Category);
            Assert.AreEqual(category.Name, viewmodel.Category.Name);

        }
    }
}
