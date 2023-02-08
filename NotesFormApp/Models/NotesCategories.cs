using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesFormApp.Models
{
    public class NotesCategories
    {
        public int NoteId { get; }
        public int? CategoryId { get; }
        public string BodyText { get; }
        public DateTime? DueDate { get; }
        public bool? Completed { get; }
        public string CategoryName { get; set; }

        public NotesCategories(int noteId, int? categoryId, string bodyText, DateTime? dueDate, bool? completed, string categoryName)
        {
            NoteId = noteId;
            CategoryId = categoryId;
            BodyText = bodyText;
            DueDate = dueDate;
            Completed = completed;
            CategoryName = categoryName;
        }
    }
}
