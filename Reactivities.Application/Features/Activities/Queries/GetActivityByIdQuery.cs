using MediatR;
using Reactivities.Domain.Entities;
using Reactivities.Infrastructure.Persistence;

namespace Reactivities.Application.Features.Activities.Queries;

public class GetActivityByIdQuery(string id) : IRequest<Activity>
{
    public string Id { get; set; } = id;
}

public class GetActivityQueryHandler(AppDbContext context) : IRequestHandler<GetActivityByIdQuery, Activity>
{
    public async Task<Activity> Handle(GetActivityByIdQuery request, CancellationToken cancellationToken)
    {
            var activity = await context.Activities.FindAsync([request.Id], cancellationToken);

            if (activity == null) throw new Exception("Activity not found.");

            return activity;
    }
}
