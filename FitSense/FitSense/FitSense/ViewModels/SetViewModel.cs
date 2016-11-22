using fitsense.models;
using FitSense.Constants;
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
    public class SetViewModel : ViewModelBase
    {
        private IDataService userDataService;
        private INavigationService navigationService;

        public Exercise Exercise { get; set; }
        public Set Set { get; set; }

        public RelayCommand StartSet { get; private set; }

        public SetViewModel(INavigationService navigationService, IDataService userDataService)
        {
            this.userDataService = userDataService;
            this.navigationService = navigationService;

            InitializeCommands();
        }

        private void InitializeCommands()
        {
            StartSet = new RelayCommand(async () =>
            {
                await navigationService.PushAsync(PageUrls.ACTIVESET).ContinueWith((antecedent) =>
                {
                    MessengerInstance.Send(Set, Constants.Messages.SetUpdated);
                });
            });
        }
    }
}