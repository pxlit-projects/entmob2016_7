using fitsense.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using uwp_fitsense.dependencies;
using uwp_fitsense.extensions;
using uwp_fitsense.messages;
using uwp_fitsense.utility;

namespace uwp_fitsense.viewmodel
{
    public class SetsPerExerciseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand ToggleShowCompletedSetsCommand { get; set; }
        private IFitDataService fitDataService;
        private INavigationService navigationService;

        public List<ChartRecord> activeChart;
        public List<ChartRecord> ActiveChart
        {
            get
            {
                return activeChart;
            }
            set
            {
                activeChart = value;
                RaisePropertyChanged("ActiveChart");
            }
        }
        
        private Exercise currentExercise;
        public Exercise CurrentExercise
        {
            get { return currentExercise; }
            set
            {
                currentExercise = value;
                if (currentExercise != null)
                    Initializing = LoadDataAsync();
                RaisePropertyChanged("CurrentExercise");
            }
        }

        public Task Initializing { get; private set; }

        private ObservableCollection<Set> sets;
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
                UpdateChartData();
                RaisePropertyChanged("SelectedSet");
            }
        }

        private void UpdateChartData()
        {
            List<ChartRecord> records = new List<ChartRecord>();
            if (selectedSet.CompletedSets != null)
            {
                foreach (CompletedSet c in selectedSet.CompletedSets.OrderBy(c => c.Time))
                {
                    String date = "" + (c.Time / 1000000);
                    date = String.Format("{0}/{1}/{2}", date.Substring(0, 2), date.Substring(2, 2), date.Substring(4, 2));
                    if (records.Count > 0)
                    {
                        if (records.Last().Date == date)
                        {
                            records.Last().Point += selectedSet.Points;
                        }
                        else
                        {
                            records.Add(new ChartRecord()
                            {
                                Date = date,
                                Point = selectedSet.Points
                            });
                        }
                    }
                    else
                    {
                        records.Add(new ChartRecord()
                        {
                            Date = date,
                            Point = selectedSet.Points
                        });
                    }
                }
                ActiveChart = records;
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

        private async void PrepareLoadingAsync()
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            if (CurrentExercise != null)
            {
                Sets = (await fitDataService.GetSetsFromExerciseAsync(CurrentExercise)).ToObservableCollection();
            }
        }

        private void LoadCommands()
        {
            ToggleShowCompletedSetsCommand = new AlwaysRunCommand((Object o) =>
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