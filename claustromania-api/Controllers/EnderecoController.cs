using Claustromania.Dtos;
using Claustromania.Services;
using Microsoft.AspNetCore.Mvc;

namespace Claustromania.Controllers
{
    [Route("endereço")]
    [ApiController]

    public class EnderecoController : ControllerBase
    {
        private readonly EnderecoService _service;

        public EnderecoController(EnderecoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listaend = await _service.GetAll();

            return Ok(listaend);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            try
            {
                var enderecos = await _service.GetOneById(id);

                if (enderecos is null)
                {
                    return NotFound("Informacao nao encontrada!");
                }

                return Ok(enderecos);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EnderecoDto item)
        {
            try
            {
                var endereco = await _service.Create(item);

                if (endereco is null)
                {
                    return Problem("Ocorreram erros ao salvar!");
                }

                return Created("", endereco);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.InnerException?.Message ?? ex.Message);
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EnderecoDto item)
        {
            try
            {
                var endereco = await _service.Update(id, item);

                if (endereco is null)
                    return NotFound();

                return Ok(endereco);
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
                var endereco = await _service.Delete(id);

                if (endereco == null)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
