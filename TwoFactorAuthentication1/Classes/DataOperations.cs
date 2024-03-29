﻿using TwoFactorAuthentication1.Data;
using TwoFactorAuthNet;

namespace TwoFactorAuthentication1.Classes;
public class DataOperations
{
    public static int Period = 150;
    public static DateTime DateTime;
    private const string Issuer = "OED";
    private const int Bytes = 160;
    private const int Digits = 6;

    public static (string secret, string code) Generate(string emailAddress)
    {
        var tfa = new TwoFactorAuth(Issuer, Digits, Period);
        var secret = tfa.CreateSecret(Bytes);
        var code = tfa.GetCode(secret,DateTime);

        using var context = new Context();

        var verification = context.Verifications.FirstOrDefault();
        verification!.EmailAddress = emailAddress;
        verification.Secret = secret;
        verification.Code = code;
        verification.CreatedDate = DateTime.Now;
        verification.CreatedTime = DateTime.Now.TimeOfDay;

        context.SaveChanges();

        return (secret, code);
    }

    public static bool Simulation(string secret, string code, string emailAddress, string companyName)
    {
        using var context = new Context();

        var issuer = context.Organizations.FirstOrDefault(x => x.CompanyName == "Company1");
        var tfa = new TwoFactorAuth(issuer!.Issuer, Digits, Period);
        var verification = context.Verifications.FirstOrDefault(x => x.EmailAddress == emailAddress);

        if (verification is not null)
        {
            return tfa.VerifyCode(secret, code);
        }

        return false;
    }
}
