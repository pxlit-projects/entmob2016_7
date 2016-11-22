using fitsense.models;
using FitSense.Dependencies;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using FitSense.Constants;
using System.Threading.Tasks;
using System;

namespace FitSense.ViewModels
{
    public class ActiveSetViewModel : ViewModelBase
    {
        private IDataService dataService;
        private INavigationService navigationService;

        public RelayCommand CancelSet { get; private set; }
        public RelayCommand StartSet { get; private set; }
        public RelayCommand RepButtonCommand { get; private set; }

        public Set ActiveSet { get; private set; }
        public bool IsFinished { get; set; }

        private string startButtonText;
        public string StartButtonText
        {
            get { return startButtonText; }
            private set
            {
                startButtonText = value;
                RaisePropertyChanged("StartButtonText");
            }
        }

        private bool startButtonEnabled;
        public bool StartButtonEnabled
        {
            get { return startButtonEnabled; }
            private set
            {
                startButtonEnabled = value;
                RaisePropertyChanged("StartButtonEnabled");
            }
        }

        private string repButtonText;
        public string RepButtonText
        {
            get { return repButtonText; }
            set
            {
                repButtonText = value;
                RaisePropertyChanged("RepButtonText");
            }
        }

        private bool repButtonEnabled;
        public bool RepButtonEnabled
        {
            get { return repButtonEnabled; }
            set
            {
                repButtonEnabled = value;
                RaisePropertyChanged("RepButtonEnabled");
            }
        }


        //private Timer timer;

        private int timeLeft;
        public int TimeLeft
        {
            get { return timeLeft; }
            private set
            {
                int oldValue = timeLeft;
                timeLeft = value;
                RaisePropertyChanged("TimeLeft");
            }
        }
        private int repsLeft;
        public int RepsLeft
        {
            get { return repsLeft; }
            private set
            {
                int oldValue = repsLeft;
                repsLeft = value;
                RaisePropertyChanged("RepsLeft");
            }
        }

        public ActiveSetViewModel(INavigationService navigationService, IDataService dataService)
        {
            this.dataService = dataService;
            this.navigationService = navigationService;

            InitializeMessages();
            InitializeCommands();
            StartButtonText = "Start";
            RepButtonText = "Do 1";
            repButtonEnabled = false;
            IsFinished = false;
        }

        private void InitializeCommands()
        {
            CancelSet = new RelayCommand(() =>
            {
                FinishedSet();
            });

            RepButtonCommand = new RelayCommand(() =>
            {
                if(RepsLeft > 0)
                    RepsLeft--;
            });

            StartSet = new RelayCommand(async () =>
            {
                //if(TimeLeft > 0)
                if (!IsFinished)
                {
                    StartButtonEnabled = false;
                    RepButtonEnabled = true;
                    while (TimeLeft > 0 && RepButtonEnabled)
                    {
                        // wait 1000 miliseconds in a different thread
                        await CountDown(1000).ContinueWith((antecedent) =>
                        {
                            // we are on the main thread again, time to update te ui!
                            TimeLeft--;
                            if(RepsLeft == 0)
                            {
                                RepButtonEnabled = false;
                                StartButtonText = "Finished! Well done";
                                StartButtonEnabled = true;
                                IsFinished = true;
                            }
                            if (TimeLeft <= 0)
                            {
                                //StartButtonText = "Finished! Continue";
                                StartButtonText = "Game Over";
                                StartButtonEnabled = true;
                                IsFinished = true;
                            }
                        });//add stuff to go to ui thread);
                    }
                }
                else
                {
                    FinishedSet();
                }
            });
        }

        private async Task CountDown(int milisec)
        {
            await Task.Delay(milisec);
        }

        private void InitializeMessages()
        {
            MessengerInstance.Register<Set>(this, Messages.SetUpdated, (sender) =>
            {
                this.ActiveSet = sender;
                TimeLeft = sender.MaxTime;
                RepsLeft = sender.Reps;
            });
        }
    
        private async void FinishedSet()
        {
            await navigationService.PopToRootAsync().ContinueWith((antecedent) =>
            {
                if(IsFinished)
                {
                    CompletedSet completedSet = new CompletedSet()
                    {
                        Duration = ActiveSet.MaxTime - TimeLeft,
                        SetID = ActiveSet.SetID,
                        Time = FormatTime(DateTime.Now),
                        UserID = dataService.LoggedInUser.UserID
                    };
                    dataService.SendCompletedSet(completedSet);
                    
                }
            });
        }

        private long FormatTime(DateTime now)
        {
            long value = 0;
            value = (value + now.Day) * 100;
            value = (value + now.Month) * 100;
            value = (value + (now.Year % 100)) * 100;
            value = (value + now.Hour) * 100;
            value = (value + now.Minute) * 100;
            value = (value + now.Second) * 100;
            return value;
        }
    }
}