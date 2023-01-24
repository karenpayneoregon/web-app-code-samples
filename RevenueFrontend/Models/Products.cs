﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Products
{
    public int ProductId { get; set; }

    public string ProductName { get; set; }

    public int? SupplierId { get; set; }

    public int? CategoryId { get; set; }

    public string QuantityPerUnit { get; set; }

    public decimal? UnitPrice { get; set; }

    public short? UnitsInStock { get; set; }

    public short? UnitsOnOrder { get; set; }

    public short? ReorderLevel { get; set; }

    public bool Discontinued { get; set; }

    public DateTime? DiscontinuedDate { get; set; }

    public virtual Categories Category { get; set; }

    public virtual ICollection<OrderDetails> OrderDetails { get; } = new List<OrderDetails>();

    public virtual Suppliers Supplier { get; set; }
}