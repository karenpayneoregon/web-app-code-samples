﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable


namespace Revenue.Configuration.Core1.Models;

public partial class Applications
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int? Identifier { get; set; }

    public string ContactName { get; set; }

    public virtual ICollection<AcedEmailSettings> AcedEmailSettings { get; } = new List<AcedEmailSettings>();

    public virtual ICollection<AzureSettings> AzureSettings { get; } = new List<AzureSettings>();

    public virtual ICollection<GeneralSettings> GeneralSettings { get; } = new List<GeneralSettings>();

    public virtual ICollection<MailSettings> MailSettings { get; } = new List<MailSettings>();

    public virtual ICollection<WebPageSettings> WebPageSettings { get; } = new List<WebPageSettings>();
}