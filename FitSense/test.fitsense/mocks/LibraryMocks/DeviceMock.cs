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
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public object NativeDevice
        {
            get; set;
        }

        public int Rssi
        {
            get; set;
        }

        public IList<IService> Services
        {
            get; set;
        }

        public DeviceState State
        {
            get; set;
        }

        public event EventHandler ServicesDiscovered;

        public void DiscoverServices()
        {
            if(Services != null && Services.Count > 0)
            {
                ServicesDiscovered?.Invoke(this, new EventArgs());
            }
        }
    }
}
