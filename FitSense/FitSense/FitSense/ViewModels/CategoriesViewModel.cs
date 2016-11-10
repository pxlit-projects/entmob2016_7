﻿using FitSense.Constants;
using FitSense.Dependencies;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSense.ViewModels
{
    public class CategoriesViewModel : ViewModelBase
    {
        private IUserDataService userDataService;
        private INavigationService navigationService;

        public List<String> Categories;

        public RelayCommand GoToCategoryCommand { get; set; }

        public CategoriesViewModel(INavigationService navigationService, IUserDataService userDataService)
        {
            this.userDataService = userDataService;
            this.navigationService = navigationService;

            InitializeCommands();
        }

        private void InitializeCommands()
        {
            GoToCategoryCommand = new RelayCommand(() =>
            {
                //MessengerInstance.Send<LoginViewModel>(this, Messages.LoginSucces);
            });
        }
    }
}
