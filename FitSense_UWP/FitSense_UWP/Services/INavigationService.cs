using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace FitSense_UWP.Services
{
    //A service to navigate between screens
    public interface INavigationService
    {
        Type NavigateTo(String destination);
        void NavigateFromLoginToApplication();
    }
}
