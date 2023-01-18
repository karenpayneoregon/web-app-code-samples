﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Data.Configurations
{
    public partial class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> entity)
        {
            entity.HasKey(e => e.RegionId).IsClustered(false);

            entity.Property(e => e.RegionId)
            .ValueGeneratedNever()
            .HasColumnName("RegionID");
            entity.Property(e => e.RegionDescription)
            .IsRequired()
            .HasMaxLength(50)
            .IsFixedLength();

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Region> entity);
    }
}
