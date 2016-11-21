using fitsense.models;
using FitSense.Constants;
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

namespace test.fitsense
{
    [TestClass]
    class ExercisesViewModelTest
    {
        private IUserDataService userDataService;

        private ExercisesViewModel GetViewModel()
        {
            var viewmodel = new ExercisesViewModel(null, this.userDataService);
            IMessenger messenger = Messenger.Default;
            var category = userDataService.GetAllCategories().FirstOrDefault();
            messenger.Send(category, Messages.CategoryUpdated);
            return viewmodel;
        }

        [TestInitialize]
        public void Init()
        {
            userDataService = new UserDataServiceMock();
        }

        [TestMethod]
        public void ExercisesContainData()
        {
            var viewmodel = GetViewModel();
            Assert.IsNotNull(viewmodel.ExercisesViews);
        }

        [TestMethod]
        public void IsCategorySet()
        {
            var viewmodel = GetViewModel();
            Assert.IsNotNull(viewmodel.Category);
        }
    }
}
