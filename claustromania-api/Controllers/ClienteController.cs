using Claustromania.DTOs;
using Claustromania.Models;
using Claustromania.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Claustromania.Enums;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet("by-email/{email}")]
        public async Task<ActionResult<ClienteDto>> GetByEmail(string email)
        {
            var cliente = await _service.GetByEmailAsync(email);
            return cliente == null ? NotFound() : Ok(_mapper.Map<ClienteDto>(cliente));
        }

        [HttpPost]
        public async Task<ActionResult<ClienteDto>> Create([FromBody] ClienteDto dto)
        {
            if (!Enum.IsDefined(typeof(NivelExperiencia), dto.NivelExperiencia))
            {
                return BadRequest("Nível de experiência inválido. Valores válidos: 0 (Explorador), 1 (Aventureiro), 2 (Veterano), 3 (Lendário).");
            }
            try
            {
                var entity = _mapper.Map<Cliente>(dto);
                var created = await _service.CreateAsync(entity);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, _mapper.Map<ClienteDto>(created));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(Guid id, [FromBody] ClienteDto dto)
        {
            try
            {
                if (id != dto.Id)
                    return BadRequest("ID na URL não corresponde ao ID no corpo da requisição");

                var cliente = _mapper.Map<Cliente>(dto);
                var resultado = await _service.UpdateAsync(cliente);

                if (!resultado)
                    return NotFound("Cliente não encontrado");

                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.InnerException?.Message);
            }

        }
       

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _service.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }

      
    }
}
