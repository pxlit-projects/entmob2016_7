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

namespace test.fitsense
{
    [TestClass]
    public class ExercisesViewModelTest
    {
        //private IUserDataService userDataService;
        private ViewModelLocatorMock locatorMock;

        //private ExercisesViewModel GetViewModel()
        //{
        //    var viewmodel = new ExercisesViewModel(null, this.userDataService);
        //    IMessenger messenger = Messenger.Default;
        //    var category = userDataService.GetAllCategories().FirstOrDefault();
        //    messenger.Send(category, Messages.CategoryUpdated);
        //    return viewmodel;
        //}

        private void sendMessage()
        {
            IMessenger messenger = Messenger.Default;
            var category = ServiceLocator.Current.GetInstance<IDataService>().GetAllCategories().FirstOrDefault();
            messenger.Send(category, Messages.CategoryUpdated);
        }

        [TestInitialize]
        public void Init()
        {
            locatorMock = new ViewModelLocatorMock();
            //userDataService = new UserDataServiceMock();
        }

        [TestMethod]
        public void AreExercisesSet()
        {
            //var viewmodel = GetViewModel();
            var viewmodel = locatorMock.ExercisesViewModel;
            sendMessage();
            Assert.IsNotNull(viewmodel.ExercisesViews);
        }

        [TestMethod]
        public void IsCategorySet()
        {
            //var viewmodel = GetViewModel();
            var viewmodel = locatorMock.ExercisesViewModel;
            sendMessage();
            Assert.IsNotNull(viewmodel.Category);
        }
    }
}
