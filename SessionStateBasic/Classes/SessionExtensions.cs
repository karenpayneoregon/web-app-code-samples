using System.Text;

namespace SessionStateBasic.Classes;

public static class SessionExtensions
{
    //public static void SetString(this ISession session, string key, string value)
    //{
    //    session.Set(key, Encoding.UTF8.GetBytes(value));
    //}
    public static bool? GetBoolean(this ISession session, string key)
    {
        var data = session.Get(key);
        if (data == null)
        {
            return null;
        }
        return BitConverter.ToBoolean(data, 0);
    }
    public static void SetBoolean(this ISession session, string key, bool value)
    {
        session.Set(key, BitConverter.GetBytes(value));
    }
}
