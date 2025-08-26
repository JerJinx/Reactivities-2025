using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Reactivities.Domain.Entities;
using Reactivities.Infrastructure.Persistence;

namespace Reactivities.Application.Features.Activities.Command;

public class UpdateActivityCommand : IRequest
{
    public required Activity Activity { get; set; }
}

public class UpdateActivityCommandHandler(AppDbContext context, IMapper mapper) : IRequestHandler<UpdateActivityCommand>
{
    public async Task Handle(UpdateActivityCommand request, CancellationToken cancellationToken)
    {
        var activity = await context.Activities.FindAsync([request.Activity.Id], cancellationToken) ?? throw new Exception("Cannot find activity");

        mapper.Map(request.Activity, activity);
        
        await context.SaveChangesAsync(cancellationToken);
    }
}
