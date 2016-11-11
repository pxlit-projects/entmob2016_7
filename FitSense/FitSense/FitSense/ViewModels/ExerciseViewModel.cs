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
    public class ExerciseViewModel : ViewModelBase
    {
        private IUserDataService userDataService;
        private INavigationService navigationService;

        public Exercise Exercise { get; set; }
        public Category Category { get; set; }

        public RelayCommand GoToSetCarouselCommand { get; private set; }

        public ExerciseViewModel(INavigationService navigationService, IUserDataService userDataService)
        {
            this.userDataService = userDataService;
            this.navigationService = navigationService;

            InitializeCommands();
        }

        private void InitializeCommands()
        {
            GoToSetCarouselCommand = new RelayCommand(async () =>
            {
                await navigationService.PushAsync(PageUrls.SETSCAROUSEL).ContinueWith((antecedent) =>
                {
                    MessengerInstance.Send(Exercise, Constants.Messages.ExerciseUpdated);
                });
            });
        }
    }
}