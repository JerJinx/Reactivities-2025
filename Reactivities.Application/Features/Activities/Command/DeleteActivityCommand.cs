using MediatR;
using Reactivities.Application.Common;
using Reactivities.Infrastructure.Persistence;

namespace Reactivities.Application.Features.Activities.Command;

public class DeleteActivityCommand(string id) : IRequest<Result<Unit>>
{
    public string Id { get; set; } = id;
}

public class DeleteActivityCommandHandler(AppDbContext context) : IRequestHandler<DeleteActivityCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(DeleteActivityCommand request, CancellationToken cancellationToken)
    {
        var activity = await context.Activities.FindAsync([request.Id], cancellationToken);

        if (activity == null) return Result<Unit>.Failure("Activity not found", 404);

        context.Remove(activity);

        var result = await context.SaveChangesAsync(cancellationToken) > 0;

        if (!result) return Result<Unit>.Failure("Failed to delete the activity", 400);

        return Result<Unit>.Success(Unit.Value);
    }
}