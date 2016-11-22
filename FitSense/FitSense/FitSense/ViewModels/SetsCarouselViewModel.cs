using fitsense.models;
using FitSense.Dependencies;
using FitSense.Extensions;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FitSense.ViewModels
{
    public class SetsCarouselViewModel : ViewModelBase
    {
        private IDataService userDataService;
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

        public Task Initialization { get; private set; }

        public SetsCarouselViewModel(INavigationService navigationService, IDataService userDataService)
        {
            this.userDataService = userDataService;
            this.navigationService = navigationService;

            Initialization = InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            InitializeMessages();
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            var result = await (userDataService.GetSetViewModelsFromExerciseAsync(Exercise, navigationService));
            SetViews = result.ToObservableCollection();
        }

        private void InitializeMessages()
        {
            MessengerInstance.Register<Exercise>(this, Constants.Messages.ExerciseUpdated, async (sender) =>
            {
                Exercise = sender;
                await LoadDataAsync();
            });
        }
    }
}