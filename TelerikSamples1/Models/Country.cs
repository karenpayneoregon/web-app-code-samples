using Newtonsoft.Json;

#pragma warning disable CS8618
namespace TelerikSamples1.Models;

public class Country
{
    public int Id { get; set; }
    public string Text { get; set; }
    [JsonIgnore]
    public string Value => Id.ToString();
    public Country(int identifier)
    {
        Id = identifier;
    }

    public override string ToString() => Text;

}
