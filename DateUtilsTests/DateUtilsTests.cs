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

        [TestMethod]
        public void Get_First_Day_Name_Of_Month()
        {
            DateTime source1 = new DateTime(2014, 12, 15, 9, 10, 11);
            DayOfWeek sourceDay1 = DayOfWeek.Thursday;
            DateTime expected1 = new DateTime(2014, 12, 4);

            DateTime source2 = new DateTime(2014, 12, 15, 9, 10, 11);
            DayOfWeek sourceDay2 = DayOfWeek.Sunday;
            DateTime expected2 = new DateTime(2014, 12, 7);

            Assert.AreEqual(expected1, DateUtils.FirstDayNameOfMonth(source1, sourceDay1));
            Assert.AreEqual(expected2, DateUtils.FirstDayNameOfMonth(source2, sourceDay2));
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

            Assert.AreEqual(expected1, DateUtils.LastDayNameOfMonth(source1, sourceDay1));
            Assert.AreEqual(expected2, DateUtils.LastDayNameOfMonth(source2, sourceDay2));
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

            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);

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


    }
}
