using System;
using BlueArk;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DateUtilsTests
{
    [TestClass]
    public class DateUtilsTests
    {
        [TestMethod]
        public void Get_First_Day_Of_Month()
        {
            DateTime source1 = new DateTime(2014, 12, 15, 9, 10, 11);

            DateTime expected1 = new DateTime(2014, 12, 1);

            Assert.AreEqual(expected1, DateUtils.FirstDayOfMonth(source1));
        }

        [TestMethod]
        public void Get_Last_Day_Of_Month()
        {
            DateTime source1 = new DateTime(2014, 12, 15, 9, 10, 11);

            DateTime expected1 = new DateTime(2014, 12, 31);

            Assert.AreEqual(expected1, DateUtils.LastDayOfMonth(source1));
        }

    }
}
