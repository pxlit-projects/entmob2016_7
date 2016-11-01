﻿using FitSense_UWP.Services;
using FitSense_UWP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSense_UWP
{
    public class ViewModelLocator
    {
        private static IFitDataService dataService = new FitDataService(new FitSense.DAL.SensorRepository());
        private static INavigationService navigationService = new NavigationService();

        private SetsPerExerciseViewModel setsPerExerciseViewModel = new SetsPerExerciseViewModel(dataService, navigationService);
        public SetsPerExerciseViewModel SetsPerExerciseViewModel
        {
            get { return setsPerExerciseViewModel; }
            set { setsPerExerciseViewModel = value; }
        }

        private LoginViewModel loginViewModel = new LoginViewModel(navigationService, LoginService.Instance);
        public LoginViewModel LoginViewModel
        {
            get { return loginViewModel; }
            set { loginViewModel = value; }
        }

        private CategoriesPageViewModel categoriesPageViewModel = new CategoriesPageViewModel(dataService, navigationService);
        public CategoriesPageViewModel CategoriesPageViewModel
        {
            get { return categoriesPageViewModel; }
            set { categoriesPageViewModel = value; }
        }

        private ExercisesViewModel exercisesViewModel = new ExercisesViewModel(navigationService, dataService);
        public ExercisesViewModel ExercisesViewModel
        {
            get { return exercisesViewModel; }
            set { exercisesViewModel = value; }
        }
    }
}