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
    public class JogoController : ControllerBase
    {
        private readonly JogoService _service;
        private readonly IMapper _mapper;

        public JogoController(JogoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JogoDto>>> GetAll()
        {
            var jogos = await _service.GetAllAsync();
            return Ok(_mapper.Map<List<JogoDto>>(jogos));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JogoDto>> GetById(Guid id)
        {
            var jogo = await _service.GetByIdAsync(id);
            return jogo == null ? NotFound() : Ok(_mapper.Map<JogoDto>(jogo));
        }

        [HttpPost]
        public async Task<ActionResult<JogoDto>> Create([FromBody] JogoDto dto)
        {
            var entity = _mapper.Map<Jogo>(dto);
            var created = await _service.CreateAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, _mapper.Map<JogoDto>(created));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] JogoDto dto)
        {
            if (id != dto.Id) return BadRequest();
            var updated = await _service.UpdateAsync(_mapper.Map<Jogo>(dto));
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
