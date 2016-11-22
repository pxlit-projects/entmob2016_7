using FitSense.Extensions;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.fitsense.Tests.Extensions
{
    [TestClass]
    public class ListExtensionsTest
    {

        public void ToObservableCollectionTest()
        {

            List<int> intList = new List<int>() { 10, 15, 16, 18 };

            ObservableCollection<int> intColl = ListExtensions.ToObservableCollection(intList);

            for (int i = 0; i < intList.Count; i++)
            {
                Assert.AreEqual(intList[i], intColl[i]);
            }

            List<string> stringList = new List<string>() { "Hello", "World" };

            ObservableCollection<string> stringColl = ListExtensions.ToObservableCollection(stringList);

            for (int i = 0; i < stringList.Count; i++)
            {
                Assert.AreEqual(stringList[i], stringColl[i]);
            }


        }

    }
}
