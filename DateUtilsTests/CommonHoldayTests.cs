using System;
using BlueArk;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DateUtilsTests
{
    [TestClass]
    public class CommonHoldayTests
    {
        [TestMethod]
        public void Get_Easter()
        {
            Int32 source1 = 2014;
            DateTime expected1 = new DateTime(2014, 4, 20);

            Int32 source2 = 2010;
            DateTime expected2 = new DateTime(2010, 4, 4);

            Int32 source3 = 2007;
            DateTime expected3 = new DateTime(2007, 4, 8);

            Int32 source4 = 1818;
            DateTime expected4 = new DateTime(1818, 3, 22);

            Int32 source5 = 2038;
            DateTime expected5 = new DateTime(2038, 4, 25);

            Assert.AreEqual(expected1, DateUtils.EasterSunday(source1));
            Assert.AreEqual(expected2, DateUtils.EasterSunday(source2));
            Assert.AreEqual(expected3, DateUtils.EasterSunday(source3));
            Assert.AreEqual(expected4, DateUtils.EasterSunday(source4));
            Assert.AreEqual(expected5, DateUtils.EasterSunday(source5));
        }
    }
}
