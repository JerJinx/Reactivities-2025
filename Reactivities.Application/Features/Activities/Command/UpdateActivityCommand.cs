using AutoMapper;
using FluentValidation;
using MediatR;
using Reactivities.Application.Common;
using Reactivities.Application.Features.Activities.DTOs;
using Reactivities.Infrastructure.Persistence;

namespace Reactivities.Application.Features.Activities.Command;

public class UpdateActivityCommand : IRequest<Result<Unit>>
{
    public required UpdateActivityDto ActivityDto { get; set; }
}

public class UpdateActivityCommandHandler(AppDbContext context, IMapper mapper) : IRequestHandler<UpdateActivityCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(UpdateActivityCommand request, CancellationToken cancellationToken)
    {
        var activity = await context.Activities.FindAsync([request.ActivityDto.Id], cancellationToken);
        
        if (activity == null) return Result<Unit>.Failure("Activity not found", 404);

        mapper.Map(request.ActivityDto, activity);

        var result = await context.SaveChangesAsync(cancellationToken) > 0;

        if (!result) return Result<Unit>.Failure("Failed to update the activity", 400);

        return Result<Unit>.Success(Unit.Value);
    }
}

public class UpdateActivityValidator : BaseActivityValidator<UpdateActivityCommand, UpdateActivityDto>
{
    public UpdateActivityValidator() : base(x => x.ActivityDto)
    {
        RuleFor(a => a.ActivityDto.Id)
            .NotEmpty().WithMessage("Id is required");
    }
}