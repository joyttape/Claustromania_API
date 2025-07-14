using Claustromania.DTOs;
using Claustromania.Models;
using Claustromania.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Claustromania.Dtos;

namespace Claustromania.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservaController : ControllerBase
    {
        private readonly ReservaService _service;
        private readonly IMapper _mapper;

        public ReservaController(ReservaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservaDto>>> GetAll()
        {
            var reservas = await _service.GetAllAsync();
            return Ok(_mapper.Map<List<ReservaDto>>(reservas));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReservaDto>> GetById(Guid id)
        {
            var reserva = await _service.GetByIdAsync(id);
            return reserva == null ? NotFound() : Ok(_mapper.Map<ReservaDto>(reserva));
        }

        [HttpPost]
        public async Task<ActionResult<ReservaDto>> Create([FromBody] CreateReservaDto dto)
        {
            try
            {
                var reserva = _mapper.Map<Reserva>(dto);
                var created = await _service.CreateAsync(reserva);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, _mapper.Map<ReservaDto>(created));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ReservaDto dto)
        {
            if (id != dto.Id) return BadRequest("ID inconsistente");

            try
            {
                var reserva = _mapper.Map<Reserva>(dto);
                var updated = await _service.UpdateAsync(reserva);
                return updated ? NoContent() : NotFound();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _service.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
