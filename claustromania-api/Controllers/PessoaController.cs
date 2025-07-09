using AutoMapper;
using Claustromania.Dtos;
using Claustromania.Models; // Adicionado para usar o modelo Pessoa diretamente
using Claustromania.Services;
using Microsoft.AspNetCore.Mvc;

namespace Claustromania.Controllers
{
    [ApiController]
    [Route("pessoa")]
    public class PessoaController : ControllerBase
    {
        private readonly PessoaService _service;
        private readonly IMapper _mapper;

        public PessoaController(PessoaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lista = await _service.GetAll();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(Guid id)
        {
            try
            {
                var pessoa = await _service.GetOneById(id);
                return pessoa is null ? NotFound() : Ok(pessoa);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, title: "Erro ao buscar pessoa");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PessoaDto item)
        {
            try
            {
                // A senha será hashed dentro do PessoaService
                var pessoaDtoResult = await _service.Create(item);
                return CreatedAtAction(nameof(GetOne), new { id = pessoaDtoResult.Id }, pessoaDtoResult);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, title: "Erro ao criar pessoa");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] PessoaDto item)
        {
            try
            {
                // A senha será hashed dentro do PessoaService se fornecida
                var pessoaDtoResult = await _service.Update(id, item);
                return pessoaDtoResult is null ? NotFound() : Ok(pessoaDtoResult);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, title: "Erro ao atualizar pessoa");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var sucesso = await _service.Delete(id);
                return sucesso ? NoContent() : NotFound();
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, title: "Erro ao excluir pessoa");
            }
        }

        [HttpGet("porCidade/{cidade}")]
        public async Task<ActionResult<IEnumerable<PessoaDto>>> GetByCidade(string cidade)
        {
            var pessoas = await _service.GetPessoasByCidadeAsync(cidade);
            return Ok(_mapper.Map<List<PessoaDto>>(pessoas));
        }
    }
}