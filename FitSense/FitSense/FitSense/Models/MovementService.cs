using Robotics.Mobile.Core.Bluetooth.LE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace FitSense.Models
{
    class MovementService : SensorService
    {
        private IService service;
        private ICharacteristic dataCharacteristic;
        private ICharacteristic switchCharacteristic;
        private ICharacteristic periodCharacteristic;
        
        public MovementService(IService movementService)
        {
            
        }

        public Vector3 GetGyroValue()
        {
            throw new NotImplementedException();
        }



    }
}
