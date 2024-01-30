using System.Numerics;

namespace WebApplication1.Classes;

public static class Extensions
{
    public static bool IsEven<T>(this T sender) where T : INumber<T>
        => T.IsEvenInteger(sender);
}
