using fitsense.models;
using FitSense.Dependencies;
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

        public ObservableCollection<ExerciseViewModel> Exercises { get; private set; }
        public int Index { get; private set; }


        public ExercisesViewModel(INavigationService navigationService, IUserDataService userDataService)
        {
            this.userDataService = userDataService;
            this.navigationService = navigationService;
            Index = 5;

            InitializeCommands();
            LoadData();
        }

        private void LoadData()
        {
            //Exercises = userDataService.GetAllCategories().ToObservableCollection();
            Exercises = new ObservableCollection<ExerciseViewModel>()
            {
                new ExerciseViewModel(navigationService, userDataService)
                {
                    Exercise = new Exercise()
                    {
                        ExerciseID = 0,
                        Name = "Exercise 0"
                    }
                },
                new ExerciseViewModel(navigationService, userDataService)
                {
                    Exercise = new Exercise()
                    {
                        ExerciseID = 1,
                        Name = "Exercise 1"
                    }
                },
                new ExerciseViewModel(navigationService, userDataService)
                {
                    Exercise = new Exercise()
                    {
                        ExerciseID = 2,
                        Name = "Exercise 2"
                    }
                }
            };
        }

        private void InitializeCommands()
        {
        }
    }
}