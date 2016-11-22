using fitsense.models;
using FitSense.Constants;
using FitSense.Dependencies;
using FitSense.ViewModels;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.ServiceLocation;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using test.fitsense.mocks;

namespace test.fitsense
{
    [TestClass]
    public class ActiveSetViewModelTest
    {
        private ViewModelLocatorMock locatorMock;

        private void sendMessage()
        {
            Set sendingSet = new Set() { SetID = 0, MaxTime = 10, Reps = 20 };
            IMessenger messenger = Messenger.Default;
            messenger.Send(sendingSet, Messages.SetUpdated);
        }

        [TestInitialize]
        public void Init()
        {
            locatorMock = new ViewModelLocatorMock();
        }

        [TestMethod]
        public void DataLoadedTest()
        {
            var viewmodel = locatorMock.ActiveSetViewModel;
            sendMessage();
            Assert.AreEqual(10, viewmodel.TimeLeft);
            Assert.AreEqual(20, viewmodel.RepsLeft);
        }

        [TestMethod]
        public void IsCancelSetLoadedTest()
        {
            var viewmodel = locatorMock.ActiveSetViewModel;
            Assert.IsNotNull(viewmodel.CancelSet);
        }

        [TestMethod]
        public void IsStartSetLoadedTest()
        {
            var viewmodel = locatorMock.ActiveSetViewModel;
            Assert.IsNotNull(viewmodel.StartSet);
        }

        [TestMethod]
        public void CanCancelSetTest()
        {
            var viewmodel = locatorMock.ActiveSetViewModel;
            var navigation = ServiceLocator.Current.GetInstance<INavigationService>() as NavigationServiceMock;

            Assert.IsNotNull(viewmodel.CancelSet);

            viewmodel.CancelSet.Execute(null);

            Assert.IsTrue(navigation.Poped);
        }
    }
}
