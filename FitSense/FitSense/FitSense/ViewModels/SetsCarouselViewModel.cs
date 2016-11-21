using fitsense.models;
using FitSense.Dependencies;
using FitSense.Extensions;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FitSense.ViewModels
{
    public class SetsCarouselViewModel : ViewModelBase
    {
        private IUserDataService userDataService;
        private INavigationService navigationService;

        private ObservableCollection<SetViewModel> setViews;
        public ObservableCollection<SetViewModel> SetViews
        {
            get
            {
                return setViews;
            }
            private set
            {
                ObservableCollection<SetViewModel> old = setViews;
                setViews = value;
                RaisePropertyChanged("SetViews", old, value, true);
            }
        }
        public Exercise Exercise { get; private set; }

        public SetsCarouselViewModel(INavigationService navigationService, IUserDataService userDataService)
        {
            this.userDataService = userDataService;
            this.navigationService = navigationService;

            InitializeMessages();
        }

        private void LoadData()
        {
            SetViews = (userDataService.GetSetViewModelsFromExercise(Exercise, navigationService)).ToObservableCollection();
        }

        private void InitializeMessages()
        {
            MessengerInstance.Register<Exercise>(this, Constants.Messages.ExerciseUpdated, (sender) =>
            {
                Exercise = sender;
                LoadData();
            });
        }
    }
}