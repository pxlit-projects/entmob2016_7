﻿using FitSense.Model;
using FitSense_UWP.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitSense_UWP.Extensions;
using System.Windows.Input;
using FitSense_UWP.Utility;
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

        public ICommand EditCommand { get; set; }

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

        public MainPageViewModel(IFitDataService dataService, INavigationService dialogService, ILoginService loginService)
        {
            this.fitDataService = dataService;
            this.navigationService = dialogService;
            this.loginService = loginService;
            distances = fitDataService.GetAllRecords().ToObservableCollection();

            //TODO: commands deftig uitwerken, dit is een placeholder
            EditCommand = new CustomCommand(NavigateToLogin, YouCanRunIt);
        }

        public void NavigateToLogin(Object obj)
        {
            navigationService.NavigateTo("Login");
        }

        public bool YouCanRunIt(Object obj)
        {
            return true;
        }

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
