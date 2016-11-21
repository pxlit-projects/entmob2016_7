using FitSense.Constants;
using FitSense.Dependencies;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;
using System.Windows.Input;
using Xamarin.Forms;
using System;
using FitSense.Models;
using System.Diagnostics;
using System.Numerics;
using System.Collections.Generic;

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
        //public RelayCommand LoginCommand { get; private set; }
        public RelayCommand CarouselCommand { get; private set; }
        public RelayCommand GoToCategoriesCommand { get; private set; }

        public RelayCommand TestCommand { get; private set; }

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
                await navigation.PushAsync(PageUrls.SENSORCONNECTVIEW);
            });

            GoToCategoriesCommand = new RelayCommand(async () =>
            {
                await navigation.PushAsync(PageUrls.CATEGORIESVIEW);
            });

            //LoginCommand = new RelayCommand(async () =>
            //{
            //    if (userDataService.LoggedInUser == null)
            //        await navigation.PushModalAsync(PageUrls.LOGINVIEW);
            //});

            TestCommand = new RelayCommand(() =>
            {
                SensorDevice sensor = ServiceLocator.Current.GetInstance<SensorDevice>();
                if (sensor.MovementService != null)
                {
                    if (!sensor.MovementService.IsOn)
                    {
                        sensor.MovementService.SetEnabled(true);
                    }
                    if (!sensor.MovementService.IsUpdating)
                    {
                        sensor.MovementService.StartReadData(100);
                        sensor.MovementService.OnValueChanged += MovementService_OnValueChanged;
                    }
                    else
                    {
                        sensor.MovementService.stopReadData();
                        sensor.MovementService.OnValueChanged -= MovementService_OnValueChanged;
                        foreach (var vect in vectList)
                        {
                            Debug.WriteLine(vect.X + "," + vect.Y + "," + vect.Z);
                        }
                    }
                    
                }
                else
                {
                    Debug.WriteLine("Movementsensor not found.");
                }
            });
            
        }

        private List<Vector3> vectList = new List<Vector3>();

        private void MovementService_OnValueChanged(object sender, Helpers.ValueChangedEventArgs<System.Numerics.Vector3> args)
        {
            Debug.WriteLine("Data Retrieved.");
            vectList.Add(args.NewValue);
        }

        private void InitializeMessages()
        {
            //MessengerInstance.Register<LoginViewModel>(this, Constants.Messages.LoginSucces, (sender) =>
            //{
            //    Device.BeginInvokeOnMainThread(async () =>
            //    {
            //        await navigation.PopModalAsync();
            //    });
            //});
        }
    }
}