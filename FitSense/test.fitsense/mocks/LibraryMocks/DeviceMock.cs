using Robotics.Mobile.Core.Bluetooth.LE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.fitsense.mocks
{
    class DeviceMock : IDevice
    {
        public Guid ID
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public object NativeDevice
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Rssi
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IList<IService> Services
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public DeviceState State
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public event EventHandler ServicesDiscovered;

        public void DiscoverServices()
        {
            throw new NotImplementedException();
        }
    }
}
