using System.Text.Json;
using System.Text.Json.Serialization;

namespace MiscSettingsApp.Models;


public class MiscSettings
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Name { get; set; }
    [JsonPropertyName("TheEnum")]
    public string TypeName { get; set; }

    public override string ToString()
    {
        var options = new JsonSerializerOptions()
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            NumberHandling = JsonNumberHandling.WriteAsString,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        };

        return JsonSerializer.Serialize(this, options);
    }

}