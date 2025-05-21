using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Claustromania.Dtos;
using Claustromania.Models;
using Claustromania.DataContexts;
using Microsoft.EntityFrameworkCore;
using Claustromania.Services;


namespace Claustromania.Controllers
{
    [Route("jogos")]
    [ApiController]
    public class JogoController : ControllerBase
    {
        private readonly JogoService _service;

        public JogoController(JogoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listajogos = await _service.GetAll();

            return Ok(listajogos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            try
            {
                var jogos = await _service.GetOneById(id);

                if (jogos is null)
                {
                    return NotFound("Informacao nao encontrada!");
                }

                return Ok(jogos);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] JogoDto jogo)
        {
            try
            {
                var jogos = await _service.Create(jogo);

                if (jogos is null)
                {
                    return Problem("Ocorreram erros ao salvar!");
                }

                return Created("", jogos);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.InnerException?.Message ?? ex.Message);
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] JogoDto item)
        {
            try
            {
                var jogos = await _service.Update(id, item);

                if (jogos is null)
                    return NotFound();

                return Ok(jogos);
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
                var jogo = await _service.Delete(id);

                if (jogo == null)
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
