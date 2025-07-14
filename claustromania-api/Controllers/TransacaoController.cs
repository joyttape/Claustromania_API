using Claustromania.DTOs;
using Claustromania.Models;
using Claustromania.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Claustromania.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransacaoController : ControllerBase
    {
        private readonly TransacaoService _service;
        private readonly IMapper _mapper;

        public TransacaoController(TransacaoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransacaoDto>>> GetAll()
        {
            var lista = await _service.GetAllAsync();
            return Ok(_mapper.Map<List<TransacaoDto>>(lista));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TransacaoDto>> GetById(Guid id)
        {
            var transacao = await _service.GetByIdAsync(id);
            return transacao == null ? NotFound() : Ok(_mapper.Map<TransacaoDto>(transacao));
        }

        [HttpPost]
        public async Task<ActionResult<TransacaoDto>> Create([FromBody] TransacaoDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, _mapper.Map<TransacaoDto>(created));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] TransacaoDto dto)
        {
            if (id != dto.Id) return BadRequest();
            var updated = await _service.UpdateAsync(id, dto);
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
