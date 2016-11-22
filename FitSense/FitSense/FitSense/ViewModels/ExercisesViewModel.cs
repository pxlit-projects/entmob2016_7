using fitsense.models;
using FitSense.Dependencies;
using FitSense.Extensions;
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
        private IDataService userDataService;
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

        public ExercisesViewModel(INavigationService navigationService, IDataService userDataService)
        {
            this.userDataService = userDataService;
            this.navigationService = navigationService;

            InitializeMessages();
            PrepareLoadingDataAsync();
        }

        private async void PrepareLoadingDataAsync()
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            ExercisesViews = new ObservableCollection<ExerciseViewModel>();
            List<Exercise> exercises = await userDataService.GetExercisesFromCategoryAsync(Category);
             
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
            MessengerInstance.Register<Category>(this, Constants.Messages.CategoryUpdated, async (sender) =>
            {
                Category = sender;
                await LoadDataAsync();
            });
        }
    }
}