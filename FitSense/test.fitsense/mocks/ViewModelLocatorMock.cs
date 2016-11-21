using FitSense.Dependencies;
using FitSense.ViewModels;
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
            SimpleIoc.Default.Register<IUserDataService, UserDataServiceMock>();
            SimpleIoc.Default.Register<IConnectivity, ConnectivityMock>();
            //SimpleIoc.Default.Register<SensorDevice>();

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<SensorConnectViewModel>();
            SimpleIoc.Default.Register<CategoriesViewModel>();

            SimpleIoc.Default.Register<ExercisesViewModel>();
            SimpleIoc.Default.Register<ExerciseViewModel>();
            SimpleIoc.Default.Register<SetsCarouselViewModel>();
            SimpleIoc.Default.Register<ActiveSetViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public LoginViewModel Login
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginViewModel>();
            }
        }

        public SensorConnectViewModel Connect
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SensorConnectViewModel>();
            }
        }

        public CategoriesViewModel CategoriesViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CategoriesViewModel>();
            }
        }

        public ExercisesViewModel ExercisesViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ExercisesViewModel>();
            }
        }

        public ExerciseViewModel ExerciseViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ExerciseViewModel>();
            }
        }

        public SetsCarouselViewModel SetsCarouselViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SetsCarouselViewModel>();
            }
        }

        public ActiveSetViewModel ActiveSetViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ActiveSetViewModel>();
            }
        }
    }
}
