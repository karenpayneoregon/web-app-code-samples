﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace MultipleSubmitButtonsBasic.Models;

public partial class Categories
{
    public int CategoryID { get; set; }

    [Display(Name = "Name")]
    public string CategoryName { get; set; }

    public string Description { get; set; }

    public virtual ICollection<Products> Products { get; } = new List<Products>();

    public override string ToString() => CategoryName;

}