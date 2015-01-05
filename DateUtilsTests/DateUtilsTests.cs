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

            DateTime source2 = DateTime.Today;
            DateTime expected2 = new DateTime(source2.Year, source2.Month, 1);

            Assert.AreEqual(expected1, DateUtils.FirstDayOfMonth(source1));
            Assert.AreEqual(expected2, DateUtils.FirstDayOfMonth());
        }

        [TestMethod]
        public void Get_Last_Day_Of_Month()
        {
            DateTime source1 = new DateTime(2014, 12, 15, 9, 10, 11);
            DateTime expected1 = new DateTime(2014, 12, 31);

            DateTime source2 = DateTime.Today;
            DateTime expected2 = new DateTime(source2.Year, source2.Month, 1).AddMonths(1).AddDays(-1);

            Assert.AreEqual(expected1, DateUtils.LastDayOfMonth(source1));
            Assert.AreEqual(expected2, DateUtils.LastDayOfMonth());
        }

        [TestMethod]
        public void Get_First_Day_Name_Of_Month()
        {
            DateTime source1 = new DateTime(2014, 12, 15, 9, 10, 11);
            DayOfWeek sourceDay1 = DayOfWeek.Thursday;
            DateTime expected1 = new DateTime(2014, 12, 4);

            DateTime source2 = new DateTime(2014, 12, 15, 9, 10, 11);
            DayOfWeek sourceDay2 = DayOfWeek.Sunday;
            DateTime expected2 = new DateTime(2014, 12, 7);

            // Test without specifying source month (should default to current)
            DayOfWeek sourceDay3 = DayOfWeek.Sunday;
            DateTime expected3 = DateUtils.FirstDayNameOfMonth(DateTime.Today, sourceDay3);

            Assert.AreEqual(expected1, DateUtils.FirstDayNameOfMonth(source1, sourceDay1));
            Assert.AreEqual(expected2, DateUtils.FirstDayNameOfMonth(source2, sourceDay2));
            Assert.AreEqual(expected3, DateUtils.FirstDayNameOfMonth(sourceDay3));
        }

        [TestMethod]
        public void Get_Last_Day_Name_Of_Month()
        {
            DateTime source1 = new DateTime(2014, 12, 15, 9, 10, 11);
            DayOfWeek sourceDay1 = DayOfWeek.Thursday;
            DateTime expected1 = new DateTime(2014, 12, 25);

            DateTime source2 = new DateTime(2015, 1, 31, 9, 10, 11);
            DayOfWeek sourceDay2 = DayOfWeek.Wednesday;
            DateTime expected2 = new DateTime(2015, 1, 28);

            // Test without specifying source month (should default to current)
            DayOfWeek sourceDay3 = DayOfWeek.Sunday;
            DateTime expected3 = DateUtils.LastDayNameOfMonth(DateTime.Today, sourceDay3);

            Assert.AreEqual(expected1, DateUtils.LastDayNameOfMonth(source1, sourceDay1));
            Assert.AreEqual(expected2, DateUtils.LastDayNameOfMonth(source2, sourceDay2));
            Assert.AreEqual(expected3, DateUtils.LastDayNameOfMonth(sourceDay3));
        }

        [TestMethod]
        public void Get_Nth_Day_Name_Of_Month()
        {
            DateTime source1 = new DateTime(2014, 12, 15, 9, 10, 11);
            DayOfWeek sourceDay1 = DayOfWeek.Thursday;
            DateTime expected1 = new DateTime(2014, 12, 4);
            DateTime actual1 = DateUtils.NthDayNameOfMonth(source1, sourceDay1, 0);

            DateTime expected2 = new DateTime(2014, 12, 11);
            DateTime actual2 = DateUtils.NthDayNameOfMonth(source1, sourceDay1, 1);

            // Test without specifying source month (should default to current)
            DayOfWeek sourceDay3 = DayOfWeek.Sunday;
            DateTime actual3 = DateUtils.NthDayNameOfMonth(sourceDay3, 1);
            DateTime expected3 = DateUtils.NthDayNameOfMonth(DateTime.Today, sourceDay3, 1);

            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
            Assert.AreEqual(expected3, actual3);

            // Now check for an out of range exception:
            try
            {
                DateUtils.NthDayNameOfMonth(DateTime.Now, DayOfWeek.Wednesday, 10);
                Assert.Fail("A call with index 10 should have failed, but didn't.");
            }
            catch (ArgumentOutOfRangeException)
            {
                // Do nothing: this is the correct exception that should be thrown.
            }
            catch (Exception e)
            {
                Assert.Fail("Incorrect exception thrown: " + e.Message);
            }
        }

        [TestMethod]
        public void Get_DaysBetween()
        {
            DateTime source1 = new DateTime(2014, 12, 15, 9, 10, 11);
            DateTime target1 = new DateTime(2014, 12, 16, 9, 10, 11);

            DateTime source2 = new DateTime(2014, 12, 15, 9, 10, 11);
            DateTime target2 = new DateTime(2014, 12, 15, 4, 10, 11);

            DateTime source3 = new DateTime(2013, 12, 15, 9, 10, 11);
            DateTime target3 = new DateTime(2014, 12, 15, 4, 10, 11);

            Assert.AreEqual(1, DateUtils.DaysBetween(source1, target1));
            Assert.AreEqual(0, DateUtils.DaysBetween(source2, target2));
            Assert.AreEqual(365, DateUtils.DaysBetween(source3, target3));
        }

        [TestMethod]
        public void Get_DaysTo()
        {
            DateTime target1 = DateTime.Now;

            Assert.AreEqual(0, DateUtils.DaysTo(target1));
        }

        [TestMethod]
        public void Get_DaysFrom()
        {
            DateTime source1 = DateUtils.Tomorrow;
            DateTime source2 = DateUtils.Yesterday;
            DateTime source3 = DateTime.Today;

            Assert.AreEqual(-1, DateUtils.DaysFrom(source1));
            Assert.AreEqual(1, DateUtils.DaysFrom(source2));
            Assert.AreEqual(0, DateUtils.DaysFrom(source3));
        }
    }
}
