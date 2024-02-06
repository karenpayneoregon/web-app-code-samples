﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NorthWindExampleApp4.Models;

public partial class Customers
{
    /// <summary>
    /// Primary key
    /// </summary>
    public int CustomerIdentifier { get; set; }
    [Display(Name = "Name")]
    public string CompanyName { get; set; }

    public int? ContactId { get; set; }

    public string Street { get; set; }

    public string City { get; set; }

    public string Region { get; set; }

    [Display(Name = "Postal")]
    public string PostalCode { get; set; }

    public int? CountryIdentifier { get; set; }

    public string Phone { get; set; }

    public string Fax { get; set; }

    public int? ContactTypeIdentifier { get; set; }
    [Display(Name = "Modified")]
    public DateTime? ModifiedDate { get; set; }

    public virtual Contacts Contact { get; set; }
    [Display(Name = "Contact type id")]
    public virtual ContactType ContactTypeIdentifierNavigation { get; set; }

    public virtual Countries CountryIdentifierNavigation { get; set; }

    public virtual ICollection<Orders> Orders { get; } = new List<Orders>();

    public override string ToString() => CompanyName;

}