using MediatR;
using Reactivities.Infrastructure.Persistence;

namespace Reactivities.Application.Features.Activities.Command;

public class DeleteActivityCommand(string id) : IRequest
{
    public string Id { get; set; } = id;
}

public class DeleteActivityCommandHandler(AppDbContext context) : IRequestHandler<DeleteActivityCommand>
{
    public async Task Handle(DeleteActivityCommand request, CancellationToken cancellationToken)
    {
        var activity = await context.Activities.FindAsync([request.Id], cancellationToken) ?? throw new Exception("Cannot find activity");

        context.Remove(activity);

        await context.SaveChangesAsync(cancellationToken);
    }
}