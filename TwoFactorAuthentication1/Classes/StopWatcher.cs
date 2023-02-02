using System.Diagnostics;

namespace TwoFactorAuthentication1.Classes;

public sealed class StopWatcher
{

    private static readonly Lazy<StopWatcher> Lazy = new(() => new StopWatcher());


    private readonly Stopwatch _stopwatch;

    /// <summary>
    /// Inaccessible constructor
    /// </summary>
    private StopWatcher()
    {
        _stopwatch = new Stopwatch();
    }

    public void Start()
    {
        _stopwatch.Reset();
        _stopwatch.Start();
    }
        
    public void Stop() => _stopwatch.Stop();

    /// <summary>
    /// Get elapsed time as a TimeSpan
    /// </summary>
    public TimeSpan Elapsed =>
        _stopwatch.Elapsed;

    /// <summary>
    /// Format elapsed time to minutes, seconds, milliseconds
    /// </summary>
    public string ElapsedFormatted => Elapsed.ToString("hh\\:mm\\:ss\\.fff");

    /// <summary>
    /// Access point to methods and properties
    /// </summary>
    public static StopWatcher Instance => Lazy.Value;

}