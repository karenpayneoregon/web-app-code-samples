using FluentValidation;
using HoursApplication.ExtensiionMethods;
using HoursApplication.Models;

namespace HoursApplication.Validators;

public class TimesContainerValidator : AbstractValidator<TimesContainer>
{
    public TimesContainerValidator()
    {

        string message = string.Empty;

        RuleFor(tc => tc)
            .Must(tc =>
            {
                if (tc.StartTime < new TimeSpan(0,7,59,0))
                {
                    message = "Start must be 8 AM or higher";
                    return false;
                }

                if (tc.StartTime > tc.EndTime)
                {
                    message = $"{nameof(tc.EndTime).SplitCamelCase()} is not valid";
                    return false;
                }

                if (tc.EndTime == tc.StartTime)
                {
                    message = "Times can not be equal";
                    return false;
                }
  
                return true;
            })
            .WithMessage((_) => message);

    }
}

