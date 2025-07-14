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
            try
            {
                if (id != dto.Id)
                    return BadRequest("ID na URL não corresponde ao ID no corpo da requisição");

                var funcionario = _mapper.Map<Funcionario>(dto);
                var resultado = await _service.UpdateAsync(funcionario);

                if (!resultado)
                    return NotFound("Cliente não encontrado");

                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.InnerException?.Message);
            }

        }

        [HttpGet("buscar-por-nome")]
public async Task<IActionResult> BuscarPorNome([FromQuery] string nome)
{
    var funcionarios = await _service.GetByNomeAsync(nome);
    var dtos = _mapper.Map<List<FuncionarioDto>>(funcionarios);
    return Ok(dtos);
}

[HttpGet("buscar-por-email")]
public async Task<IActionResult> BuscarPorEmail([FromQuery] string email)
{
    var funcionario = await _service.GetByEmailAsync(email);
    if (funcionario == null) return NotFound("Funcionário não encontrado.");
    var dto = _mapper.Map<FuncionarioDto>(funcionario);
    return Ok(dto);
}

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _service.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
