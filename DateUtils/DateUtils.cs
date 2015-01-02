using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueArk
{
    /// <summary>
    /// Utilities for dealing with dates, ignoring the time component.
    /// </summary>
    public static class DateUtils
    {
        #region Properties
        /// <summary>
        /// Gets the first day of the current month
        /// </summary>
        public static DateTime FirstDayOfCurrentMonth
        {
            get { return FirstDayOfMonth(DateTime.Today); }
        }

        /// <summary>
        /// Gets the last day of the current month
        /// </summary>
        public static DateTime LastDayOfCurrentMonth
        {
            get
            {
                DateTime today = DateTime.Today;

                return LastDayOfMonth(DateTime.Today);
            }
        }
        #endregion

        #region First/Last day of a month
        /// <summary>
        /// Given a source date, return the first day of that month.
        /// </summary>
        /// <param name="sourceDate">The source date to make the calculation from.</param>
        /// <returns>A DateTime object representing midnight on the first day of
        /// the specified month.</returns>
        public static DateTime FirstDayOfMonth(DateTime sourceDate)
        {
            return new DateTime(sourceDate.Year, sourceDate.Month, 1);
        }

        /// <summary>
        /// Return the first day of the current month.
        /// </summary>
        /// <returns>A DateTime object representing midnight on the first day of
        /// the current month.</returns>
        public static DateTime FirstDayOfMonth()
        {
            return FirstDayOfMonth(DateTime.Today);
        }

        /// <summary>
        /// Given a source date, return the last day of that month.
        /// </summary>
        /// <param name="sourceDate">The source date to make the calculation from.</param>
        /// <returns>A DateTime object representing midnight on the last day of
        /// the specified month.</returns>
        public static DateTime LastDayOfMonth(DateTime sourceDate)
        {
            return new DateTime(sourceDate.Year, sourceDate.Month, DateTime.DaysInMonth(sourceDate.Year, sourceDate.Month));
        }

        /// <summary>
        /// Return the last day of the current month.
        /// </summary>
        /// <returns>A DateTime object representing midnight on the last day of
        /// the current month.</returns>
        public static DateTime LastDayOfMonth()
        {
            return LastDayOfMonth(DateTime.Today);
        }

        #endregion

        #region First/Last/Nth specified day of a month
        /// <summary>
        /// Find the date of the first specified day of the week within a given month.
        /// </summary>
        /// <param name="currentMonth">Any DateTime within the month being searched.</param>
        /// <param name="dayName">The day of the week being searched for.</param>
        /// <returns>A DateTime representing the first occurance of the specified day of the
        /// week in a given month.</returns>
        public static DateTime FirstDayNameOfMonth(DateTime currentMonth, DayOfWeek dayName)
        {
            DateTime checkDate = FirstDayOfMonth(currentMonth);
            Int32 checkDayName = (Int32)checkDate.DayOfWeek;
            Int32 searchDayName = (Int32)dayName;

            Int32 dateDiff = searchDayName - checkDayName;
            dateDiff += dateDiff < 0 ? 7 : 0;

            checkDate = checkDate.AddDays(dateDiff);

            return checkDate;
        }

        /// <summary>
        /// Find the date of the first specified day of the week within the current month.
        /// </summary>
        /// <param name="dayName">The day of the week being searched for.</param>
        /// <returns>A DateTime representing the first occurance of the specified day of the
        /// week in the current month.</returns>
        public static DateTime FirstDayNameOfMonth(DayOfWeek dayName)
        {
            return FirstDayNameOfMonth(DateTime.Today, dayName);
        }

        /// <summary>
        /// Find the date of the last specified day of the week within a given month.
        /// </summary>
        /// <param name="currentMonth">Any DateTime within the month being searched.</param>
        /// <param name="dayName">The day of the week being searched for.</param>
        /// <returns>A DateTime representing the last occurance of the specified day of the
        /// week in a given month.</returns>
        public static DateTime LastDayNameOfMonth(DateTime currentMonth, DayOfWeek dayName)
        {
            DateTime nextMonth = currentMonth.AddMonths(1);
            DateTime checkDate = FirstDayNameOfMonth(nextMonth, dayName);

            checkDate = checkDate.AddDays(-7);

            return checkDate;
        }

        /// <summary>
        /// Find the date of the last specified day of the week within the current month.
        /// </summary>
        /// <param name="dayName">The day of the week being searched for.</param>
        /// <returns>A DateTime representing the last occurance of the specified day of the
        /// week in the current month.</returns>
        public static DateTime LastDayNameOfMonth(DayOfWeek dayName)
        {
            return LastDayNameOfMonth(DateTime.Today, dayName);
        }

        /// <summary>
        /// Find the date of the nth specified day of the week within a given month.
        /// </summary>
        /// <param name="currentMonth">Any DateTime within the month being searched.</param>
        /// <param name="dayName">The day of the week being searched for.</param>
        /// <param name="index">A zero-based index of the day to find. 0 searches for the
        /// first day name, 1 searches for the second, and so on.</param>
        /// <returns>A DateTime representing the nth occurance of the specified day of the
        /// week in a given month.</returns>
        public static DateTime NthDayNameOfMonth(DateTime currentMonth, DayOfWeek dayName, Int32 index)
        {
            DateTime checkDate = FirstDayNameOfMonth(currentMonth, dayName);

            Int32 firstDayOfMonth = checkDate.Day;
            Int32 daysInMonth = DateTime.DaysInMonth(checkDate.Year, checkDate.Month);
            Int32 daysToAdd = 7*index;
            Int32 calculatedDay = firstDayOfMonth + daysToAdd;

            if (calculatedDay > daysInMonth)
            {
                throw new ArgumentOutOfRangeException();
            }

            checkDate = checkDate.AddDays(daysToAdd);

            return checkDate;
        }

        /// <summary>
        /// Find the date of the nth specified day of the week within the current month.
        /// </summary>
        /// <param name="dayName">The day of the week being searched for.</param>
        /// <param name="index">A zero-based index of the day to find. 0 searches for the
        /// first day name, 1 searches for the second, and so on.</param>
        /// <returns>A DateTime representing the nth occurance of the specified day of the
        /// week in the current month.</returns>
        public static DateTime NthDayNameOfMonth(DayOfWeek dayName, Int32 index)
        {
            return NthDayNameOfMonth(DateTime.Today, dayName, index);
        }
        #endregion

        #region
        // TODO...
        #endregion
    }
}
