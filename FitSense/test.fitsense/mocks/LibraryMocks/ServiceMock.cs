using Robotics.Mobile.Core.Bluetooth.LE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.fitsense.mocks.LibraryMocks
{
    class ServiceMock : IService
    {
        public IList<ICharacteristic> Characteristics
        {
            get; set;
        }

        public Guid ID
        {
            get; set;
        }

        public bool IsPrimary
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public event EventHandler CharacteristicsDiscovered;

        public void DiscoverCharacteristics()
        {
            if(Characteristics != null && Characteristics.Count > 0)
            {
                CharacteristicsDiscovered(this, new EventArgs());
            }
        }

        public ICharacteristic FindCharacteristic(KnownCharacteristic characteristic)
        {
            return Characteristics.First<ICharacteristic>((c) => c.ID == characteristic.ID);
        }
    }
}
