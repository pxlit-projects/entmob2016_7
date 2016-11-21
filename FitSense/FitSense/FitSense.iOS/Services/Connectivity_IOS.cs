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