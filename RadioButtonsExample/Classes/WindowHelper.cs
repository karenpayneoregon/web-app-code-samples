using System.Diagnostics;

namespace RadioButtonsExample.Classes;

public static class WindowHelper
{
    public static void BringProcessToFront(Process process)
    {
        IntPtr handle = process.MainWindowHandle;
        if (IsIconic(handle))
        {
            ShowWindow(handle, SW_RESTORE);
        }

        SetForegroundWindow(handle);
    }

    public static void ShowConsoleWindow(WebApplication app)
    {
        Process[] processes = Process.GetProcesses();

        var applicationTitle = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AppDomain.CurrentDomain.FriendlyName + ".exe");


        foreach (var process in processes)
        {
            if (!string.IsNullOrWhiteSpace(process.MainWindowTitle))
            {
                //IWebHostEnvironment environment = app.Environment;
                //var path = environment.ContentRootPath;
                
                if (process.MainWindowTitle == applicationTitle)
                {
                    BringProcessToFront(process);
                }
            }
        }
    }

    const int SW_RESTORE = 9;

    [System.Runtime.InteropServices.DllImport("User32.dll")]
    private static extern bool SetForegroundWindow(IntPtr handle);
    [System.Runtime.InteropServices.DllImport("User32.dll")]
    private static extern bool ShowWindow(IntPtr handle, int nCmdShow);
    [System.Runtime.InteropServices.DllImport("User32.dll")]
    private static extern bool IsIconic(IntPtr handle);

}
