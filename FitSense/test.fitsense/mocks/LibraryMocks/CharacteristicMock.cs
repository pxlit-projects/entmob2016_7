using Robotics.Mobile.Core.Bluetooth.LE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.fitsense.mocks.LibraryMocks
{
    class CharacteristicMock : ICharacteristic
    {
        public bool CanRead
        {
            get; set;
        }

        public bool CanUpdate
        {
            get; set;
        }

        public bool CanWrite
        {
            get; set;
        }

        public IList<IDescriptor> Descriptors
        {
            get; set;
        }

        public Guid ID
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public object NativeCharacteristic
        {
            get; set;
        }

        public CharacteristicPropertyType Properties
        {
            get; set;
        }

        public string StringValue
        {
            get; set;
        }

        public string Uuid
        {
            get; set;
        }

        public byte[] Value
        {
            get; set;
        }

        public byte[] Written { get; set; }
        public bool IsWritten { get; set; }


        public event EventHandler<CharacteristicReadEventArgs> ValueUpdated;

        public Task<ICharacteristic> ReadAsync()
        {
            var args = new CharacteristicReadEventArgs();
            args.Characteristic = this;
            ValueUpdated(this, args);
            return new Task<ICharacteristic>(() => this);
        }

        public void StartUpdates()
        {
            CanUpdate = true;
        }

        public void StopUpdates()
        {
            CanUpdate = false;
        }

        public void Write(byte[] data)
        {
            IsWritten = true;
            Written = data;
        }
    }
}
