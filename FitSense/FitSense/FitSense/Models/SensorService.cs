using Robotics.Mobile.Core.Bluetooth.LE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSense.Models
{
    class SensorService
    {

        private IService service;
        protected ICharacteristic dataCharacteristic;
        protected ICharacteristic switchCharacteristic;
        protected ICharacteristic periodCharacteristic;

        public bool IsOn { get; private set; }

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

        public void SetEnabled(bool value)
        {
            if (value)
            {
                if (!IsOn)
                {
                    //Enable sensor
                    //switchCharacteristic.Write()
                }
            }
            else
            {
                if (IsOn)
                {
                    //Disable sensor
                    switchCharacteristic.Write(new byte[] { 0x00 });
                }
            }
            
        }


    }
}
