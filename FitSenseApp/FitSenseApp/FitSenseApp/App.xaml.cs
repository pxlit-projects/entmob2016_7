using FitSenseApp.Pages;
using Robotics.Mobile.Core.Bluetooth.LE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FitSenseApp
{
    public partial class App : Application
    {
        public static IAdapter adaptor;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new DeviceList(adaptor));
        }

        public static void SetAdaptor(IAdapter adaptor)
        {
            App.adaptor = adaptor;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
