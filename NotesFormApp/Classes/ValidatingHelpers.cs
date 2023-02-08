using System.Text;
using FluentValidation.Results;

namespace NotesFormApp.Classes;

public static class ValidatingHelpers
{
    public static string PresentErrorMessage(this ValidationResult sender)
    {
        StringBuilder builder = new();

        sender.Errors.Select(validationFailure => validationFailure.ErrorMessage)
            .ToList()
            .ForEach(x => builder.AppendLine(x));

        return builder.Length == 0 ?
            "Valid" :
            builder.ToString();

    }
}