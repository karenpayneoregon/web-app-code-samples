using NotesFormApp.Models;

namespace NotesFormApp.Classes;

public class NoteValidator : AbstractValidator<Note>
{
    public NoteValidator()
    {
        RuleFor(note => note.BodyText)
            .NotEmpty()
            .MinimumLength(5);

        RuleFor(note => note.DueDate)
            .GreaterThan(DateTime.Now.AddDays(-1));
    }
}