using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using MediatR;
using Application.Activities;

namespace API.Controllers
{
    public class ActivitiesController : baseApiController
    {
    //     private readonly IMediator _Mediator;
    //     public ActivitiesController(IMediator Mediator)
    //     {
    //        _Mediator=Mediator;
    //     }
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetAllActivities(CancellationToken sethu)
        {
            return await mediator.Send(new List.Query(),sethu);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivityById(Guid id)
        {
            return await mediator.Send(new Details.Query{Id = id});
        }
        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity)
        {
            return Ok(await mediator.Send(new Create.Command{Activity = activity}));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity(Guid id,Activity activity)
        {
          activity.Id=id;
          return Ok(await mediator.Send(new Edit.Command{Activity = activity}));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            return Ok(await mediator.Send(new Delete.Command{Id = id}));
        }
    }
}