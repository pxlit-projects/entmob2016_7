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
    public class SetViewModel : ViewModelBase
    {
        private IUserDataService userDataService;
        private INavigationService navigationService;

        public Exercise Exercise { get; set; }
        public Set Set { get; set; }

        public SetViewModel(INavigationService navigationService, IUserDataService userDataService)
        {
            this.userDataService = userDataService;
            this.navigationService = navigationService;

            InitializeCommands();
        }

        private void InitializeCommands()
        {
        }
    }
}