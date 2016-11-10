using fitsense.models;
using FitSense.Dependencies;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSense.ViewModels
{
    public class ExerciseViewModel : ViewModelBase
    {
        private IUserDataService userDataService;
        private INavigationService navigationService;

        public Exercise Exercise { get; set; }

        public ExerciseViewModel(INavigationService navigationService, IUserDataService userDataService)
        {
            this.userDataService = userDataService;
            this.navigationService = navigationService;

            InitializeCommands();
            LoadData();
        }

        private void LoadData()
        {
            //Exercises = userDataService.GetAllCategories().ToObservableCollection();
        }

        private void InitializeCommands()
        {
        }
    }
}