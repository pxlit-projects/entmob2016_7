using FitSense.Model;
using FitSense_UWP.Extensions;
using FitSense_UWP.Messages;
using FitSense_UWP.Services;
using FitSense_UWP.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSense_UWP.ViewModel
{
    public class ExercisesViewModel : INotifyPropertyChanged
    {
        private INavigationService navigationService;
        private IFitDataService dataService;
        private MessagingService messagingService;

        public event PropertyChangedEventHandler PropertyChanged;

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
                RaisePropertyChanged("Exercise");
            }
        }

        public Exercise selectedPage { get; set; }
        public Exercise SelectedPage
        {
            get { return selectedPage; }
            set
            {
                selectedPage = value;
                RaisePropertyChanged("SelectedExersice");
                navigationService.NavigateTo(NavigationService.EXERCISES);
            }
        }

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public ExercisesViewModel(INavigationService navigationService, IFitDataService dataService, MessagingService messagingService)
        {
            this.dataService = dataService;
            this.navigationService = navigationService;
            this.messagingService = messagingService;
            Exercises = dataService.GetAllExercises().ToObservableCollection();

            Messenger.Default.Register<UpdateSelectedCategory>(this, OnUpdateSelectedCategoryReceived);

            //Initialise commands
        }

        private void OnUpdateSelectedCategoryReceived(UpdateSelectedCategory obj)
        {
            SelectedCategory = messagingService.Category;
        }
    }
}
