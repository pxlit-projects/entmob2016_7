using FitSense.Model;
using FitSense_UWP.Extensions;
using FitSense_UWP.Messages;
using FitSense_UWP.Services;
using FitSense_UWP.Util;
using FitSense_UWP.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FitSense_UWP.ViewModel
{
    public class SetsPerExerciseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ToggleShowCompletedSets { get; set; }
        private IFitDataService fitDataService;
        private INavigationService navigationService;

        private Exercise currentExercise { get; set; }
        public Exercise CurrentExercise
        {
            get { return currentExercise; }
            set
            {
                currentExercise = value;
                if(currentExercise != null)
                    LoadData();
                RaisePropertyChanged("CurrentExercise");
            }
        }

        private ObservableCollection<Set> sets { get; set; }
        public ObservableCollection<Set> Sets
        {
            get { return sets; }
            set
            {
                sets = value;
                RaisePropertyChanged("Sets");
            }
        }

        private Set selectedSet;
        public Set SelectedSet
        {
            get { return selectedSet; }
            set
            {
                selectedSet = value;
                RaisePropertyChanged("SelectedSet");
            }
        }

        public SetsPerExerciseViewModel(IFitDataService dataService, INavigationService dialogService)
        {
            this.fitDataService = dataService;
            this.navigationService = dialogService;
               
            LoadMessengerListeners();
            LoadCommands();
        }

        private void LoadMessengerListeners()
        {
            Messenger.Default.Register<SendExercise>(this, sendExercise =>
            {
                CurrentExercise = sendExercise.Exercise;
            });
        }

        private void LoadData()
        {
            sets = fitDataService.GetSetsFromExercise(CurrentExercise).ToObservableCollection();
        }

        private void LoadCommands()
        {
            ToggleShowCompletedSets = new AlwaysRunCommand((Object o) =>
            {           
                SelectedSet = fitDataService.ToggleSelectedSetVisibility(SelectedSet);
            });
        }

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
