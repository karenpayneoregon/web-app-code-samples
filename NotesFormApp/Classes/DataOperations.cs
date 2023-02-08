using NotesFormApp.Data;
using Microsoft.EntityFrameworkCore;
using NotesFormApp.Models;

namespace NotesFormApp.Classes
{
    internal class DataOperations
    {
        public static async Task<List<Note>> ReadNotes(int categoryId)
        {
            await using var context = new Context();
            return await context.Note
                .Include(x => x.Category)
                .Where(x => x.CategoryId == categoryId)
                .ToListAsync();
        }

        public static async Task<List<Category>> ReadCategories()
        {
            await using var context = new Context();
            return await context.Category.OrderBy(x => x.CategoryName).ToListAsync();
        }

        public static void MockAdd()
        {
            var lorem = new Bogus.DataSets.Lorem(locale: "en");
            using var context = new Context();
            Note note = new Note() { BodyText = lorem.Paragraph(), CategoryId = 3, DueDate = DateTime.Now, Completed = true};
            
            context.Attach(note);
            context.SaveChanges();

        }

        public static bool Update(Note note)
        {
            using var context = new Context();
            context.Attach(note).State = EntityState.Modified;
            return context.SaveChanges() == 1;
        }
    }
}
