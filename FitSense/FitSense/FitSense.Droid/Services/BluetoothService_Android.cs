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
using Robotics.Mobile.Core.Bluetooth.LE;
using FitSense.Droid.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(BluetoothService_Android))]
namespace FitSense.Droid.Services
{
    public class BluetoothService_Android : IBluetoothService
    {
        public Robotics.Mobile.Core.Bluetooth.LE.IAdapter Adapter
        {
            get; private set;
        }

        public BluetoothService_Android()
        {
            Adapter = new Robotics.Mobile.Core.Bluetooth.LE.Adapter();
        }
        
    }
}