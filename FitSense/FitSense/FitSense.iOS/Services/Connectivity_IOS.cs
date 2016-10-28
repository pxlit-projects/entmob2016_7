using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using FitSense.Dependencies;
using FitSense.Constants;

[assembly: Xamarin.Forms.Dependency(typeof(IConnectivity))]
namespace FitSense.iOS.Services
{
    class Connectivity_IOS : IConnectivity
    {
        public ConnectionStatus NetworkStatus
        {
            get;
            private set;
        }

        public Connectivity_IOS() { }

        public ConnectionStatus CheckNetworkStatus()
        {
            NetworkStatus = null;
            return NetworkStatus;
        }
    }
}