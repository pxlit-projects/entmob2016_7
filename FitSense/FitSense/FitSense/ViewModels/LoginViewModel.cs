using FitSense.Constants;
using FitSense.Dependencies;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FitSense.ViewModels
{
    class LoginViewModel : ViewModelBase
    {

        private IUserDataService userDataService;
        private INavigationService navigationService;

        public string Username { get; set; }
        public string Password { get; set; }
        public string Feedback { get; set; }
        public string ValidationErrors { get; private set; }

        public RelayCommand LoginCommand { get; set; }
        public RelayCommand HelpCommand { get; set; }

        public bool CanLogin
        {
            get
            {
                ValidationErrors = string.Empty;

                if (string.IsNullOrEmpty(Username))
                    ValidationErrors = "Please enter a username.";

                if (string.IsNullOrEmpty(Password))
                    ValidationErrors += "Please enter a password.";
                return string.IsNullOrEmpty(ValidationErrors);
            }
        }

        public LoginViewModel()
        {
            userDataService = ServiceLocator.Current.GetInstance<IUserDataService>();
            navigationService = ServiceLocator.Current.GetInstance<INavigationService>();

            LoginCommand = new RelayCommand(() =>
            {
                Feedback = string.Empty;
                if (CanLogin)
                {
                    ConnectionStatus st = DependencyService.Get<IConnectivity>().CheckNetworkStatus();
                    userDataService.LoginAsync(Username, Password).ContinueWith((a) =>
                    {
                        if (userDataService.LoggedInUser != null)
                            MessengerInstance.Send<LoginViewModel>(this, Messages.LoginSucces);
                        else
                            Feedback = "Login attempt failed";
                    });
                    
                }
            });
        }
        
    }
}
