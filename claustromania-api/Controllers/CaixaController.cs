using Claustromania.DTOs;
using Claustromania.Models;
using Claustromania.Data;
using Claustromania.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Claustromania.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CaixaController : ControllerBase
    {
        private readonly CaixaService _service;
        private readonly IMapper _mapper;

        public CaixaController(CaixaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CaixaDto>>> GetAll()
        {
            var caixas = await _service.GetAllAsync();
            return Ok(_mapper.Map<List<CaixaDto>>(caixas));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CaixaDto>> GetById(Guid id)
        {
            var caixa = await _service.GetByIdAsync(id);
            return caixa == null ? NotFound() : Ok(_mapper.Map<CaixaDto>(caixa));
        }

        [HttpPost]
        public async Task<ActionResult<CaixaDto>> Create([FromBody] CaixaDto dto)
        {
            var entity = _mapper.Map<Caixa>(dto);
            var created = await _service.CreateAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, _mapper.Map<CaixaDto>(created));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CaixaDto dto)
        {
            if (id != dto.Id) return BadRequest();
            var updated = await _service.UpdateAsync(_mapper.Map<Caixa>(dto));
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _service.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
        [HttpGet("detalhado")]
        public async Task<ActionResult<IEnumerable<CaixaDto>>> GetAllDetalhado()
        {
            var caixasComDetalhes = await _service.GetAllDetalhadoAsync();
            var caixasDto = _mapper.Map<List<CaixaDto>>(caixasComDetalhes);
            return Ok(caixasDto);
        }


    }
}
