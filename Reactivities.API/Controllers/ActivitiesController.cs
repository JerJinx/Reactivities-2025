using Microsoft.AspNetCore.Mvc;
using Reactivities.Application.Features.Activities.Command;
using Reactivities.Application.Features.Activities.DTOs;
using Reactivities.Application.Features.Activities.Queries;
using Reactivities.Domain.Entities;

namespace Reactivities.API.Controllers;

public class ActivitiesController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetAll([FromQuery] GetAllActivitiesQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetById(string id)
    {
        return HandleResult(await Mediator.Send(new GetActivityByIdQuery(id)));
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateActivity(CreateActivityDto activity)
    {
        return HandleResult(await Mediator.Send(new CreateActivityCommand { ActivityDto = activity }));
    }

    [HttpPut]
    public async Task<ActionResult> UpdateActiviy(UpdateActivityDto activity)
    {
        return HandleResult(await Mediator.Send(new UpdateActivityCommand { ActivityDto = activity }));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteActivity(string id)
    {
        return HandleResult(await Mediator.Send(new DeleteActivityCommand(id)));
    }
}
