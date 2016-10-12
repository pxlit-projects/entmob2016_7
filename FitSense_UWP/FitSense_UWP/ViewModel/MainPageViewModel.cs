using FitSense.Model;
using FitSense_UWP.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitSense_UWP.Extensions;

namespace FitSense_UWP.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IFitDataService fitDataService;

        private ObservableCollection<Distance> distances;
        private Distance selectedDistance;

        public ObservableCollection<Distance> Distances
        {
            get { return distances; }
            set
            {
                distances = value;
                RaisePropertyChanged("Distances");
            }
        }

        public Distance SelectedDistance
        {
            get { return selectedDistance; }
            set
            {
                selectedDistance = value;
                RaisePropertyChanged("SelectedDistance");
            }
        }

        public MainPageViewModel(IFitDataService dataService)
        {
            this.fitDataService = dataService;
            distances = fitDataService.GetAllRecords().ToObservableCollection();
        }

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
