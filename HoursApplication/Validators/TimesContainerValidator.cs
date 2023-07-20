using FluentValidation;
using HoursApplication.Models;

namespace HoursApplication.Validators;

public class TimesContainerValidator : AbstractValidator<TimesContainer>
{
    public TimesContainerValidator()
    {
        RuleFor(x => x.StartTime)
            .LessThan(x => x.EndTime)
            .WithMessage("Invalid");

        RuleFor(x => x.EndTime)
            .GreaterThan(x => x.StartTime)
            .WithMessage("Invalid");
    }
}