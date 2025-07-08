using Claustromania.DTOs;
using Claustromania.Models;
using Claustromania.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Claustromania.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalaController : ControllerBase
    {
        private readonly SalaService _service;
        private readonly IMapper _mapper;

        public SalaController(SalaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalaDto>>> GetAll()
        {
            var salas = await _service.GetAllAsync();
            return Ok(_mapper.Map<List<SalaDto>>(salas));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SalaDto>> GetById(Guid id)
        {
            var sala = await _service.GetByIdAsync(id);
            return sala == null ? NotFound() : Ok(_mapper.Map<SalaDto>(sala));
        }

        [HttpPost]
        public async Task<ActionResult<SalaDto>> Create([FromBody] SalaDto dto)
        {
            var entity = _mapper.Map<Sala>(dto);
            var created = await _service.CreateAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, _mapper.Map<SalaDto>(created));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] SalaDto dto)
        {
            if (id != dto.Id) return BadRequest();
            var updated = await _service.UpdateAsync(_mapper.Map<Sala>(dto));
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _service.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
