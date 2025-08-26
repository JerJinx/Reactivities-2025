using Microsoft.AspNetCore.Mvc;
using Reactivities.Application.Features.Activities.Command;
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
        var activity = await Mediator.Send(new GetActivityByIdQuery(id));
        return activity;
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateActivity(Activity activity)
    {
        return await Mediator.Send(new CreateActivityCommand { Activity = activity });
    }

    [HttpPut]
    public async Task<ActionResult> UpdateActiviy(Activity activity)
    {
        await Mediator.Send(new UpdateActivityCommand { Activity = activity });
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteActivity(string id)
    {
        await Mediator.Send(new DeleteActivityCommand(id));
        return Ok();
    }
}
