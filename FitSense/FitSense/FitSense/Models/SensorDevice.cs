using FitSense.Dependencies;
using Robotics.Mobile.Core.Bluetooth.LE;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FitSense.Models
{
    class SensorDevice
    {
        private IDevice connectedDevice;
        private IAdapter adapter;
        private List<IService> deviceServices;


        public IDevice ConnectedDevice
        {
            get
            {
                return connectedDevice;
            }
            set
            {
                ConnectDevice(value);
            }
        }

        public SensorDevice()
        {
            this.adapter = DependencyService.Get<IBluetoothService>().Adapter;

            InitializeEvents();
        }

        private void ConnectDevice(IDevice device)
        {
            adapter.ConnectToDevice(device);
        }

        private void DisconnectDevice()
        {
            if(connectedDevice != null)
            {
                adapter.DisconnectDevice(connectedDevice);
            }
        }

        private void InitializeEvents()
        {
            adapter.DeviceConnected += (object sender, DeviceConnectionEventArgs args) =>
            {
                connectedDevice = args.Device;

                connectedDevice.ServicesDiscovered += (object se, EventArgs arg) =>
                {
                    deviceServices = (List<IService>)connectedDevice.Services;
                    InitializeSensors();
                };
            };
        }

        private void InitializeSensors()
        {
            foreach (var service in deviceServices)
            {
                var characteristic = service.Characteristics;

                if(service.ID == 0xAA00.UuidFromPartial())
                {
                    Debug.WriteLine("Found infrared service.");
                }
                else if(service.ID == 0xAA10.UuidFromPartial())
                {
                    Debug.WriteLine("Found Accelerometer service.");
                }
                else if(service.ID == 0xAA20.UuidFromPartial())
                {
                    Debug.WriteLine("Found humidity service.");
                }
                else if (service.ID == 0xAA30.UuidFromPartial())
                {
                    Debug.WriteLine("Found magneto service.");
                }





            }
        }
    }
}
