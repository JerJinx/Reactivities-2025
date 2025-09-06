using MediatR;
using Reactivities.Application.Common;
using Reactivities.Domain.Entities;
using Reactivities.Infrastructure.Persistence;

namespace Reactivities.Application.Features.Activities.Queries;

public class GetActivityByIdQuery(string id) : IRequest<Result<Activity>>
{
    public string Id { get; set; } = id;
}

public class GetActivityQueryHandler(AppDbContext context) : IRequestHandler<GetActivityByIdQuery, Result<Activity>>
{
    public async Task<Result<Activity>> Handle(GetActivityByIdQuery request, CancellationToken cancellationToken)
    {
            var activity = await context.Activities.FindAsync([request.Id], cancellationToken);

            if (activity == null) return Result<Activity>.Failure("Activity not found", 404);

            return Result<Activity>.Success(activity);
    }
}
