using FluentValidation;

namespace HoursApplication.Classes;

public class TimesContainer
{
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}

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