using FitSense_UWP.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FitSense_UWP.Services
{
    class NavigationService : INavigationService
    {
        public void NavigateBack(Page currentPage)
        {
            throw new NotImplementedException();
        }

        public Type NavigateTo(String destination)
        {
            switch(destination)
            {
                case "Login":
                    return typeof(Login);
                default:
                    return typeof(MainPage);
            }
            //((Frame)Window.Current.Content).Navigate(destination);
        }
    }
}
