using Robotics.Mobile.Core.Bluetooth.LE;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FitSenseApp.Pages
{
    public partial class DeviceList : ContentPage
    {
        IAdapter adapter;
        ObservableCollection<IDevice> devices;

        public DeviceList(IAdapter adapter)
        {
            InitializeComponent();
            this.adapter = adapter;
            this.devices = new ObservableCollection<IDevice>();
            listView.ItemsSource = devices;

            adapter.DeviceDiscovered += (object sender, DeviceDiscoveredEventArgs e) =>
            {
                if (!devices.Any(d => d.ID == e.Device.ID))
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        devices.Add(e.Device);
                    });
                }
            };

            adapter.ScanTimeoutElapsed += (sender, e) =>
            {
                adapter.StopScanningForDevices(); // not sure why it doesn't stop already, if the timeout elapses... or is this a fake timeout we made?
                Device.BeginInvokeOnMainThread(() =>
                {
                    DisplayAlert("Timeout", "Bluetooth scan timeout elapsed", "OK");
                });
            };

            ScanAllButton.Clicked += (sender, e) => {
                StartScanning();
            };

            ScanHrmButton.Clicked += (sender, e) => {
                StartScanning(0x180D.UuidFromPartial());
            };
        }

        public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (((ListView)sender).SelectedItem == null)
            {
                return;
            }
            Debug.WriteLine(" xxxxxxxxxxxx  OnItemSelected " + e.SelectedItem.ToString());
            StopScanning();

            var device = e.SelectedItem as IDevice;
            var servicePage = new ServiceList(adapter, device);
            //load services on the next page
            Navigation.PushAsync(servicePage);
            Debug.WriteLine($"connected with : {device.Name}");
            ((ListView)sender).SelectedItem = null; // clear selection
        }

        void StartScanning()
        {
            StartScanning(Guid.Empty);
        }

        void StartScanning(Guid forService)
        {
            if (adapter.IsScanning)
            {
                adapter.StopScanningForDevices();
                Debug.WriteLine("adapter.StopScanningForDevices()");
            }
            else
            {
                devices.Clear();
                adapter.StartScanningForDevices(forService);
                Debug.WriteLine("adapter.StartScanningForDevices(" + forService + ")");
            }
        }

        void StopScanning()
        {
            // stop scanning
            new Task(() => {
                if (adapter.IsScanning)
                {
                    Debug.WriteLine("Still scanning, stopping the scan");
                    adapter.StopScanningForDevices();
                }
            }).Start();
        }
    }
}
