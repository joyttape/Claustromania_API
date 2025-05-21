using Microsoft.AspNetCore.Mvc;
using Claustromania.Dtos;
using Claustromania.Services;

namespace Claustromania.Controllers
{
    [Route("pessoa")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly PessoaService _service;

        public PessoaController(PessoaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listaPessoas = await _service.GetAll();
            return Ok(listaPessoas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            try
            {
                var pessoa = await _service.GetOneById(id);
                return pessoa is null ? NotFound() : Ok(pessoa);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PessoaDto item)
        {
            try
            {
                var pessoa = await _service.Create(item);
                return pessoa is null ? Problem("Erro ao criar") : Created("", pessoa);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.InnerException?.Message ?? ex.Message);
                return Problem(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PessoaDto item)
        {
            try
            {
                var pessoa = await _service.Update(id, item);
                return pessoa is null ? NotFound() : Ok(pessoa);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var pessoa = await _service.Delete(id);
                return pessoa is null ? NotFound() : NoContent();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}