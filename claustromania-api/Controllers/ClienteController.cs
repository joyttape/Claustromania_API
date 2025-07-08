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
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _service;
        private readonly IMapper _mapper;

        public ClienteController(ClienteService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> GetAll()
        {
            var clientes = await _service.GetAllAsync();
            return Ok(_mapper.Map<List<ClienteDto>>(clientes));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDto>> GetById(Guid id)
        {
            var cliente = await _service.GetByIdAsync(id);
            return cliente == null ? NotFound() : Ok(_mapper.Map<ClienteDto>(cliente));
        }

        [HttpPost]
        public async Task<ActionResult<ClienteDto>> Create([FromBody] ClienteDto dto)
        {
            var entity = _mapper.Map<Cliente>(dto);
            var created = await _service.CreateAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, _mapper.Map<ClienteDto>(created));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ClienteDto dto)
        {
            if (id != dto.Id) return BadRequest();
            var updated = await _service.UpdateAsync(_mapper.Map<Cliente>(dto));
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _service.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }

        [HttpGet("detalhado")] 
        public async Task<ActionResult<IEnumerable<ClienteDetalhadoDto>>> GetAllDetalhado()
        {
            var clientesComDetalhes = await _service.GetAllDetalhadoAsync();
            var clientesDto = _mapper.Map<List<ClienteDetalhadoDto>>(clientesComDetalhes);
            return Ok(clientesDto);
        }


        [HttpGet("detalhado/{id}")] 
        public async Task<ActionResult<ClienteDetalhadoDto>> GetByIdDetalhado(Guid id)
        {
            var clienteComDetalhes = await _service.GetByIdDetalhadoAsync(id);
            if (clienteComDetalhes == null) return NotFound();
            return Ok(_mapper.Map<ClienteDetalhadoDto>(clienteComDetalhes));
        }
    }
}
