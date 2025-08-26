using MediatR;
using Microsoft.EntityFrameworkCore;
using Reactivities.Domain.Entities;
using Reactivities.Infrastructure.Persistence;

namespace Reactivities.Application.Features.Activities.Queries;

public class GetAllActivitiesQuery : IRequest<List<Activity>>
{

}
public class GetAllActivitiesQueryHandler(AppDbContext context) : IRequestHandler<GetAllActivitiesQuery, List<Activity>>
{
    public async Task<List<Activity>> Handle(GetAllActivitiesQuery request, CancellationToken cancellationToken)
    {
        return await context.Activities.ToListAsync(cancellationToken);
    }
}