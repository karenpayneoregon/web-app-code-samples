using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace RazorLibrary.Classes;

public static class TempDataHelper
{
    /// <summary>
    /// Put an item into TempData
    /// </summary>
    /// <typeparam name="T">Item type</typeparam>
    /// <param name="sender">TempData</param>
    /// <param name="key">Used to retrieve value with <see cref="Get{T}"/> </param>
    /// <param name="value">Value to store</param>
    public static void Put<T>(this ITempDataDictionary sender, string key, T value) where T : class
    {
        sender[key] = JsonConvert.SerializeObject(value);
    }
    /// <summary>
    /// Get value by key in TempData
    /// </summary>
    /// <typeparam name="T">Item type</typeparam>
    /// <param name="sender">TempData</param>
    /// <param name="key">Used to retrieve value</param>
    /// <returns>Item</returns>
    public static T Get<T>(this ITempDataDictionary sender, string key) where T : class
    {
        sender.TryGetValue(key, out var unknown);
        return unknown == null ? null : JsonConvert.DeserializeObject<T>((string)unknown);
    }
}
