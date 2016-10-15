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

        public NavigationService()
        {
        }

        public void CloseLoginDialog()
        {
            

        }

        public Type NavigateTo(String pageName)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            switch(pageName)
            {
                case "Login":
                    //rootFrame.Navigate(typeof(Login));
                    return typeof(Login);
                    break;
                default:
                    //rootFrame.Navigate(typeof(MainPage));
                    return typeof(MainPage);
                    break;
            }
        }
    }
}
