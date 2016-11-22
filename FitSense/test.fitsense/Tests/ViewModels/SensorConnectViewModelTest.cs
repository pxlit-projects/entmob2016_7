using FitSense.Dependencies;
using FitSense.Models;
using Microsoft.Practices.ServiceLocation;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Robotics.Mobile.Core.Bluetooth.LE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.fitsense.mocks;

namespace test.fitsense
{
    [TestClass]
    public class SensorConnectViewModelTest
    {
        private ViewModelLocatorMock locatorMock;
        private List<IDevice> devices;

        [TestInitialize]
        public void init()
        {
            locatorMock = new ViewModelLocatorMock();
            devices = new List<IDevice>()
            {
                new DeviceMock()
                {
                    ID = Guid.NewGuid()
                },
                new DeviceMock()
                {
                    ID = Guid.NewGuid()
                }
            };
        }

        [TestMethod]
        public void StartScanTest()
        {
            var viewmodel = locatorMock.Connect;
            var bluetooth = ServiceLocator.Current.GetInstance<IBluetoothService>() as BluetoothServiceMock;
            var adapter = bluetooth.Adapter as AdapterMock;

            viewmodel.Devices.Add(devices[0]);

            Assert.IsNotNull(viewmodel.ScanCommand);

            viewmodel.ScanCommand.Execute(null);

            Assert.AreEqual(0, viewmodel.Devices.Count);
            Assert.IsTrue(adapter.IsScanning);
        }

        [TestMethod]
        public void DevicesDiscoveredTest()
        {
            var viewmodel = locatorMock.Connect;
            var bluetooth = ServiceLocator.Current.GetInstance<IBluetoothService>() as BluetoothServiceMock;
            var adapter = bluetooth.Adapter as AdapterMock;
            
            adapter.DiscoverDevice(devices[0]);
            adapter.DiscoverDevice(devices[1]);

            Assert.AreEqual(devices.Count, viewmodel.Devices.Count);

            Assert.AreEqual(devices[0].ID, viewmodel.Devices[0].ID);
            Assert.AreEqual(devices[1].ID, viewmodel.Devices[1].ID);
        }

        [TestMethod]
        public void ItemSelectedCommandTest()
        {
            var viewmodel = locatorMock.Connect;
            var bluetooth = ServiceLocator.Current.GetInstance<IBluetoothService>() as BluetoothServiceMock;
            var adapter = bluetooth.Adapter as AdapterMock;
            var navigation = ServiceLocator.Current.GetInstance<INavigationService>() as NavigationServiceMock;
            adapter.StartScanningForDevices();
            
            Assert.IsNotNull(viewmodel.ItemSelectedCommand);

            viewmodel.ItemSelectedCommand.Execute(devices[0]);

            var sensorDevice = ServiceLocator.Current.GetInstance<SensorDevice>();

            Assert.AreEqual(devices[0].ID, sensorDevice.ConnectedDevice.ID);

            Assert.IsFalse(adapter.IsScanning);

            Assert.IsTrue(navigation.Poped);
        }

        [TestMethod]
        public void ScanTimeElapsedTest()
        {
            var viewmodel = locatorMock.Connect;
            var bluetooth = ServiceLocator.Current.GetInstance<IBluetoothService>() as BluetoothServiceMock;
            var adapter = bluetooth.Adapter as AdapterMock;

            viewmodel.ScanCommand.Execute(null);

            Assert.IsTrue(adapter.IsScanning);

            adapter.ThrowScanTimeElapsedEvent();

            Assert.IsFalse(adapter.IsScanning);
        }

    }
}
