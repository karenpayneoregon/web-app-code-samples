﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Revenue.Configuration.Core1.Data;
using Revenue.Configuration.Core1.Models;
using System;
using System.Collections.Generic;

namespace Revenue.Configuration.Core1.Data.Configurations
{
    public partial class GeneralSettingsConfiguration : IEntityTypeConfiguration<GeneralSettings>
    {
        public void Configure(EntityTypeBuilder<GeneralSettings> entity)
        {
            entity.HasOne(d => d.IdentifierNavigation).WithMany(p => p.GeneralSettings)
            .HasForeignKey(d => d.Identifier)
            .HasConstraintName("FK_GeneralSettings_Applications");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<GeneralSettings> entity);
    }
}