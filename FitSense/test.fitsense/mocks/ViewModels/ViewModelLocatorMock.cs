using fitsense.DAL.dependencies;
using FitSense.Dependencies;
using FitSense.Models;
using FitSense.Services;
using FitSense.ViewModels;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.fitsense.mocks.Repository;
using test.fitsense.mocks.ServiceMocks;

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
            //SimpleIoc.Default.Register<IDataService, UserDataServiceMockOld>();

            //SimpleIoc.Default.Register<IDataService, DataServiceMock>();

            SimpleIoc.Default.Register<ICategoryRepository, CategoryRepositoryMock>();
            SimpleIoc.Default.Register<IExerciseRepository, ExerciseRepositoryMock>();
            SimpleIoc.Default.Register<ISetRepository, SetRepositoryMock>();
            SimpleIoc.Default.Register<IUserRepository, UserRepositoryMock>();

            SimpleIoc.Default.Register<IDataService, DataService>();


            SimpleIoc.Default.Register<IConnectivity, ConnectivityMock>();
            //SimpleIoc.Default.Register<SensorDevice>();

            SimpleIoc.Default.Register<IBluetoothService, BluetoothServiceMock>();

            SimpleIoc.Default.Register<SensorDevice>();

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<SensorConnectViewModel>();
            SimpleIoc.Default.Register<CategoriesViewModel>();

            SimpleIoc.Default.Register<ExercisesViewModel>();
            SimpleIoc.Default.Register<ExerciseViewModel>();
            SimpleIoc.Default.Register<SetsCarouselViewModel>();
            SimpleIoc.Default.Register<ActiveSetViewModel>();
            SimpleIoc.Default.Register<SetViewModel>();
        }

        public void replaceDataServiceMock()
        {
            //SimpleIoc.Default.Unregister<IDataService>();

            //SimpleIoc.Default.Register<ICategoryRepository, CategoryRepositoryMock>();
            //SimpleIoc.Default.Register<IExerciseRepository, ExerciseRepositoryMock>();
            //SimpleIoc.Default.Register<ISetRepository, SetRepositoryMock>();
            //SimpleIoc.Default.Register<IUserRepository, UserRepositoryMock>();

            //SimpleIoc.Default.Register<IDataService, DataService>();
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

        public SetViewModel SetViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SetViewModel>();
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
