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

        public MovementService MovementService { get; set; }


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

                connectedDevice.DiscoverServices();
            };
        }

        /// <summary>
        /// http://processors.wiki.ti.com/index.php/CC2650_SensorTag_User's_Guide
        /// </summary>
        private void InitializeSensors()
        {
            foreach (var service in deviceServices)
            {
                var characteristic = service.Characteristics;

                //Debug.WriteLine(service.ID.PartialFromUuid());
                //foreach(var c in service.Characteristics)
                //{
                //    Debug.WriteLine(" --  " + c.ID.PartialFromUuid() + "   =   " + c.Name); 
                //}

                if(service.ID.PartialFromUuid() == "0xaa00")
                {
                    Debug.WriteLine("Found infrared service.");
                }
                else if (service.ID.PartialFromUuid() == "0xaa80")
                {
                    Debug.WriteLine("Found Accelerometer/Gyroscope service.");
                    MovementService = new MovementService(service);
                }
                else if (service.ID.PartialFromUuid() == "0xaa20")
                {
                    Debug.WriteLine("Found humidity service.");
                }
                else if (service.ID.PartialFromUuid() == "0xaa30")
                {
                    Debug.WriteLine("Found magneto service.");
                }


            }
        }
    }
}
