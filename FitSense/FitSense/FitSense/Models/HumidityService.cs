using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robotics.Mobile.Core.Bluetooth.LE;
using FitSense.Helpers;

namespace FitSense.Models
{
    class HumidityService : SensorService
    {
        public delegate void ValueChanged(object sender, ValueChangedEventArgs<float> args);
        public event ValueChanged OnTempValueChanged;
        public event ValueChanged OnHumValueChanged;

        private EventHandler<CharacteristicReadEventArgs> valueUpdatedHandler;

        private float oldTemp;
        private float oldHum;

        public HumidityService(IService service) : base(service)
        {
            
        }

        public new void StartReadData(int interval)
        {
            valueUpdatedHandler = (s, e) =>
            {
                float newTemp = GetTemperature();
                float newHum = GetHumidity();

                ValueChangedEventArgs<float> tempArgs = new ValueChangedEventArgs<float>();
                tempArgs.NewValue = newTemp;
                tempArgs.OldValue = oldTemp;
                oldTemp = newTemp;
                OnTempValueChanged(this, tempArgs);

                ValueChangedEventArgs<float> humArgs = new ValueChangedEventArgs<float>();
                humArgs.NewValue = newHum;
                humArgs.OldValue = oldHum;
                oldHum = newHum;
                OnHumValueChanged(this, humArgs);
            };
            dataCharacteristic.ValueUpdated += valueUpdatedHandler;
            base.StartReadData(interval);
        }

        private new void stopReadData()
        {
            base.stopReadData();
            dataCharacteristic.ValueUpdated -= valueUpdatedHandler;
        }

        private float GetTemperature()
        {
            byte[] raw = dataCharacteristic.Value;
            int rawTemp = BitConverter.ToInt32(raw, 0);
            return ConvertTemp(rawTemp);
        }

        private float GetHumidity()
        {
            byte[] raw = dataCharacteristic.Value;
            int rawHum = BitConverter.ToInt32(raw, 2);
            return ConvertHumidity(rawHum);
        }
        
        private float ConvertTemp(int rawTemp)
        {
            return ((float)rawTemp / 65536) * 165 - 40;
        }

        private float ConvertHumidity(int rawHum)
        {
            return (rawHum / 65536f) * 100;
        }
    }
}
