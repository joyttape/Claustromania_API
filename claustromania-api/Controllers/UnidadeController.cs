using AutoMapper;
using Claustromania.Dtos;
using Claustromania.DTOs;
using Claustromania.Models;
using Claustromania.Data;
using Claustromania.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class UnidadeController : ControllerBase
{
    private readonly UnidadeService _service;
    private readonly IMapper _mapper;
    private readonly ClaustromaniaDbContext _context;
    
    public UnidadeController(UnidadeService service, IMapper mapper, ClaustromaniaDbContext context)
    {
        _service = service;
        _mapper = mapper;
        _context = context;
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
    public async Task<ActionResult<UnidadeDto>> Create([FromBody] UnidadeCreateDto dto)
    {
        var criada = await _service.CreateWithEnderecoAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = criada.Id }, _mapper.Map<UnidadeDto>(criada));
    }



    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UnidadeCreateDto dto)
    {
        var entidade = _mapper.Map<Unidade>(dto);
        entidade.Id = id;

        var atualizado = await _service.UpdateAsync(entidade);
        return atualizado ? NoContent() : NotFound();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deletado = await _service.DeleteAsync(id);
        return deletado ? NoContent() : NotFound();
    }
}
