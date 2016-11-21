using Robotics.Mobile.Core.Bluetooth.LE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.fitsense.mocks
{
    class AdapterMock : IAdapter
    {
        private List<IDevice> connectedDevices;
        public IList<IDevice> ConnectedDevices
        {
            get
            {
                return connectedDevices;
            }
        }

        private List<IDevice> discoveredDevices;
        public IList<IDevice> DiscoveredDevices
        {
            get
            {
                return discoveredDevices;
            }
        }

        public bool IsScanning { get; private set; }

        public event EventHandler<DeviceConnectionEventArgs> DeviceConnected;
        public event EventHandler<DeviceConnectionEventArgs> DeviceDisconnected;
        public event EventHandler<DeviceDiscoveredEventArgs> DeviceDiscovered;
        public event EventHandler ScanTimeoutElapsed;

        public void ConnectToDevice(IDevice device)
        {
            connectedDevices.Add(device);
            var args = new DeviceConnectionEventArgs();
            args.Device = device;
            DeviceConnected?.Invoke(this, args);
        }

        public void DisconnectDevice(IDevice device)
        {
            connectedDevices.Remove(device);
            var args = new DeviceConnectionEventArgs();
            args.Device = device;
            DeviceDisconnected?.Invoke(this, args);
        }

        public void StartScanningForDevices()
        {
            IsScanning = true;
        }

        public void StartScanningForDevices(Guid serviceUuid)
        {
            IsScanning = true;
        }

        public void StopScanningForDevices()
        {
            IsScanning = false;
        }

        public void discoverDevice(IDevice device)
        {
            var args = new DeviceDiscoveredEventArgs();
            args.Device = device;
            DeviceDiscovered?.Invoke(this, args);
        }
    }
}
