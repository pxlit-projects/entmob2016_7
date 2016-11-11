using fitsense.models;
using FitSense.Dependencies;
using FitSense.Extensions;
using FitSense.Messages;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSense.ViewModels
{
    public class ExercisesViewModel : ViewModelBase
    {
        private IUserDataService userDataService;
        private INavigationService navigationService;

        public ObservableCollection<ExerciseViewModel> ExercisesViews { get; private set; }
        public int Index { get; private set; }
        public Category Category { get; private set; }

        public ExercisesViewModel(INavigationService navigationService, IUserDataService userDataService)
        {
            this.userDataService = userDataService;
            this.navigationService = navigationService;

            InitializeCommands();
            InitializeMessages();
            LoadData();
        }

        private void LoadData()
        {
            //Exercises = userDataService.GetAllCategories().ToObservableCollection();
            ExercisesViews = new ObservableCollection<ExerciseViewModel>();
            List<Exercise> exercises = userDataService.GetExercisesFromCategory(Category);
            foreach(Exercise e in exercises)
            {
                ExercisesViews.Add(new ExerciseViewModel(navigationService, userDataService)
                {
                    Exercise = e
                });
            }
        }

        private void InitializeCommands()
        {
        }

        private void InitializeMessages()
        {
            MessengerInstance.Register<CategoryUpdated>(this, (sender) =>
            {
                Category = sender.Category;
                LoadData();
            });
        }
    }
}