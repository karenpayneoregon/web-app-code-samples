using Microsoft.EntityFrameworkCore;
using Revenue.Configuration.Core1.Classes;

// ReSharper disable once CheckNamespace
namespace Revenue.Configuration.Core1.Data;
public partial class Context
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            ConnectionHelpers.NoLoggingSqlServer(optionsBuilder);
        }

        
    }
}
