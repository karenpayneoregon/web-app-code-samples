using System.Text.Json;
using AjaxBasics.Models;

namespace AjaxBasics.Classes;

public class MockData
{
    public static List<FusionLog> FusionLogs() =>
        new()
        {
            new FusionLog() { Id = 1, FileName = "CalabrioAbsenceImport.1.log", Date = new DateOnly(2023, 10, 1) },
            new FusionLog() { Id = 2, FileName = "car_archive_devweb7datasources.log", Date = new DateOnly(2023, 10, 7) },
            new FusionLog() { Id = 3, FileName = "DailyWorkEffortReviews.log", Date = new DateOnly(2023, 11, 21) },
            new FusionLog() { Id = 4, FileName = "SECURE_OTTER_UPLOAD_hits.log", Date = new DateOnly(2023, 11, 22) },
            new FusionLog() { Id = 5, FileName = "xtraCleanFail.log", Date = new DateOnly(2023, 11, 23) }
        };

    public static string SerializeFusionLogs()
    {
        return JsonSerializer.Serialize(FusionLogs(), new JsonSerializerOptions
        {
            WriteIndented = true
        });
    }
}