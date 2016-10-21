using FitSense_UWP.Services;
using FitSense_UWP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSense_UWP
{
    public class ViewModelLocator
    {
        private static IFitDataService dataService = new FitDataService();
        private static INavigationService navigationService = new NavigationService();
        private static MessagingService messagingService = new MessagingService();

        private LoginViewModel loginViewModel = new LoginViewModel(navigationService, LoginService.Instance);
        public LoginViewModel LoginViewModel
        {
            get { return loginViewModel; }
            set { loginViewModel = value; }
        }

        private CategoriesPageViewModel categoriesPageViewModel = new CategoriesPageViewModel(dataService, navigationService, messagingService);
        public CategoriesPageViewModel CategoriesPageViewModel
        {
            get { return categoriesPageViewModel; }
            set { categoriesPageViewModel = value; }
        }

        private ExercisesViewModel exercisesViewModel = new ExercisesViewModel(navigationService, dataService, messagingService);
        public ExercisesViewModel ExercisesViewModel
        {
            get { return exercisesViewModel; }
            set { exercisesViewModel = value; }
        }
    }
}