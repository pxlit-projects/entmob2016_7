using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FitSense_UWP.Services
{
    class DialogService : IDialogService
    {
        MainPage mainPage = null;

        public DialogService()
        {
        }

        public void CloseLoginDialog()
        {
            

        }

        public void OpenLoginDialog()
        {
            mainPage = new MainPage();
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(MainPage));
        }
    }
}
