using FitSense.Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitSense.Constants;

namespace test.fitsense.mocks
{
    class ConnectivityMock : IConnectivity
    {
        public ConnectionStatus NetworkStatus
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ConnectionStatus CheckNetworkStatus()
        {
            throw new NotImplementedException();
        }
    }
}
