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

        /// <summary>
        /// Gets yesterday's date.
        /// </summary>
        public static DateTime Yesterday
        {
            get { return DateTime.Today.AddDays(-1); }
        }

        /// <summary>
        /// Gets tomorrow's date.
        /// </summary>
        public static DateTime Tomorrow
        {
            get { return DateTime.Today.AddDays(1); }
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

        #region Date Calculations
        /// <summary>
        /// Calculate the number of days between sourceDate and the targetDate
        /// </summary>
        /// <param name="sourceDate">The date to start from</param>
        /// <param name="targetDate">The date to compare against the source</param>
        /// <returns>The number of days (positive or negative) between the source date,
        /// and the target date.</returns>
        public static Int32 DaysBetween(DateTime sourceDate, DateTime targetDate)
        {
            return (targetDate.Date - sourceDate.Date).Days;
        }

        /// <summary>
        /// Calculate the number of days between today and the targetDate
        /// </summary>
        /// <param name="targetDate">The date to compare against today</param>
        /// <returns>The number of days (positive or negative) between today,
        /// and the target date.</returns>
        public static Int32 DaysTo(DateTime targetDate)
        {
            return DaysBetween(DateTime.Today, targetDate);
        }

        /// <summary>
        /// Calculate the number of days from the source date to today
        /// </summary>
        /// <param name="sourceDate">The date to compare against today</param>
        /// <returns>The number of days (positive or negative) between the source
        /// date and today.</returns>
        public static Int32 DaysFrom(DateTime sourceDate)
        {
            return DaysBetween(sourceDate, DateTime.Today);
        }

        /// <summary>
        /// Gets the number of days in a given year
        /// </summary>
        /// <param name="year">The year to use for calculating the number of days from.</param>
        /// <returns>The number of days in the given year</returns>
        public static Int32 DaysInYear(Int32 year)
        {
            DateTime thisYear = new DateTime(year, 1, 1);
            DateTime nextYear = new DateTime(year+1, 1, 1);

            return (nextYear - thisYear).Days;
        }

        /// <summary>
        /// Gets the number of days in the current year
        /// </summary>
        /// <returns>The number of days in the current year</returns>
        public static Int32 DaysInYear()
        {
            return DaysInYear(DateTime.Today.Year);
        }
        #endregion

        #region Common Holidays
        #region Easter
        /// <summary>
        /// Calculate the date of Easter Sunday on a given year
        /// </summary>
        /// <param name="year">The year to calculate Easter Sunday from</param>
        /// <returns>The Date of Easter Sunday on a given year.</returns>
        public static DateTime EasterSunday(int year)
        {
            int day = 0;
            int month = 0;

            int g = year % 19;
            int c = year / 100;
            int h = (c - (int)(c / 4) - (int)((8 * c + 13) / 25) + 19 * g + 15) % 30;
            int i = h - (int)(h / 28) * (1 - (int)(h / 28) * (int)(29 / (h + 1)) * (int)((21 - g) / 11));

            day = i - ((year + (int)(year / 4) + i + 2 - c + (int)(c / 4)) % 7) + 28;
            month = 3;

            if (day > 31)
            {
                month++;
                day -= 31;
            }

            return new DateTime(year, month, day).Date;
        }

        /// <summary>
        /// Calculate the date of Easter Sunday this year.
        /// </summary>
        /// <returns>The date of Easter Sunday for the current year.</returns>
        public static DateTime EasterSunday()
        {
            return EasterSunday(DateTime.Today.Year);
        }

        /// <summary>
        /// Calculate the date of the next Easter Sunday
        /// </summary>
        /// <returns>Date of the next Easter Sunday from the current date.</returns>
        public static DateTime NextEasterSunday()
        {
            DateTime thisEaster = EasterSunday();
            if (DateTime.Today > thisEaster)
            {
                return EasterSunday(DateTime.Today.Year + 1);
            }
            else
            {
                return thisEaster;
            }
        }

        /// <summary>
        /// Calculate the date of the previous Easter Sunday
        /// </summary>
        /// <returns>Date of the previous Easter Sunday from the current date.</returns>
        public static DateTime PreviousEasterSunday()
        {
            DateTime thisEaster = EasterSunday();
            if (DateTime.Today < thisEaster)
            {
                return EasterSunday(DateTime.Today.Year - 1);
            }
            else
            {
                return thisEaster;
            }
        }

        #endregion
        #endregion


        #region Lists of Dates
        /// <summary>
        /// Returns a list of DateTime objects that match the supplied HashSet
        /// of days of the week between given dates.
        /// </summary>
        /// <param name="start">The start date to begin checking from.</param>
        /// <param name="end">The end date to check up to.</param>
        /// <param name="days">A HashSet of DayOfWeek values.</param>
        /// <returns>A List of DateTime values matching the input criteria.</returns>
        public static List<DateTime> EveryDayName(DateTime start, DateTime end, HashSet<DayOfWeek> days)
        {
            List<DateTime> dateList = new List<DateTime>();

            // Make sure start is before end
            if (start > end)
            {
                DateTime tmp = end.Date;
                end = start.Date;
                start = tmp;
            }

            // Loop through all dates, and add any that match the criteria
            for (DateTime date = start; date <= end; date = date.AddDays(1))
            {
                if (days.Contains(date.DayOfWeek))
                    dateList.Add(date.Date);
            }

            return dateList;
        }

        /// <summary>
        /// Returns a list of DateTime objects that match the supplied HashSet
        /// of days of the week between now and a given end date.
        /// </summary>
        /// <param name="end">The end date to check up to.</param>
        /// <param name="days">A HashSet of DayOfWeek values.</param>
        /// <returns>A List of DateTime values matching the input criteria.</returns>
        public static List<DateTime> EveryDayName(DateTime end, HashSet<DayOfWeek> days)
        {
            return EveryDayName(DateTime.Today, end, days);
        }

        /// <summary>
        /// Returns a list of DateTime objects that match the supplied HashSet
        /// of days of the week between now and a given number of days from now.
        /// </summary>
        /// <param name="dayCount">The number of days added to today. The resulting date represents
        /// the upper bound of the search space.</param>
        /// <param name="days">A HashSet of DayOfWeek values.</param>
        /// <returns>A List of DateTime values matching the input criteria.</returns>
        public static List<DateTime> EveryDayName(Int32 dayCount, HashSet<DayOfWeek> days)
        {
            return EveryDayName(DateTime.Today.AddDays(dayCount), days);
        }

        #endregion
    }
}
