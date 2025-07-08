using Claustromania.DTOs;
using Claustromania.Models;
using Claustromania.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Claustromania.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalaJogoController : ControllerBase
    {
        private readonly SalaJogoService _service;
        private readonly IMapper _mapper;

        public SalaJogoController(SalaJogoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalaJogoDto>>> GetAll()
        {
            var registros = await _service.GetAllAsync();
            return Ok(_mapper.Map<List<SalaJogoDto>>(registros));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SalaJogoDto>> GetById(Guid id)
        {
            var registro = await _service.GetByIdAsync(id);
            return registro == null ? NotFound() : Ok(_mapper.Map<SalaJogoDto>(registro));
        }

        [HttpPost]
        public async Task<ActionResult<SalaJogoDto>> Create([FromBody] SalaJogoDto dto)
        {
            var entity = _mapper.Map<SalaJogo>(dto);
            var created = await _service.CreateAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, _mapper.Map<SalaJogoDto>(created));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] SalaJogoDto dto)
        {
            if (id != dto.Id) return BadRequest();
            var updated = await _service.UpdateAsync(_mapper.Map<SalaJogo>(dto));
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
