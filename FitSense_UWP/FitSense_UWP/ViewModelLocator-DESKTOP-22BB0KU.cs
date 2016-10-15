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

        private static MainPageViewModel mainPageViewModel = new MainPageViewModel(dataService, navigationService, LoginService.Instance);

        public static MainPageViewModel MainPageViewModel
        {
            get
            {
                return mainPageViewModel;
            }
        }


    }
}