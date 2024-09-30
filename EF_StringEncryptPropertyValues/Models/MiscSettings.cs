using System.Collections;

namespace EF_StringEncryptPropertyValues.Models;

public class MiscSettings : IEnumerable
{
    public string Name { get; set; }
    public TheEnum TheEnum { get; set; }
    public IEnumerator GetEnumerator()
    {
        yield return Name;
        yield return TheEnum;
    }
}




