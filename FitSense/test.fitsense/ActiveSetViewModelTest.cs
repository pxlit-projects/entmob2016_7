using fitsense.models;
using FitSense.Constants;
using FitSense.Dependencies;
using FitSense.ViewModels;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using test.fitsense.mocks;

namespace test.fitsense
{
    [TestClass]
    public class ActiveSetViewModelTest
    {
        private IUserDataService userDataService;

        private ActiveSetViewModel GetViewModel()
        {
            var viewmodel = new ActiveSetViewModel(null, this.userDataService);
            // Send over a set
            // for the test we use a self made Set so we know for sure the values that will be inserted
            Set sendingSet = new Set() { SetID = 0, MaxTime = 10, Reps = 20 };
            IMessenger messenger = Messenger.Default;
            messenger.Send(sendingSet, Messages.SetUpdated);
            return viewmodel;
        }

        [TestInitialize]
        public void Init()
        {
            userDataService = new UserDataServiceMock();
        }

        [TestMethod]
        public void DataLoaded()
        {
            var viewmodel = GetViewModel();
            Assert.AreEqual(10, viewmodel.TimeLeft);
            Assert.AreEqual(20, viewmodel.RepsLeft);
        }

        [TestMethod]
        public void IsCancelSetLoaded()
        {
            var viewModel = GetViewModel();
            Assert.IsNotNull(viewModel.CancelSet);
        }

        [TestMethod]
        public void IsStartSetLoaded()
        {
            var viewModel = GetViewModel();
            Assert.IsNotNull(viewModel.StartSet);
        }

        [TestMethod]
        public void CanExecuteStartSet()
        {
            var viewModel = GetViewModel();
            viewModel.StartSet.Execute(null);
        }

        [TestMethod]
        public void CanExecuteCancelSet()
        {
            var viewModel = GetViewModel();
            viewModel.CancelSet.Execute(null);
        }
    }
}
