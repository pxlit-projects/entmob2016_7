using fitsense.models;
using FitSense.Dependencies;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            InitializeCommands();
            InitializeMessages();
        }

        private void LoadData()
        {
            
            //Exercises = userDataService.GetAllCategories().ToObservableCollection();
            SetViews = new ObservableCollection<SetViewModel>();
            if (Exercise != null)
            {
                List<Set> sets = userDataService.GetSetsFromExercise(Exercise);
                foreach (Set set in sets)
                {
                    SetViews.Add(new SetViewModel(navigationService, userDataService)
                    {
                        Exercise = Exercise,
                        Set = set
                    });
                }
            }
        }

        private void InitializeCommands()
        {
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