﻿using fitsense.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using uwp_fitsense.dependencies;
using uwp_fitsense.extensions;
using uwp_fitsense.messages;
using uwp_fitsense.services;
using uwp_fitsense.utility;

namespace uwp_fitsense.viewmodel
{
    public class ExercisesViewModel : INotifyPropertyChanged
    {
        private INavigationService navigationService;
        private IFitDataService dataService;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand GoToSetPerExercisePageCommand { get; set; }
        public ICommand ActivateChartCommand { get; set; }

        private Category selectedCategory;
        public Category SelectedCategory
        {
            get { return selectedCategory; }
            set
            {
                selectedCategory = value;
                PrepareLoadingDataAsync();
                RaisePropertyChanged("SelectedCategory");
            }
        }


        private ObservableCollection<Exercise> exercises;
        public ObservableCollection<Exercise> Exercises
        {
            get { return exercises; }
            set
            {
                exercises = value;
                RaisePropertyChanged("Exercises");
            }
        }

        public Exercise selectedExercise;
        public Exercise SelectedExercise
        {
            get { return selectedExercise; }
            set
            {
                selectedExercise = value;
                RaisePropertyChanged("SelectedExercise");
                //UpdateChartData
            }
        }

        private List<ChartRecord> activeChart;
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

        private void UpdateChartData()
        {
            List<ChartRecord> records = new List<ChartRecord>();
            foreach (Set set in selectedExercise.Sets)
            {
                foreach (CompletedSet completedSet in set.CompletedSets.OrderBy(c => c.Time))
                {
                    String date = "" + (completedSet.Time / 1000000);
                    date = String.Format("{0}/{1}/{2}", date.Substring(0, 2), date.Substring(2, 2), date.Substring(4, 2));
                    if (records.Count > 0)
                    {
                        if (records.Last().Date == date)
                        {
                            records.Last().Point += set.Points;
                        }
                        else
                        {
                            records.Add(new ChartRecord()
                            {

                                Date = date,
                                Point = set.Points
                            });
                        }
                    }
                    else
                    {
                        records.Add(new ChartRecord()
                        {
                            Date = date,
                            Point = set.Points
                        });
                    }
                }
            }
            ActiveChart = records;
        }

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public ExercisesViewModel(IFitDataService dataService, INavigationService navigationService)
        {
            this.dataService = dataService;
            this.navigationService = navigationService;

            LoadMessengerListeners();
            Initializing = LoadDataAsync();
            LoadCommands();
        }

        public Task Initializing { get; private set; }

        private void LoadMessengerListeners()
        {
            Messenger.Default.Register<UpdateSelectedCategory>(this, OnUpdateSelectedCategoryReceived);
        }

        private async void PrepareLoadingDataAsync()
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            var result = await dataService.GetExercisesFromCategoryAsync(SelectedCategory);
            Exercises = result.ToObservableCollection();
        }

        private void LoadCommands()
        {
            GoToSetPerExercisePageCommand = new AlwaysRunCommand((object o) =>
            {
                Messenger.Default.Send<SendExercise>(new SendExercise() { Exercise = SelectedExercise });
                Messenger.Default.Send<ChangePage>(new ChangePage() { Page = navigationService.NavigateTo(NavigationService.SETSPEREXERCISE) });
            });

            ActivateChartCommand = new AlwaysRunCommand((object o) =>
            {
                UpdateChartData();
            });
        }

        private void OnUpdateSelectedCategoryReceived(UpdateSelectedCategory updateCategory)
        {
            SelectedCategory = updateCategory.Category;
        }
    }
}