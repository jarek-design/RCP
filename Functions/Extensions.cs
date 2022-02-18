using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Extensions1
{
    public static class Extens
    {
        public static DateTime datePart(this DateTime d1)
        {
            return new DateTime(d1.Year, d1.Month, d1.Day, 0, 0, 0);
        }

        public static DateTime dateHourMin(this DateTime d1)
            // bez sekund
        {
            return new DateTime(d1.Year, d1.Month, d1.Day, d1.Hour, d1.Minute, 0);
        }

        public static DateTime timeSplit(DateTime actDate, int hour, int minutes)
        {
            return new DateTime(actDate.Year, actDate.Month, actDate.Day, hour, minutes, 0);
        }

        public static DateTime TimeSplit(this DateTime actDate, int hour, int minutes)
        {
            return new DateTime(actDate.Year, actDate.Month, actDate.Day, hour, minutes, 0);
        }

        public static String Repeat(this String stringToRepeat, int repeat)
        {
            var builder = new System.Text.StringBuilder(repeat * stringToRepeat.Length);
            for (int i = 0; i < repeat; i++)
            {
                builder.Append(stringToRepeat);
            }
            return builder.ToString();
        }      
    }
   
}
