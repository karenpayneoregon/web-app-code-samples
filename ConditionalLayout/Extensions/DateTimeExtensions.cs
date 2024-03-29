﻿namespace ConditionalLayout.Extensions;

internal static class DateTimeExtensions
{
    public static bool IsWeekend(this DateTime self) 
        => self.DayOfWeek is DayOfWeek.Sunday or DayOfWeek.Saturday;

    public static bool IsWeekDay(this DateTime self)
        => !self.IsWeekend();

    public static bool IsWeekDay(this DayOfWeek sender)
    {
        return sender == DayOfWeek.Monday || sender == DayOfWeek.Tuesday || sender == DayOfWeek.Wednesday ||
               sender == DayOfWeek.Thursday || sender == DayOfWeek.Friday;
    }

    public static bool IsWeekend(this DayOfWeek sender) => !sender.IsWeekDay();
}