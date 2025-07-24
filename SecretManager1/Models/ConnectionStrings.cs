namespace SecretManager1.Models;

#pragma warning disable CS8618
public class ConnectionStrings
{
    public string DefaultConnection { get; set; }
    public override string ToString() => $"DefaultConnection: {DefaultConnection}";
}