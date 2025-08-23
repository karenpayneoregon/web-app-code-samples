﻿using System.Globalization;

namespace WorkingWithDateTime.Classes;

public static class DateTimeUtils
{
    public static int GetWeekNumber()
    {
        var currentCulture = CultureInfo.CurrentCulture;
        int weekNumber = currentCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        return weekNumber;
    }


    public static int Week(this DateTime date)
    {
        var day = (int)CultureInfo.CurrentCulture.Calendar.GetDayOfWeek(date);
        return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date.AddDays(4 - (day == 0 ? 7 : day)), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
    }

    public static int GetIso8601WeekOfYear(DateTime date)
    {
        // Seriously cheat.  If it's Monday, Tuesday or Wednesday, then it'll be the same week# as whatever
        // Thursday, Friday or Saturday are,and we always get those right
        var day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(date);
        if (day is >= DayOfWeek.Monday and <= DayOfWeek.Wednesday)
        {
            date = date.AddDays(3);
        }

        // Return the week of our adjusted day
        return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
    }

    public static int WeekOfYear(this DateTime date) => ISOWeek.GetWeekOfYear(date);

}
