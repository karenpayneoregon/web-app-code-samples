using System.Diagnostics;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace RazorLibrary.Classes;

public static class WindowHelper
{
    public static void BringProcessToFront(Process process)
    {
        IntPtr handle = process.MainWindowHandle;
        if (IsIconic(handle))
        {
            ShowWindow(handle, SwRestore);
        }

        SetForegroundWindow(handle);
    }

    public static void ShowConsoleWindow(WebApplication app)
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
            }
        }
    }

    const int SwRestore = 9;

    [System.Runtime.InteropServices.DllImport("User32.dll")]
    private static extern bool SetForegroundWindow(IntPtr handle);
    [System.Runtime.InteropServices.DllImport("User32.dll")]
    private static extern bool ShowWindow(IntPtr handle, int nCmdShow);
    [System.Runtime.InteropServices.DllImport("User32.dll")]
    private static extern bool IsIconic(IntPtr handle);

}
