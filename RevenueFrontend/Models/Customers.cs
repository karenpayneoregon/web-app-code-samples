﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Customers
{
    /// <summary>
    /// Id
    /// </summary>
    public int CustomerIdentifier { get; set; }

    /// <summary>
    /// Company
    /// </summary>
    public string CompanyName { get; set; }

    /// <summary>
    /// ContactId
    /// </summary>
    public int? ContactId { get; set; }

    /// <summary>
    /// Street
    /// </summary>
    public string Street { get; set; }

    /// <summary>
    /// City
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// Region
    /// </summary>
    public string Region { get; set; }

    /// <summary>
    /// Postal Code
    /// </summary>
    public string PostalCode { get; set; }

    /// <summary>
    /// CountryIdentifier
    /// </summary>
    public int? CountryIdentifier { get; set; }

    /// <summary>
    /// Phone
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// Fax
    /// </summary>
    public string Fax { get; set; }

    /// <summary>
    /// ContactTypeIdentifier
    /// </summary>
    public int? ContactTypeIdentifier { get; set; }

    /// <summary>
    /// Modified Date
    /// </summary>
    public DateTime? ModifiedDate { get; set; }

    public virtual Contacts Contact { get; set; }

    public virtual ContactType ContactTypeIdentifierNavigation { get; set; }

    public virtual Countries CountryIdentifierNavigation { get; set; }

    public virtual ICollection<Orders> Orders { get; } = new List<Orders>();
}