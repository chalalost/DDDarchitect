using DDDarchitect.Domain.DomainModel.EventDomainModel.Entitites;
using DDDarchitect.Domain.DomainModel.EventDomainModel.Queries;
using Microservice.Framework.Common;
using Microservice.Framework.Domain.Commands;
using Microservice.Framework.Domain.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDDarchitect.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryProcessor _queryProcessor;

        public EventController(
            ICommandBus commandBus,
            IQueryProcessor queryProcessor)
        {
            _commandBus = commandBus;
            _queryProcessor = queryProcessor;
        }

        [HttpGet("getEvents")]
        public async Task<IActionResult> GetEvents(
            [FromQuery(Name = "categoryId")] string categoryId,
            [FromQuery(Name = "ids")] string[] ids)
        {
            var catId = categoryId.IsNotNullOrEmpty()
                ? new CategoryId(categoryId)
                : null;

            var result = await _queryProcessor
                .ProcessAsync(
                new GetMultiEventQuery(catId) { Ids = ids.Select(id => new EventDomain.EventId(id)).ToList() },
                CancellationToken.None);

            return Ok(new MapEventsToEventDtos(result.ToList().AsReadOnly()).Map());
        }

        [HttpGet("getEvent/{eventId}")]
        public async Task<IActionResult> GetEventsById(string eventId)
        {
            var result = await _queryProcessor
                .ProcessAsync(
                new GetEventQuery(new EventDomain.EventId(eventId)),
                CancellationToken.None);

            return Ok(new MapEventToEventDto(result).Map());
        }
    }
}
