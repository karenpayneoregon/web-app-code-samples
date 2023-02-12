using Microsoft.EntityFrameworkCore;
using SeriLogConditional.Models;

namespace SeriLogConditional.Data;

public class Context : DbContext
{
    public DbSet<LogSettings> LogSettings { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=serilLogData.db");
}
