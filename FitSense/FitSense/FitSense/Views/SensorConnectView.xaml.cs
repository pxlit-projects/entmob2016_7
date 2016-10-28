using FitSense.ViewModels;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FitSense.Views
{
    public partial class SensorConnectView : NavigationPage
    {
        //private SensorConnectViewModel viewModel;

        public SensorConnectView()
        {
            InitializeComponent();
            //viewModel = ServiceLocator.Current.GetInstance<SensorConnectViewModel>();
        }
    }
}
