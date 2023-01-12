using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace RazorLibrary.Classes;

public static class TempDataHelper
{
    public static void Put<T>(this ITempDataDictionary sender, string key, T value) where T : class
    {
        sender[key] = JsonConvert.SerializeObject(value);
    }
    public static T Get<T>(this ITempDataDictionary sender, string key) where T : class
    {
        sender.TryGetValue(key, out var unknown);
        return unknown == null ? null : JsonConvert.DeserializeObject<T>((string)unknown);
    }
}
