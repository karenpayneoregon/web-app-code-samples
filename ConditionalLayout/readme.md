﻿# About

Shows how to set the layout file conditionally.

In _ViewStart.cshtml we check if today is a week day or weekend

```csharp
@using ConditionalLayout.Classes
@{
    Layout = StartupConfiguration.Decide;
}
```

In StartupConfiguration.cs

```csharp
public class StartupConfiguration
{
    public static string Decide => DateTime.Now.IsWeekDay() ? "_Layout" : "_LayoutWeekend";
}
```

SomePage uses a different layout than index page

```csharp
@{
    Layout = "Shared/_OtherLayout.cshtml";
}
```