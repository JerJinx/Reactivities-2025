using AutoMapper;
using FluentValidation;
using MediatR;
using Reactivities.Application.Common;
using Reactivities.Application.Features.Activities.DTOs;
using Reactivities.Domain.Entities;
using Reactivities.Infrastructure.Persistence;

namespace Reactivities.Application.Features.Activities.Command;

public class CreateActivityCommand : IRequest<Result<string>>
{
    public required CreateActivityDto ActivityDto { get; set; }
}

public class CreateActivityCommandHandler(AppDbContext context, IMapper mapper) : IRequestHandler<CreateActivityCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
    {
        var activity = mapper.Map<Activity>(request.ActivityDto);

        context.Activities.Add(activity);

        var result = await context.SaveChangesAsync(cancellationToken) > 0;

        if (!result) return Result<string>.Failure("Failed to create the activity", 400);

        return Result<string>.Success(activity.Id);
    }
}

public class CreateActivityValidator : BaseActivityValidator<CreateActivityCommand, CreateActivityDto>
{
    public CreateActivityValidator() : base(x => x.ActivityDto)
    {
    }
}