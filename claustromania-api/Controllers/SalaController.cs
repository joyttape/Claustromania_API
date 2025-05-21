using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Claustromania.Dtos;
using Claustromania.Models;
using Claustromania.DataContexts;
using Microsoft.EntityFrameworkCore;
using Claustromania.Services;

namespace Claustromania.Controllers
{
    [Route("salas")]
    [ApiController]
    public class SalaController : ControllerBase
    {
        private readonly SalaService _service;

        public SalaController(SalaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listasalas = await _service.GetAll();

            return Ok(listasalas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            try
            {
                var salas = await _service.GetOneById(id);

                if (salas is null)
                {
                    return NotFound("Informacao nao encontrada!");
                }

                return Ok(salas);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SalaDto item)
        {
            try
            {
                var sala = await _service.Create(item);

                if (sala is null)
                {
                    return Problem("Ocorreram erros ao salvar!");
                }

                return Created("", sala);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.InnerException?.Message ?? ex.Message);
                throw;
            }


        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SalaDto item)
        {
            try
            {
                var sala = await _service.Update(id, item);

                if (sala is null)
                    return NotFound();

                return Ok(sala);
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
                var sala = await _service.Delete(id);

                if (sala == null)
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
