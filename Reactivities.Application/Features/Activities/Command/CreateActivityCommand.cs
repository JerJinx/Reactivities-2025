using MediatR;
using Reactivities.Domain.Entities;
using Reactivities.Infrastructure.Persistence;

namespace Reactivities.Application.Features.Activities.Command;

public class CreateActivityCommand : IRequest<string>
{
    public required Activity Activity { get; set; }
}

public class CreateActivityCommandHandler(AppDbContext context) : IRequestHandler<CreateActivityCommand, string>
{
    public async Task<string> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
    {
        context.Activities.Add(request.Activity);

        await context.SaveChangesAsync(cancellationToken);

        return request.Activity.Id;
    }
}