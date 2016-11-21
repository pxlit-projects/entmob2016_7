/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:FitSense"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using fitsense.DAL;
using fitsense.DAL.dependencies;
using FitSense.Dependencies;
using FitSense.Models;
using FitSense.Services;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Xamarin.Forms;

namespace FitSense.ViewModels
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
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

            SimpleIoc.Default.Register<INavigationService, NavigationService>();

            SimpleIoc.Default.Register<IUserRepository, UserRepository>();
            SimpleIoc.Default.Register<ICategoryRepository, CategoryRepository>();
            SimpleIoc.Default.Register<IExerciseRepository, ExerciseRepository>();
            SimpleIoc.Default.Register<ISetRepository, SetRepository>();
            SimpleIoc.Default.Register<IDataService, DataService>();
            //SimpleIoc.Default.Register<IUserDataService>(() => new UserDataService(
            //    new CategoryRepository(),
            //    new ExerciseRepository(),
            //    new SetRepository()));

            SimpleIoc.Default.Register<IConnectivity>(() => DependencyService.Get<IConnectivity>());
            SimpleIoc.Default.Register<IBluetoothService>(() => DependencyService.Get<IBluetoothService>());

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<SensorConnectViewModel>();
            SimpleIoc.Default.Register<SensorDevice>();
            SimpleIoc.Default.Register<CategoriesViewModel>();

            SimpleIoc.Default.Register<ExercisesViewModel>();
            SimpleIoc.Default.Register<ExerciseViewModel>();
            SimpleIoc.Default.Register<SetsCarouselViewModel>();
            SimpleIoc.Default.Register<ActiveSetViewModel>();
            //SimpleIoc.Default.Register<IDummyRepository, DummyRepository>();
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

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}