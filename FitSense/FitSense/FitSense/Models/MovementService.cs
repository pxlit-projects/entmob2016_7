using Robotics.Mobile.Core.Bluetooth.LE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSense.Models
{
    class MovementService
    {
        private IService service;
        private ICharacteristic dataCharacteristic;
        private ICharacteristic switchCharacteristic;
        private ICharacteristic periodCharacteristic;
        
        public MovementService(IService movementService)
        {
            this.service = movementService;
            foreach (var character in movementService.Characteristics)
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





    }
}
