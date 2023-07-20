using FluentValidation;
using HoursApplication.Models;

namespace HoursApplication.Validators;

public class TimesContainerValidator : AbstractValidator<TimesContainer>
{
    public TimesContainerValidator()
    {

        RuleFor(x => x.StartTime)
            .LessThan(x => x.EndTime)
            .WithMessage("Can not be less than 8 AM")
            .GreaterThan(new TimeSpan(0,7,0,0))
            .WithMessage("{PropertyName} is not invalid");

        RuleFor(x => x.EndTime)
            .GreaterThan(x => x.StartTime)
            .WithMessage("{PropertyName} is not invalid");
    }
}