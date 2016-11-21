using FitSense.Dependencies;
using FitSense.ViewModels;
using FitSense.Views;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FitSense
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //var main = new MainView();
            var login = new LoginView();

            var navigationService = ServiceLocator.Current.GetInstance<INavigationService>();

            //navigationService.Navigation = main.Navigation;
            navigationService.Navigation = login.Navigation;

            //MainPage = new NavigationPage(main);
            MainPage = new NavigationPage(login);
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
