using AutoMapper;
using CrimeService.Data.DTOs;
using CrimeService.Data.Repository;
using CrimeService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrimeService.Controllers
{
    [Route("crimes")]
    [ApiController]
    public class CrimeEventsController : ControllerBase
    {
        private readonly IAsyncRepository<CrimeEvent> _crimeRepository;
        private readonly IMapper _mapper;
        public CrimeEventsController(IAsyncRepository<CrimeEvent> crimeRepository, IMapper mapper)
        {
            _crimeRepository = crimeRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IList<CrimeEvent>>> GetAllCrimeEvents()
        {
            var AllCrimes = await _crimeRepository.GetAllAsync();
            if (AllCrimes.Count == 0)
            {
                return NotFound("The crimes collection is empty.");
            }
            return Ok(_mapper.Map<IList<CrimeEventReadDto>>(AllCrimes));
        }
        [HttpGet("id", Name = "GetSpecificCrimeEvent")]
        public async Task<ActionResult<CrimeEvent>> GetSpecificCrimeEvent(Guid id)
        {
            var CrimeWithId = await _crimeRepository.GetByIdAsync(id);
            if (CrimeWithId is null)
            {
                return NotFound("A crime with given id not existent.");
            }
            return Ok(_mapper.Map<CrimeEventReadDto>(CrimeWithId));
        }
        [HttpPost]
        public async Task<ActionResult> CreateCrimeEvent(CrimeEventCreateDto dto)
        {
            CrimeEvent CrimeFromUser = _mapper.Map<CrimeEvent>(dto);
            await _crimeRepository.AddAsync(CrimeFromUser);
            await _crimeRepository.SaveAsync();
            CrimeEventReadDto CrimeInReadFormat = _mapper.Map<CrimeEventReadDto>(CrimeFromUser);
            return CreatedAtRoute(nameof(GetSpecificCrimeEvent), new { Id = CrimeInReadFormat.Id }, CrimeInReadFormat);
        }
        [Route("assign")]
        [HttpPost]
        public async Task<ActionResult> AssignUnitToEvent([FromQuery] CrimeAssignViewModel requestModel)
        {
            Console.WriteLine(requestModel.unitId);
            Console.WriteLine(requestModel.crimeId);
            var Crime = await _crimeRepository.GetByIdAsync(requestModel.crimeId);
            if (Crime is null)
            {
                return BadRequest();
            }
            if (Crime.LawEnforcement != String.Empty)
            {
                return BadRequest();
            }
            Crime.LawEnforcement = requestModel.unitId;
            await _crimeRepository.SaveAsync();
            return Ok();
        }
    }
}
