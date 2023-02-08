using Microsoft.EntityFrameworkCore;
using NotesFormApp.Data;
using NotesFormApp.Models;

namespace NotesFormApp.Classes;

internal class SetupDatabase
{
    public static async Task Initialize()
    {
        await using var context = new Context();
        CleanDatabase(context);
        await PopulateCategories(context);
        await PopulateNotes(context);
    }
    /// <summary>
    /// Remove database if exists
    /// Create new database
    /// </summary>
    public static void CleanDatabase(DbContext context)
    {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }

    /// <summary>
    /// Populate categories which is followed by adding several notes.
    /// </summary>
    /// <param name="context"></param>
    public static async Task PopulateCategories(DbContext context)
    {
        List<Category> list = new()
        {
            new () { CategoryName = "Shopping list" },
            new () { CategoryName = "Today" },
            new () {CategoryName = "Next week" },
            new () {CategoryName = "Appointments" }
        };

        await context.AddRangeAsync(list);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Add several notes
    /// </summary>
    public static async Task PopulateNotes(DbContext context)
    {
        List<Note> list = new()
        {
            new () {CategoryId = 1, BodyText = "Buy eggs, milk and sugar", DueDate = new DateTime(2022,10,16, 13,23,0), Completed = true},
            new () {CategoryId = 4, BodyText = "Dental check-up", DueDate = new DateTime(2022,10,16,8,15,0), Completed = true},
            new () {CategoryId = 2, BodyText = "Check oil in car", DueDate = new DateTime(2022,10,10,15,45,0), Completed = true}
        };

        await context.AddRangeAsync(list);
        await context.SaveChangesAsync();
    }


}