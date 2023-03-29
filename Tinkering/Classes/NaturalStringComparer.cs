using System.Runtime.InteropServices;

namespace Tinkering.Classes;
public class NaturalStringComparer : Comparer<string>
{
    
    [DllImport("Shlwapi.dll", CharSet = CharSet.Unicode)]
    private static extern int StrCmpLogicalW(string x, string y);

    public override int Compare(string x, string y) 
        => StrCmpLogicalW(x, y);
}