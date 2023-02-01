﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TwoFactorAuthentication1.Data.Configurations;
using TwoFactorAuthentication1.Models;
using static ConfigurationLibrary.Classes.ConfigurationHelper;

#nullable disable

namespace TwoFactorAuthentication1.Data;

public partial class Context : DbContext
{
    public Context()
    {
    }

    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Organizations> Organizations { get; set; }

    public virtual DbSet<Verifications> Verifications { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(ConnectionString());
        //=> optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AuthenticateSample;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
            modelBuilder.ApplyConfiguration(new Configurations.OrganizationsConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.VerificationsConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
