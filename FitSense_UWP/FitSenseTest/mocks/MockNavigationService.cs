﻿using FitSense_UWP.Services;
using FitSense_UWP.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSenseTest.mocks
{
    public class MockNavigationService : INavigationService
    {
        public const String EXERCISES = "Exercises";
        public const String SETSPEREXERCISE = "SetsPerExercise";
        public const String LOGIN = "Login";

        public Type NavigateTo(String destination)
        {
            switch (destination)
            {
                case LOGIN:
                    return typeof(Login);
                case EXERCISES:
                    return typeof(Oefeningen);
                case SETSPEREXERCISE:
                    return typeof(SetsPerExercisePage);
                default:
                    return typeof(CategoriesPage);
            }
        }

        public void NavigateFromLoginToApplication()
        {
            throw new NotImplementedException();
        }
    }
}
