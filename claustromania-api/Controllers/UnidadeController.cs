using Claustromania.DTOs;
using Claustromania.Models;
using Claustromania.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Claustromania.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnidadeController : ControllerBase
    {
        private readonly UnidadeService _service;
        private readonly IMapper _mapper;

        public UnidadeController(UnidadeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnidadeDto>>> GetAll()
        {
            var unidades = await _service.GetAllAsync();
            return Ok(_mapper.Map<List<UnidadeDto>>(unidades));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UnidadeDto>> GetById(Guid id)
        {
            var unidade = await _service.GetByIdAsync(id);
            return unidade == null ? NotFound() : Ok(_mapper.Map<UnidadeDto>(unidade));
        }

        [HttpPost]
        public async Task<ActionResult<UnidadeDto>> Create([FromBody] UnidadeDto dto)
        {
            var entity = _mapper.Map<Unidade>(dto);
            var created = await _service.CreateAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, _mapper.Map<UnidadeDto>(created));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UnidadeDto dto)
        {
            if (id != dto.Id) return BadRequest();
            var updated = await _service.UpdateAsync(_mapper.Map<Unidade>(dto));
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
