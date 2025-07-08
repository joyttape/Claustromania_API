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
    public class EnderecoController : ControllerBase
    {
        private readonly EnderecoService _service;
        private readonly IMapper _mapper;

        public EnderecoController(EnderecoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnderecoDto>>> GetAll()
        {
            var lista = await _service.GetAllAsync();
            return Ok(_mapper.Map<List<EnderecoDto>>(lista));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EnderecoDto>> GetById(Guid id)
        {
            var endereco = await _service.GetByIdAsync(id);
            return endereco == null ? NotFound() : Ok(_mapper.Map<EnderecoDto>(endereco));
        }

        [HttpPost]
        public async Task<ActionResult<EnderecoDto>> Create([FromBody] EnderecoDto dto)
        {
            var entity = _mapper.Map<Endereco>(dto);
            var criado = await _service.CreateAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = criado.Id }, _mapper.Map<EnderecoDto>(criado));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] EnderecoDto dto)
        {
            if (id != dto.Id) return BadRequest();
            var atualizado = await _service.UpdateAsync(_mapper.Map<Endereco>(dto));
            return atualizado ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var removido = await _service.DeleteAsync(id);
            return removido ? NoContent() : NotFound();
        }

        [HttpGet("Pessoas/{id}")] 
        public async Task<ActionResult<EnderecoDetalhadoDto>> GetByIdDetalhado(Guid id)
        {
            var enderecoComPessoas = await _service.GetByIdDetalhadoAsync(id);
            if (enderecoComPessoas == null) return NotFound();
            return Ok(_mapper.Map<EnderecoDetalhadoDto>(enderecoComPessoas));
        }
    }
}
