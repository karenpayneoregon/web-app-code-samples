﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadioButtonsExample.Data;
using RadioButtonsExample.Models;
using System;
using System.Collections.Generic;

namespace RadioButtonsExample.Data.Configurations
{
    public partial class CategoriesConfiguration : IEntityTypeConfiguration<Categories>
    {
        public void Configure(EntityTypeBuilder<Categories> entity)
        {
            entity.HasKey(e => e.CategoryID);

            entity.Property(e => e.CategoryName)
            .IsRequired()
            .HasMaxLength(15);
            entity.Property(e => e.Description).HasColumnType("ntext");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Categories> entity);
    }
}
