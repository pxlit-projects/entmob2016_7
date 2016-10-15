using FitSense.Model;
using FitSense_UWP.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitSense_UWP.Extensions;
using FitSense_UWP.Util;
using FitSense_UWP.Messages;
using Windows.UI.Xaml.Controls;
using FitSense_UWP.View;

namespace FitSense_UWP.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IFitDataService fitDataService;
        private INavigationService navigationService;
        private ILoginService loginService;

        private ObservableCollection<Distance> distances;
        private Distance selectedDistance;

        public ObservableCollection<Distance> Distances
        {
            get { return distances; }
            set
            {
                distances = value;
                RaisePropertyChanged("Distances");
            }
        }

        public Distance SelectedDistance
        {
            get { return selectedDistance; }
            set
            {
                selectedDistance = value;
                RaisePropertyChanged("SelectedDistance");
            }
        }

        public MainPageViewModel(IFitDataService fitDataService, INavigationService navigationService, ILoginService loginService)
        {
            this.navigationService = navigationService;
            this.fitDataService = fitDataService;
            this.loginService = loginService;

            LoadData();
            Messenger.Default.Register<UpdateListMessage>(this, OnUpdateListMessageReceived);

            //Navigate away from here if you are nog logged in correctly
            if (!loginService.isLoggedIn())
                navigationService.NavigateTo(typeof(Login));
        }

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        //The data got updated in another screen, reload it!
        private void OnUpdateListMessageReceived(UpdateListMessage obj)
        {
            LoadData();

        }

        //ask the service for the data and convert it to an observable collection so you can see live changes
        private void LoadData()
        {
            distances = fitDataService.GetAllRecords().ToObservableCollection();
        }

        
    }
}
