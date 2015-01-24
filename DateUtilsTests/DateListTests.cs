using System;
using System.Collections.Generic;
using BlueArk;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DateUtilsTests
{
    [TestClass]
    public class DateListTests
    {
        [TestMethod]
        public void Get_EveryDayName()
        {
            HashSet<DayOfWeek> weekdays = new HashSet<DayOfWeek>();
            HashSet<DayOfWeek> weekends = new HashSet<DayOfWeek>();
            HashSet<DayOfWeek> randomdays = new HashSet<DayOfWeek>();

            #region Populate Hashsets
            weekdays.Add(DayOfWeek.Monday);
            weekdays.Add(DayOfWeek.Tuesday);
            weekdays.Add(DayOfWeek.Wednesday);
            weekdays.Add(DayOfWeek.Thursday);
            weekdays.Add(DayOfWeek.Friday);

            weekends.Add(DayOfWeek.Saturday);
            weekends.Add(DayOfWeek.Sunday);

            randomdays.Add(DayOfWeek.Tuesday);
            randomdays.Add(DayOfWeek.Friday);
            randomdays.Add(DayOfWeek.Sunday);
            #endregion

            DateTime testDate1 = new DateTime(2015, 1, 20); // Tuesday
            DateTime testDate2 = new DateTime(2015, 1, 21); // Wednesday
            DateTime testDate3 = new DateTime(2015, 1, 24); // Saturday
            DateTime testDate4 = new DateTime(2015, 1, 31); // Saturday

            List<DateTime> test1 = DateUtils.EveryDayName(testDate1, testDate1, weekdays);
            List<DateTime> test2 = DateUtils.EveryDayName(testDate1, testDate2, weekdays);
            List<DateTime> test3 = DateUtils.EveryDayName(testDate1, testDate3, weekdays);
            List<DateTime> test4 = DateUtils.EveryDayName(testDate1, testDate4, weekdays);
            List<DateTime> test5 = DateUtils.EveryDayName(testDate1, testDate4, weekends);
            List<DateTime> test6 = DateUtils.EveryDayName(testDate1, testDate4, randomdays);
            List<DateTime> test7 = DateUtils.EveryDayName(testDate1, testDate1, weekends);
            List<DateTime> test8 = DateUtils.EveryDayName(testDate4, testDate1, randomdays);

            Assert.AreEqual(1, test1.Count);
            Assert.AreEqual(2, test2.Count);
            Assert.AreEqual(4, test3.Count);
            Assert.AreEqual(9, test4.Count);
            Assert.AreEqual(3, test5.Count);
            Assert.AreEqual(5, test6.Count);
            Assert.AreEqual(0, test7.Count);
        }
    }
}
