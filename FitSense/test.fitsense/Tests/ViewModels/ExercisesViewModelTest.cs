using fitsense.DAL.dependencies;
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
using test.fitsense.mocks.Repository;
using test.fitsense.mocks.ServiceMocks;

namespace test.fitsense
{
    [TestClass]
    public class ExercisesViewModelTest
    {
        private ViewModelLocatorMock locatorMock;

       [TestInitialize]
        public void Init()
        {
            locatorMock = new ViewModelLocatorMock();
        }

        [TestMethod]
        public void AreExercisesSetTest()
        {
            Category category = new Category() { Name = "Arms" };

            //var dataservice = ServiceLocator.Current.GetInstance<IDataService>() as DataServiceMock;
            var exercise = new Exercise(){ Name = "something", Category = category };
            
            //dataservice.Categories = new List<Category>() { category };
            var categoryRepository = ServiceLocator.Current.GetInstance<ICategoryRepository>() as CategoryRepositoryMock;
            var exerciseRepository = ServiceLocator.Current.GetInstance<IExerciseRepository>() as ExerciseRepositoryMock;
            categoryRepository.Categories = new List<Category>() { category };
            exerciseRepository.Exercises = new List<Exercise>() { exercise };

            var viewmodel = locatorMock.ExercisesViewModel;

            IMessenger messenger = Messenger.Default;
            messenger.Send(category, Messages.CategoryUpdated);

            Assert.IsNotNull(viewmodel.ExercisesViews);
        }

        [TestMethod]
        public void IsCategorySetTest()
        {
            Messenger.Reset();
            Category category = new Category { Name = "Arms", CategoryID = 1 };
            Exercise exercise = new Exercise { CategoryID = 1, Name = "lift" };
            var categoryRepository = ServiceLocator.Current.GetInstance<ICategoryRepository>() as CategoryRepositoryMock;
            var exerciseRepository = ServiceLocator.Current.GetInstance<IExerciseRepository>() as ExerciseRepositoryMock;
            categoryRepository.Categories = new List<Category>() { category };
            exerciseRepository.Exercises = new List<Exercise>() { exercise };

            var viewmodel = locatorMock.ExercisesViewModel;
            //viewmodel.Initialization.Wait();

            IMessenger messenger = Messenger.Default;
            messenger.Send(category, Messages.CategoryUpdated);

            Assert.IsNotNull(viewmodel.Category);
            Assert.AreEqual(category.Name, viewmodel.Category.Name);

        }
    }
}
