using System;
using System.Globalization;

namespace Kulman.UWP.Code
{
    public static class DateTimeExtensions
    {
        public static DateTime UnixTimeStampToDateTime(int unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        public static GregorianCalendar Gc = new GregorianCalendar();

        public static int GetWeekOfMonth(this DateTime time)
        {
            var first = new DateTime(time.Year, time.Month, 1);
            return time.GetWeekOfYear() - first.GetWeekOfYear() + 1;
        }

        public static int GetWeekOfYear(this DateTime time)
        {
            return Gc.GetWeekOfYear(time, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
        }

        public static int GetDayOfWeekNumber(this DateTime day)
        {
            var dayOfWeek = (int)day.DayOfWeek - 1;
            if (dayOfWeek < 0)
            {
                dayOfWeek = 6;
            }
            return dayOfWeek;
        }
    }
}
