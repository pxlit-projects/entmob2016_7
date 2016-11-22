using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robotics.Mobile.Core.Bluetooth.LE;
using FitSense.Helpers;
using FitSense.Constants;

namespace FitSense.Models
{
    public class KeyService : SensorService
    {
        public delegate void ValueChanged(object sender, ValueChangedEventArgs<SensorKeys> args);
        public event ValueChanged OnKeyPushed;

        private EventHandler<CharacteristicReadEventArgs> valueUpdatedHandler;

        private SensorKeys oldValue;

        public KeyService(IService service) : base(service)
        {
        }

        public new void StartReadData(int interval)
        {
            valueUpdatedHandler = (s, e) =>
            {
                SensorKeys newValue = GetKeyValue();
                if (newValue != SensorKeys.NONE && oldValue == SensorKeys.NONE)
                {
                    ValueChangedEventArgs<SensorKeys> args = new ValueChangedEventArgs<SensorKeys>();
                    args.NewValue = newValue;
                    oldValue = newValue;
                    OnKeyPushed?.Invoke(this, args);
                }
                else if(newValue == SensorKeys.NONE)
                {
                     dataCharacteristic.ValueUpdated += valueUpdatedHandler;
                     oldValue = newValue;
                }
            };
            base.StartReadData(interval);
        }

        private new void stopReadData()
        {
            base.stopReadData();
            dataCharacteristic.ValueUpdated -= valueUpdatedHandler;
        }

        private SensorKeys GetKeyValue()
        {
            byte raw = dataCharacteristic.Value[0];
            if(raw == 1)
            {
                return SensorKeys.LEFTKEY;
            }
            else if(raw == 2)
            {
                return SensorKeys.RIGHTKEY;
            }
            else if(raw == 3)
            {
                return SensorKeys.BOTHKEYS;
            }
            else if(raw == 4)
            {
                return SensorKeys.REEDRELAY;
            }
            else
            {
                return SensorKeys.NONE;
            }
        }

        public new void SetEnabled(bool value) { }
    }
}
