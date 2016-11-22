using FitSense.Converters;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.fitsense.Tests.Converters
{
    [TestClass]
    public class DeviceNameConverterTest
    {
        [TestMethod]
        public void ConvertTest()
        {
            var converter = new DeviceNameConverter();

            Assert.AreEqual("Device", converter.Convert("Device", null, null, null));
            Assert.AreEqual("<un-named device>", converter.Convert("", null, null, null));
            Assert.AreEqual("<un-named device>", converter.Convert(10, null, null, null));
        }

        [TestMethod]
        public void ConvertBackTest()
        {
            var converter = new DeviceNameConverter();

            Assert.AreEqual("Device", converter.ConvertBack("Device", null, null, null));
        }




    }
}
