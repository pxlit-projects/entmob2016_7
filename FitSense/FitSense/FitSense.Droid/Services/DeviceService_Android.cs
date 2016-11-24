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
using FitSense.Dependencies;
using FitSense.Droid.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(DeviceService_Android))]
namespace FitSense.Droid.Services
{
    class DeviceService_Android : IDeviceService
    {
        public bool IsEmulator()
        {
            string fing = Build.Fingerprint;
            bool isEmulator = false;

            if(fing != null)
            {
                isEmulator = fing.Contains("vbox")
                            || fing.Contains("generic")
                            || fing.Contains("vsemu");
            }

            return isEmulator;
        }
    }
}