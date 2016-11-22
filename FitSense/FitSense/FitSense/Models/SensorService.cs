using Robotics.Mobile.Core.Bluetooth.LE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FitSense.Models
{
    public class SensorService
    {

        protected IService service;
        protected ICharacteristic dataCharacteristic;
        protected ICharacteristic switchCharacteristic;
        protected ICharacteristic periodCharacteristic;

        public bool IsOn { get; protected set; }
        public bool IsUpdating { get; protected set; }

        public SensorService(IService service)
        {
            this.service = service;
            foreach (var character in service.Characteristics)
            {
                if (character.ID.PartialFromUuid().EndsWith("1"))
                {
                    dataCharacteristic = character;
                }
                else if (character.ID.PartialFromUuid().EndsWith("2"))
                {
                    switchCharacteristic = character;
                }
                else if (character.ID.PartialFromUuid().EndsWith("3"))
                {
                    periodCharacteristic = character;
                }
            }
            
        }

        public void StartReadData(int interval)
        {
            TimeSpan time = new TimeSpan(0, 0, 0, 0, interval);
            IsUpdating = true;
            Device.StartTimer(time, () =>
            {
                dataCharacteristic.ReadAsync();
                return IsUpdating;
            });
        }

        public void stopReadData()
        {
            IsUpdating = false;
        }

        public void SetEnabled(bool value)
        {
            if (value)
            {
                if (!IsOn)
                {
                    //Enable sensor
                    switchCharacteristic.Write(new byte[] { 0x01 });
                    IsOn = true;
                }
            }
            else
            {
                if (IsOn)
                {
                    //Disable sensor
                    switchCharacteristic.Write(new byte[] { 0x00 });
                    IsOn = false;
                }
            }

            
            
        }
        
    }
}
