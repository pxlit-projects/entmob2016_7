﻿using FitSense.Constants;
using FitSense.Dependencies;
using FitSense.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;
//using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FitSense.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {

        private IDataService userDataService;
        private INavigationService navigationService;

        public string Username { get; set; }
        public string Password { get; set; }
        public string Feedback { get; set; }
        public string ValidationErrors { get; private set; }

        public RelayCommand LoginCommand { get; set; }
        
        public bool CanLogin
        {
            get
            {
                ValidationErrors = string.Empty;

                if (string.IsNullOrEmpty(Username))
                    ValidationErrors = "Please enter a username.";

                if (string.IsNullOrEmpty(Password))
                    ValidationErrors += "Please enter a password.";
                //return true;
                return string.IsNullOrEmpty(ValidationErrors);
            }
        }

        public LoginViewModel(INavigationService navigationService, IDataService userDataService)
        {
            this.userDataService = userDataService;
            this.navigationService = navigationService;

            InitializeCommands();
        }

        private void InitializeCommands()
        {
            LoginCommand = new RelayCommand(() =>
            {
                //Feedback = string.Empty;
                if (CanLogin)
                {
                    //ConnectionStatus st = DependencyService.Get<IConnectivity>().CheckNetworkStatus();
                    ConnectionStatus st = ServiceLocator.Current.GetInstance<IConnectivity>().CheckNetworkStatus();
                    userDataService.LoginAsync(Username, Password).ContinueWith((a) =>
                    {
                        if (userDataService.LoggedInUser != null)
                        {
                            //MessengerInstance.Send<LoginViewModel>(this, Constants.Messages.LoginSucces);
                            Device.BeginInvokeOnMainThread(() =>
                            {
                                var main = new MainView();
                                Application.Current.MainPage = new NavigationPage(main);
                                navigationService.Navigation = main.Navigation;
                            });
                            
                        }
                        else
                            Feedback = "Login attempt failed";
                    });

                }
            });
        }
    }
}
