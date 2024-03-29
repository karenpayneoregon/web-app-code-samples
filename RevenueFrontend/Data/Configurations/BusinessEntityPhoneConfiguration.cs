﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Data.Configurations
{
    public partial class BusinessEntityPhoneConfiguration : IEntityTypeConfiguration<BusinessEntityPhone>
    {
        public void Configure(EntityTypeBuilder<BusinessEntityPhone> entity)
        {
            entity.Property(e => e.BusinessEntityPhoneId).HasColumnName("BusinessEntityPhoneID");
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.PhoneNumber).HasComment("Phone number");
            entity.Property(e => e.PhoneNumberTypeId).HasColumnName("PhoneNumberTypeID");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<BusinessEntityPhone> entity);
    }
}
