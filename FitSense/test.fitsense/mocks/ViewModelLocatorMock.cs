using FitSense.Dependencies;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.fitsense.mocks
{
    class ViewModelLocatorMock
    {

        public ViewModelLocatorMock()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<INavigationService, NavigationServiceMock>();
            // DANIEL: ik denk dat ge zo constructor injection moet doen
            SimpleIoc.Default.Register<IUserDataService, UserDataServiceMock>();
            SimpleIoc.Default.Register<IConnectivity, ConnectivityMock>();
            //SimpleIoc.Default.Register<IDummyRepository, DummyRepository>();
        }
    }
}
