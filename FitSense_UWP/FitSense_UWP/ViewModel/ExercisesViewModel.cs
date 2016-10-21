using FitSense.DAL;
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
    public class ExercisesViewModel : INotifyPropertyChanged
    {
        private INavigationService navigationService;
        private IFitDataService dataService;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand GoToSetPerExercisePageCommand;

        private Category selectedCategory;
        public Category SelectedCategory
        {
            get { return selectedCategory; }
            set {
                selectedCategory = value;
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
                navigationService.NavigateTo(NavigationService.EXERCISES);
            }
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
            //Initialise commands
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
                Messenger.Default.Send<SendExercise>(new SendExercise() { exercise = SelectedExercise });
                Messenger.Default.Send<ChangePage>(new ChangePage() { Page = navigationService.NavigateTo(NavigationService.SETSPEREXERCISE) });
            });
        }

        private void OnUpdateSelectedCategoryReceived(UpdateSelectedCategory updateCategory)
        {
            SelectedCategory = updateCategory.Category;
            LoadData();
        }
    }
}
