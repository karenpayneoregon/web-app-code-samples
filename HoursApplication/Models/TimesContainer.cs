﻿namespace HoursApplication.Models;

public class TimesContainer
{
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }

    public (int hours, int minutes) WorkedTime()
    {
        TimeSpan diff = EndTime - StartTime;
        return (diff.Hours, diff.Minutes);
    }
}