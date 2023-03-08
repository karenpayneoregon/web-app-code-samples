using TelerikSamples1.Models;
using static System.DateTime;

namespace TelerikSamples1.Classes;

public class MockedData
{
    public static List<NotificationModel> NotificationData() =>
        new()
        {
            new NotificationModel() { Id = 1, Time = Now, Text = "You have no mail" },
            new NotificationModel() { Id = 2, Time = Now, Text = "Meeting in 10 minutes" },
            new NotificationModel() { Id = 3, Time = Now, Text = "Take a walk"},
            new NotificationModel() { Id = 4, Time = Now, Text = "Time to take a break"},
            new NotificationModel() { Id = 5, Time = Now, Text = "Good job"},
            new NotificationModel() { Id = 6, Time = Now, Text = "Take the trash out"},
            new NotificationModel() { Id = 7, Time = Now, Text = "You have been good, have a snack"}
        };
}
