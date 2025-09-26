namespace SessionStateBasic.Classes;

public static class SessionExtensions
{
    /// <summary>
    /// Retrieves a boolean value from the session state associated with the specified key.
    /// </summary>
    /// <param name="session">The session state from which to retrieve the value.</param>
    /// <param name="key">The key associated with the boolean value in the session state.</param>
    /// <returns>
    /// A nullable boolean value. Returns <c>null</c> if the key does not exist in the session state.
    /// </returns>
    public static bool? GetBoolean(this ISession session, string key)
    {
        var data = session.Get(key);
        if (data == null)
        {
            return null;
        }
        return BitConverter.ToBoolean(data, 0);
    }
    /// <summary>
    /// Stores a boolean value in the session state associated with the specified key.
    /// </summary>
    /// <param name="session">The session state where the boolean value will be stored.</param>
    /// <param name="key">The key to associate with the boolean value in the session state.</param>
    /// <param name="value">The boolean value to store in the session state.</param>
    public static void SetBoolean(this ISession session, string key, bool value)
    {
        session.Set(key, BitConverter.GetBytes(value));
    }
    /// <summary>
    /// Retrieves a <see cref="DateOnly"/> value from the session state associated with the specified key.
    /// </summary>
    /// <param name="session">The session state from which to retrieve the value.</param>
    /// <param name="key">The key associated with the <see cref="DateOnly"/> value in the session state.</param>
    /// <returns>
    /// A nullable <see cref="DateOnly"/> value. Returns <c>null</c> if the key does not exist in the session state.
    /// </returns>
    public static DateOnly? GetDateOnly(this ISession session, string key)
    {
        var data = session.Get(key);
        if (data == null)
        {
            return null;
        }

        long ticks = BitConverter.ToInt64(data, 0);
        return DateOnly.FromDateTime(new DateTime(ticks));
    }
    /// <summary>
    /// Stores a <see cref="DateOnly"/> value in the session state associated with the specified key.
    /// </summary>
    /// <param name="session">The session state where the <see cref="DateOnly"/> value will be stored.</param>
    /// <param name="key">The key to associate with the <see cref="DateOnly"/> value in the session state.</param>
    /// <param name="value">The <see cref="DateOnly"/> value to store in the session state.</param>
    public static void SetDateOnly(this ISession session, string key, DateOnly value)
    {
        long ticks = value.ToDateTime(TimeOnly.MinValue).Ticks;
        session.Set(key, BitConverter.GetBytes(ticks));
    }
}
