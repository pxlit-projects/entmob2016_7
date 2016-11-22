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
    public class MaxTimeConverterTest
    {

        [TestMethod]
        public void ConvertTest()
        {
            var converter = new MaxTimeConverter();

            Assert.AreEqual("Max Time: 1 Minute and 10 Seconds",
                                converter.Convert(70, null, null, null));

            Assert.AreEqual("Max Time: 2 Minutes and 10 Seconds",
                                converter.Convert(130, null, null, null));

            Assert.AreEqual("Max Time: 1 Minute",
                                converter.Convert(60, null, null, null));

            Assert.AreEqual("Max Time: 10 Seconds",
                                converter.Convert(10, null, null, null));
        }








    }
}
