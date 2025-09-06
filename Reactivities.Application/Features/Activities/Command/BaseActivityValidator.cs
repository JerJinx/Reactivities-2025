using FluentValidation;
using Reactivities.Application.Features.Activities.DTOs;

namespace Reactivities.Application.Features.Activities.Command;

public class BaseActivityValidator<T, TDto> : AbstractValidator<T> where TDto : BaseActivityDto
{
    public BaseActivityValidator(Func<T, TDto> selector)
    {        
        RuleFor(a => selector(a).Title)
            .NotEmpty().WithMessage("Title is required")
            .MaximumLength(100).WithMessage("Title must no exceed 100 characters");
        RuleFor(a => selector(a).Description)
            .NotEmpty().WithMessage("Description is required");
        RuleFor(a => selector(a).Date)
            .GreaterThan(DateTime.UtcNow).WithMessage("Date must be in the future");
        RuleFor(a => selector(a).Category)
            .NotEmpty().WithMessage("Category is required");
        RuleFor(a => selector(a).City)
            .NotEmpty().WithMessage("City is required");
        RuleFor(a => selector(a).Venue)
            .NotEmpty().WithMessage("Venue is required");
        RuleFor(a => selector(a).Latitude)
            .NotEmpty().WithMessage("Latitude is required")
            .InclusiveBetween(-90,90).WithMessage("Latitude must be between -90 and 90");
        RuleFor(a => selector(a).Longitude)
            .NotEmpty().WithMessage("Longitude is required")
            .InclusiveBetween(-180, 180).WithMessage("Longitude must be between -180 and 180");
    }
}
