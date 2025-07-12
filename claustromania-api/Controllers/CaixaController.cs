using Claustromania.DTOs;
using Claustromania.Models;
using Claustromania.Data;
using Claustromania.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Claustromania.Dtos;

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

        [HttpGet("resumido")]
        public async Task<ActionResult<IEnumerable<CaixaResumidoDto>>> GetAllResumido()
        {
            var caixas = await _service.GetAllAsync();
            var caixasResumido = _mapper.Map<List<CaixaResumidoDto>>(caixas);
            return Ok(caixasResumido);
        }
        [HttpGet("resumido/{id}")]
        public async Task<ActionResult<CaixaResumidoDto>> GetByIdResumido(Guid id)
        {
            var caixa = await _service.GetByIdAsync(id);
            if (caixa == null)
                return NotFound();

            var dto = _mapper.Map<CaixaResumidoDto>(caixa);
            return Ok(dto);
        }

        [HttpPost("resumido")]
        public async Task<ActionResult<CaixaResumidoDto>> CreateResumido([FromBody] CaixaResumidoDto dto)
        {
            var caixa = _mapper.Map<Caixa>(dto);
            var created = await _service.CreateResumidoAsync(caixa);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, _mapper.Map<CaixaResumidoDto>(created));
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
        
    }
}
