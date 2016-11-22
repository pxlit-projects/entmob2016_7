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
using test.fitsense.mocks;
using test.fitsense.mocks.Repository;

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

        [TestMethod]
        public void RepButtonCommandTest()
        {
            var viewmodel = locatorMock.ActiveSetViewModel;
            var set = new Set()
            {
                MaxTime = 100,
                SetID = 1,
                Points = 10,
                Reps = 10,
                ExerciseID = 1
            };

            Messenger.Default.Send<Set>(set, Messages.SetUpdated);

            Assert.IsNotNull(viewmodel.RepButtonCommand);
            Assert.AreEqual(set.Reps, viewmodel.RepsLeft);
            
            viewmodel.RepButtonCommand.Execute(null);

            Assert.AreEqual(set.Reps - 1, viewmodel.RepsLeft);
            
        }

        
    }
}
