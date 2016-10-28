using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Net;
using FitSense.Dependencies;
using FitSense.Constants;
using Xamarin.Forms;
using FitSense.Droid.Services;

[assembly: Dependency(typeof(Connectivity_Android))]
namespace FitSense.Droid.Services
{
    class Connectivity_Android : IConnectivity
    {

        public ConnectionStatus NetworkStatus
        {
            get;
            private set;
        }

        public Connectivity_Android()
        {
            CheckNetworkStatus();
        }

        public ConnectionStatus CheckNetworkStatus()
        {
            
            ConnectivityManager manager = 
                (ConnectivityManager) Android.App.Application.Context.GetSystemService(Context.ConnectivityService);

            NetworkInfo activeConnection = manager.ActiveNetworkInfo;
            
            if(activeConnection != null && activeConnection.IsConnected)
            {
                if (manager.GetNetworkInfo(ConnectivityType.Wifi).IsConnected)
                {
                    NetworkStatus = ConnectionStatus.ReachableViaWiFiNetwork;
                }
                else
                {
                    NetworkStatus = ConnectionStatus.ReachableViaRoamingNetwork;
                }
            }
            else
            {
                NetworkStatus = ConnectionStatus.NotReachable;
            }


            return NetworkStatus;
        }

        //EXTRA : Thread maken die de NerworkStatus refreshed elke x seconden.
    }
}