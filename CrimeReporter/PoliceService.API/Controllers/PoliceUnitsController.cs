using MediatR;
using Microsoft.AspNetCore.Mvc;
using PoliceService.Application.Functions.PoliceUnits.Commands.CreatePoliceUnitCommand;
using PoliceService.Application.Functions.PoliceUnits.Queries.GetPoliceUnitsList;
using PoliceService.Application.Functions.PoliceUnits.Queries.GetSpecificPoliceUnit;
using PoliceService.Domain.Entities;

namespace PoliceService.API.Controllers
{
    [Route("units")]
    [ApiController]
    public class PoliceUnitsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PoliceUnitsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IList<PoliceUnit>>> GetAllUnits()
        {
            var AllUnits = await _mediator.Send(new GetPoliceUnitsListQuery());

            return Ok(AllUnits);
        }
        [HttpGet("id", Name = "GetSpecificCrimeEvent")]
        public async Task<ActionResult<PoliceUnit>> GetSpecificCrimeEvent(string id)
        {
            var AllUnits = await _mediator.Send(new GetSpecificPoliceUnitQuery() { Id = id });

            return Ok(AllUnits);
        }
        [HttpPost]
        public async Task<ActionResult> CreateCrimeEvent([FromBody] CreatePoliceUnitCommand unitDto)
        {
            var Result = await _mediator.Send(unitDto);

            if (Result.Success == false)
            {
                return BadRequest(Result.Message);
            }
            return Ok(Result.PoliceUnitId);
        }
    }
}
