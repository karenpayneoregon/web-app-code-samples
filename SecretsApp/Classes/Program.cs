using Microsoft.Extensions.DependencyInjection;
using SecretsApp.Classes;
using System.Runtime.CompilerServices;
using ConsoleHelperLibrary.Classes;

// ReSharper disable once CheckNamespace
namespace SecretsApp;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
 
}
