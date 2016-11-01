using FitSense.DAL;
using Fitsense.Models;
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
    public class ExercisesViewModel : INotifyPropertyChanged
    {
        private INavigationService navigationService;
        private IFitDataService dataService;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand GoToSetPerExercisePageCommand { get; set; }
        public ICommand ActivateChart { get; set; }

        private Category selectedCategory;
        public Category SelectedCategory
        {
            get { return selectedCategory; }
            set {
                selectedCategory = value;
                LoadData();
                RaisePropertyChanged("SelectedCategory");
            }
        }


        private ObservableCollection<Exercise> exercises { get; set; }
        public ObservableCollection<Exercise> Exercises
        {
            get { return exercises; }
            set
            {
                exercises = value;
                RaisePropertyChanged("Exercises");
            }
        }

        public Exercise selectedExercise { get; set; }
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

        public ExercisesViewModel(INavigationService navigationService, IFitDataService dataService)
        {
            this.dataService = dataService;
            this.navigationService = navigationService;
  
            LoadMessengerListeners();
            LoadData();
            LoadCommands();
        }

        private void LoadMessengerListeners()
        {
            Messenger.Default.Register<UpdateSelectedCategory>(this, OnUpdateSelectedCategoryReceived);
        }

        private void LoadData()
        {
            Exercises = dataService.GetExercisesFromCategory(SelectedCategory).ToObservableCollection();
        }

        private void LoadCommands()
        {
            GoToSetPerExercisePageCommand = new AlwaysRunCommand((object o) =>
            {
                Messenger.Default.Send<SendExercise>(new SendExercise() { Exercise = SelectedExercise });
                Messenger.Default.Send<ChangePage>(new ChangePage() { Page = navigationService.NavigateTo(NavigationService.SETSPEREXERCISE) });
            });

            ActivateChart = new AlwaysRunCommand((object o) =>
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
