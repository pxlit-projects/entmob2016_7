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
    public class PointsConverterTest
    {

        [TestMethod]
        public void ConvertTest()
        {
            var converter = new PointsConverter();

            Assert.AreEqual("Points: 10",
                                converter.Convert(10, null, null, null));
        }


    }
}
