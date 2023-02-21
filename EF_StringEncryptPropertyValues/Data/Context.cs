#nullable disable
using EF_StringEncryptPropertyValues.Models;
using Microsoft.EntityFrameworkCore;
using SecurityDriven.Inferno.Extensions;


namespace EF_StringEncryptPropertyValues.Data;

public partial class Context : DbContext
{

    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }

    public virtual DbSet<User> User { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<User>().Property(e => e.Password)
            .HasConversion(
                value => value.ToBytes(),
                value => value.FromBytes());

    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}