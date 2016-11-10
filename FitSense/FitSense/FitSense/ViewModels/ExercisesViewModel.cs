using fitsense.models;
using FitSense.Dependencies;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSense.ViewModels
{
    class ExercisesViewModel
    {
        private IUserDataService userDataService;
        private INavigationService navigationService;

        public ObservableCollection<Exercise> Exercises { get; private set; }

        public ExercisesViewModel(INavigationService navigationService, IUserDataService userDataService)
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