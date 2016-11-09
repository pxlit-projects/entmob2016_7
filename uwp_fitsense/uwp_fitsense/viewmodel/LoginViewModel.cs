﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using uwp_fitsense.dependencies;
using uwp_fitsense.utility;

namespace uwp_fitsense.viewmodel
{
    public class LoginViewModel
    {
        public ICommand LoginCommand { get; set; }
        private INavigationService navigationService;
        //private ILoginService loginService;

        public LoginViewModel(INavigationService navigationService)//, ILoginService loginService)
        {
            this.navigationService = navigationService;
            //this.loginService = loginService;

            RegisterCommands();
        }

        private void RegisterCommands()
        {
            LoginCommand = new AlwaysRunCommand((Object o) =>
            {
                navigationService.NavigateFromLoginToApplication();
            });
        }
    }
}
