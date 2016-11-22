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
    class RepsConverterTest
    {

        [TestMethod]
        public void ConvertTest()
        {
            var converter = new RepsConverter();

            Assert.AreEqual("Reps: 70",
                                converter.Convert(70, null, null, null));

        }

    }
}
