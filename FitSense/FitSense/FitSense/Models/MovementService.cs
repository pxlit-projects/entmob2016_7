using FitSense.Helpers;
using Robotics.Mobile.Core.Bluetooth.LE;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace FitSense.Models
{
    class MovementService : SensorService
    {
        public delegate void ValueChanged(object sender, ValueChangedEventArgs<Vector3> args);
        public event ValueChanged OnValueChanged;

        private EventHandler<CharacteristicReadEventArgs> valueUpdatedHandler;

        private Vector3 oldVector;

        public MovementService(IService movementService) : base(movementService)
        {
            //SetEnabled(true);
        }

        public new void StartReadData(int interval)
        {
            valueUpdatedHandler = (s, e) =>
            {
                Vector3 newVect = GetGyroValue();
                ValueChangedEventArgs<Vector3> args = new ValueChangedEventArgs<Vector3>();
                args.NewValue = newVect;
                oldVector = newVect;
                OnValueChanged?.Invoke(this, args);
            };
            dataCharacteristic.ValueUpdated += valueUpdatedHandler;
            base.StartReadData(interval);
        }

        private new void stopReadData()
        {
            base.stopReadData();
            dataCharacteristic.ValueUpdated -= valueUpdatedHandler;
        }

        private Vector3 GetGyroValue()
        {
            //byte[] raw = dataCharacteristic.Value;
            //await dataCharacteristic.ReadAsync();
            byte[] raw = dataCharacteristic.Value;
            if (raw == null)
            {
                Debug.WriteLine("value not found.");
                return new Vector3();
            }

            short valX = BitConverter.ToInt16(raw, 0);
            short valY = BitConverter.ToInt16(raw, 2);
            short valZ = BitConverter.ToInt16(raw, 4);

            //Debug.WriteLine(raw[0]);
            //Debug.WriteLine(raw[1]);
            //Debug.WriteLine(raw[2]);
            //Debug.WriteLine(raw[3]);
            //Debug.WriteLine(raw[4]);
            //Debug.WriteLine(raw[5]);
            //Debug.WriteLine("X: " + valX + "  Y: " + valY + "  Z: " + valZ);

            float fValX = sensorMpu9250GyroConvert(valX);
            float fValY = sensorMpu9250GyroConvert(valY);
            float fValZ = sensorMpu9250GyroConvert(valZ);

            Debug.WriteLine("X: " + fValX + "  Y: " + fValY + "  Z: " + fValZ);

            return new Vector3(fValX, fValY, fValZ);
        }

        private float sensorMpu9250GyroConvert(short data)
        {
            //-- calculate rotation, unit deg/s, range -250, +250
            return (data) / (65536 / 500.0f);
        }

        public new void SetEnabled(bool value)
        {
            if (value)
            {
                if (!IsOn)
                {
                    //Enable sensor
                    switchCharacteristic.Write(new byte[] { 0x07, 0x00 });
                    periodCharacteristic.Write(new byte[] { 0x04 });
                    IsOn = true;
                }
            }
            else
            {
                if (IsOn)
                {
                    //Disable sensor
                    switchCharacteristic.Write(new byte[] { 0x00, 0x00 });
                    IsOn = false;
                }
            }

        }

    }
}
