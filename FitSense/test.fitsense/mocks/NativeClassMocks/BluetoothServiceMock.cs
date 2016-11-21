using FitSense.Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.fitsense.mocks
{
    class BluetoothServiceMock : IBluetoothService
    {
        public global::Robotics.Mobile.Core.Bluetooth.LE.IAdapter Adapter
        {
            get
            {
                return 
            }
        }

        public void RequestTurnOn()
        {
            throw new NotImplementedException();
        }
    }
}
