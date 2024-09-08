using Microsoft.EntityFrameworkCore;

namespace EF_StringEncryptPropertyValues.Classes.Creations;

internal class SetupDatabase
{

    public static void CleanDatabase(DbContext context)
    {

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

    }

}