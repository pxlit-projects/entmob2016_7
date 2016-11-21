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
        private IDataService userDataService;
        private INavigationService navigationService;

        public RelayCommand CancelSet { get; private set; }
        public RelayCommand StartSet { get; private set; }

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

        public ActiveSetViewModel(INavigationService navigationService, IDataService userDataService)
        {
            this.userDataService = userDataService;
            this.navigationService = navigationService;

            InitializeMessages();
            InitializeCommands();
            StartButtonText = "Start";
        }

        private void InitializeCommands()
        {
            CancelSet = new RelayCommand(() =>
            {
                FinishedSet();
            });

            StartSet = new RelayCommand(async () =>
            {
                if(TimeLeft > 0)
                {
                    StartButtonEnabled = false;
                    while (TimeLeft > 0)
                    {
                        // wait 1000 miliseconds in a different thread
                        await CountDown(1000).ContinueWith((antecedent) =>
                        {
                            // we are on the main thread again, time to update te ui!
                            TimeLeft--;
                            if (TimeLeft <= 0)
                            {
                                StartButtonText = "Finished! Continue";
                                StartButtonEnabled = true;
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
            MessengerInstance.Register<Set>(this, Constants.Messages.SetUpdated, (sender) =>
            {
                TimeLeft = sender.MaxTime;
                RepsLeft = sender.Reps;
            });
        }
    
        private async void FinishedSet()
        {
            await navigationService.PopToRootAsync().ContinueWith((antecedent) =>
            {
                //MessengerInstance.Send(Set, Messages.SetUpdated);
            });
        }
    }
}