﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Taxpayer = new HashSet<Taxpayer>();
        }

        public int CategoryId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Taxpayer> Taxpayer { get; set; }
    }
}