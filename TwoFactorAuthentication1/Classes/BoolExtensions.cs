﻿namespace TwoFactorAuthentication1.Classes;

public static class BoolExtensions
{
    public static string ToYesNo(this bool value) => value ? "Yes" : "No";
}