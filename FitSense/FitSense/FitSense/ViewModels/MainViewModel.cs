using FitSense.Constants;
using FitSense.Dependencies;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;
using System.Windows.Input;
using Xamarin.Forms;
using System;

namespace FitSense.ViewModels
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private INavigationService navigation;
        private IUserDataService userDataService;
        //public RelayCommand LoginCommand;
        public RelayCommand ConnectCommand { get; private set; }
        public RelayCommand LoginCommand { get; private set; }
        public RelayCommand CarouselCommand { get; private set; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(INavigationService navigationService, IUserDataService userDataService)
        {
            this.navigation = navigationService;
            this.userDataService = userDataService;

            InitializeCommands();
            InitializeMessages();
        }

        private void InitializeCommands()
        {
            ConnectCommand = new RelayCommand(async () =>
            {
                await navigation.PushAsync(PageUrls.SensorConnectView);
            });

            LoginCommand = new RelayCommand(async () =>
            {
                if (userDataService.LoggedInUser == null)
                    await navigation.PushModalAsync(PageUrls.LoginView);
            });
            
        }

        private void InitializeMessages()
        {
            MessengerInstance.Register<LoginViewModel>(this, Messages.LoginSucces, (sender) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await navigation.PopModalAsync();
                });
            });
        }
    }
}