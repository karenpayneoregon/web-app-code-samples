using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
// ReSharper disable SuggestVarOrType_Elsewhere
#pragma warning disable CA1806

namespace RazorLibrary.Classes;

public static class WindowHelper
{

    /// <summary>
    /// Brings the specified process's main window to the foreground.
    /// </summary>
    /// <param name="process">
    /// The <see cref="Process"/> instance representing the process whose main window should be brought to the front.
    /// </param>
    /// <remarks>
    /// If the window is minimized, it will be restored before being brought to the foreground.
    /// </remarks>
    public static void BringProcessToFront(Process process)
    {
        IntPtr handle = process.MainWindowHandle;
        if (IsIconic(handle))
        {
            ShowWindow(handle, SwRestore);
        }

        SetForegroundWindow(handle);
    }

    /// <summary>
    /// <para>Locates the console window for a web application started with Visual Studio.</para>
    /// <para>If not in production environment bring the window to the front.</para>
    /// </summary>
    /// <param name="app">The application</param>
    /// <param name="title">Optional title for console window</param>
    public static void ShowConsoleWindow(this WebApplication app, string title = "")
    {
        if (!app.Environment.IsDevelopment())
        {
            return;
        }

        Process[] processes = Process.GetProcesses();

        var consoleWindowTitle = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, 
            string.Concat(AppDomain.CurrentDomain.FriendlyName, ".exe"));
        
        foreach (var process in processes)
        {
            if (string.IsNullOrWhiteSpace(process.MainWindowTitle)) continue;
            if (process.MainWindowTitle == consoleWindowTitle)
            {
                BringProcessToFront(process);
                
                if (!string.IsNullOrWhiteSpace(title))
                {
                    SetWindowText(process.MainWindowHandle, title);
                }
            }
        }
    }

    /// <summary>
    /// Sets the title of the console window for the specified web application.
    /// </summary>
    /// <param name="app">The <see cref="WebApplication"/> instance representing the application.</param>
    /// <param name="title">The desired title for the console window.</param>
    /// <remarks>
    /// This method updates the console window title only in development environments.
    /// It locates the console window associated with the application and sets its title to the specified value.
    /// </remarks>
    public static void SetConsoleWindowTitle(WebApplication app, string title)
    {
        if (!app.Environment.IsDevelopment())
        {
            return;
        }

        Process[] processes = Process.GetProcesses();

        var consoleWindowTitle = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            string.Concat(AppDomain.CurrentDomain.FriendlyName, ".exe"));
        var p = processes.FirstOrDefault(x => x.MainWindowTitle == consoleWindowTitle);
        SetWindowText(p.MainWindowHandle, title);
      
    }

    /// <summary>
    /// Sets the console window title specifically for Windows 11 environments.
    /// </summary>
    /// <param name="app">The web application instance.</param>
    /// <param name="title">The desired title for the console window.</param>
    /// <remarks>
    /// This method updates the console title for both classic console hosts and VT-aware hosts
    /// (e.g., Windows Terminal). It also handles scenarios where no console is attached, such as
    /// when running as a service or under IIS Express.
    /// </remarks>
    /// <exception cref="IOException">
    /// Thrown when no console is attached or output is redirected. The exception is caught and handled internally.
    /// </exception>
    public static void SetConsoleWindowTitleWindows11(this WebApplication app, string title)
    {
        if (!app.Environment.IsDevelopment())
            return;

        try
        {
            // Works on classic conhost and Windows Terminal
            Console.Title = title;

            // Belt-and-suspenders for VT-aware hosts (Windows Terminal)
            Console.Write($"\x1b]0;{title}\x07");
        }
        catch (IOException)
        {
            // No console is attached (e.g., service, IIS Express, or output redirected)
            // Swallow or log as needed.
        }
    }


    const int SwRestore = 9;

    [DllImport("User32.dll")]
    private static extern bool SetForegroundWindow(IntPtr handle);
    [DllImport("User32.dll")]
    private static extern bool ShowWindow(IntPtr handle, int nCmdShow);
    [DllImport("User32.dll")]
    private static extern bool IsIconic(IntPtr handle);
    [DllImport("user32.dll")]
    static extern int SetWindowText(IntPtr hWnd, string text);
}
