using FitSense.Dependencies;
using Robotics.Mobile.Core.Bluetooth.LE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.fitsense.mocks
{
    class BluetoothServiceMock : IBluetoothService
    {
        private IAdapter adapter;

        public global::Robotics.Mobile.Core.Bluetooth.LE.IAdapter Adapter
        {
            get
            {
                if (adapter == null)
                    adapter = new AdapterMock();
                return adapter;
            }
        }

        public void RequestTurnOn()
        {
            throw new NotImplementedException();
        }
    }
}
