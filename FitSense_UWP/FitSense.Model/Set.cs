using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace FitSense.Model
{
    public class Set : SensorModel, INotifyPropertyChanged
    {
        public int Reps { get; set; }
        public int ExerciseID { get; set; }
        public int Points { get; set; }
        public int MaxTime { get; set; }
        public List<CompletedSet> CompletedSets { get; set; }
        private Visibility showCompletedSets { get; set; }
        public Visibility ShowCompletedSets {
            get
            {
                return showCompletedSets;
            }
            set
            {
                showCompletedSets = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("ShowCompletedSets"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
