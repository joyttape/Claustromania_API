using Claustromania.DTOs;
using Claustromania.Models;
using Claustromania.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Claustromania.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionarioController : ControllerBase
    {
        private readonly FuncionarioService _service;
        private readonly IMapper _mapper;

        public FuncionarioController(FuncionarioService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FuncionarioDto>>> GetAll()
        {
            var funcionarios = await _service.GetAllAsync();
            return Ok(_mapper.Map<List<FuncionarioDto>>(funcionarios));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FuncionarioDto>> GetById(Guid id)
        {
            var funcionario = await _service.GetByIdAsync(id);
            return funcionario == null ? NotFound() : Ok(_mapper.Map<FuncionarioDto>(funcionario));
        }

        [HttpPost]
        public async Task<ActionResult<FuncionarioDto>> Create([FromBody] FuncionarioDto dto)
        {
            var entity = _mapper.Map<Funcionario>(dto);
            var created = await _service.CreateAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, _mapper.Map<FuncionarioDto>(created));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] FuncionarioDto dto)
        {
            if (id != dto.Id) return BadRequest();
            var entity = _mapper.Map<Funcionario>(dto);
            var updated = await _service.UpdateAsync(entity);
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
