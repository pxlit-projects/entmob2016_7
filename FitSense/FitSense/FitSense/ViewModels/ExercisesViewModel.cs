using fitsense.models;
using FitSense.Dependencies;
using FitSense.Extensions;
using FitSense.Repositories;
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

        private ObservableCollection<ExerciseViewModel> exercisesViews;
        public ObservableCollection<ExerciseViewModel> ExercisesViews
        {
            get
            {
                return exercisesViews;
            }
            private set
            {
                ObservableCollection<ExerciseViewModel> old = exercisesViews;
                exercisesViews = value;
                RaisePropertyChanged("ExercisesViews", old, value, true);
            }
        }

        public int Index { get; private set; }
        public Category Category { get; private set; }

        public ExercisesViewModel(INavigationService navigationService, IUserDataService userDataService)
        {
            this.userDataService = userDataService;
            this.navigationService = navigationService;

            InitializeMessages();
            LoadDataAsync();
        }

        private async void LoadDataAsync()
        {
            //Exercises = userDataService.GetAllCategories().ToObservableCollection();
            ExercisesViews = new ObservableCollection<ExerciseViewModel>();
            List<Exercise> exercises = await new ExerciseRepository().GetExercisesFromCategory(Category);
             
            foreach(Exercise e in exercises)
            {
                ExercisesViews.Add(new ExerciseViewModel(navigationService, userDataService)
                {
                    Exercise = e,
                    Category = Category
                });
            }
        }

        private void InitializeMessages()
        {
            MessengerInstance.Register<Category>(this, Constants.Messages.CategoryUpdated, (sender) =>
            {
                Category = sender;
                LoadDataAsync();
            });
        }
    }
}