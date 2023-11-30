using System.Text.Json;

namespace MiscSettingsApp.Classes;
public static class JSonHelper
{
    /// <summary>
    /// Serialize list to a json file
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="sender">type to serialize</param>
    /// <param name="fileName">Filename without extension</param>
    public static void ToJson<T>(this List<T> sender, string fileName)
    {
        File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{fileName}.json"),
            JsonSerializer.Serialize(sender, new JsonSerializerOptions
            {
                WriteIndented = true 
            }));
    }
    /// <summary>
    /// Serialize array to a json file
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="sender">type to serialize</param>
    /// <param name="fileName">Filename without extension</param>
    public static void ToJson<T>(this T[] sender, string fileName)
    {
        File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{fileName}.json"),
            JsonSerializer.Serialize(sender, new JsonSerializerOptions
            {
                WriteIndented = true
            }));
    }

    /// <summary>
    /// Write Json string to file
    /// </summary>
    /// <param name="sender">Json string</param>
    /// <param name="fileName">Filename without extension</param>
    public static void ToJson(this string sender, string fileName)
    {
        var json = JsonSerializer.Serialize(sender, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        
        File.WriteAllText($"{fileName}.json", sender);
    }

}
