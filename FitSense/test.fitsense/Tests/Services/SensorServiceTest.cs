using FitSense.Models;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Robotics.Mobile.Core.Bluetooth.LE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.fitsense.mocks.LibraryMocks;

namespace test.fitsense.Tests.Services
{
    [TestClass]
    public class SensorServiceTest
    {
        private CharacteristicMock dataChar;
        private CharacteristicMock switchChar;
        private CharacteristicMock periodChar;
        private ServiceMock service;

        [TestInitialize]
        public void Init()
        {
            dataChar = new CharacteristicMock();
            dataChar.ID = new Guid(0xaa01, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

            switchChar = new CharacteristicMock();
            switchChar.ID = new Guid(0xaa02, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

            periodChar = new CharacteristicMock();
            periodChar.ID = new Guid(0xaa03, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

            service = new ServiceMock();
            service.Characteristics = new List<ICharacteristic>()
            {
                dataChar, switchChar, periodChar
            };
        }

        [TestMethod]
        public void SetEnabledTest()
        {

            SensorService sensor = new SensorService(service);

            sensor.SetEnabled(true);

            var onBytes = new byte[] { 0x01 };
            var offBytes = new byte[] { 0x00 };

            Assert.IsTrue(switchChar.IsWritten);
            Assert.AreEqual(onBytes[0], switchChar.Written[0]);

            switchChar.IsWritten = false;

            sensor.SetEnabled(true);

            Assert.IsFalse(switchChar.IsWritten);

            sensor.SetEnabled(false);

            Assert.IsTrue(switchChar.IsWritten);
            Assert.AreEqual(offBytes[0], switchChar.Written[0]);

            switchChar.IsWritten = false;

            sensor.SetEnabled(false);

            Assert.IsFalse(switchChar.IsWritten);
        }

    }
}
