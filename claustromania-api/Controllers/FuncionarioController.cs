using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Claustromania.Dtos;
using Claustromania.Models;
using Claustromania.DataContexts;
using Microsoft.EntityFrameworkCore;
using Claustromania.Services;


namespace Claustromania.Controllers
{
    [Route("funcionario")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly FuncionarioService _service;

        public FuncionarioController(FuncionarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listafuncionarios = await _service.GetAll();

            return Ok(listafuncionarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            try
            {
                var funcionarios = await _service.GetOneById(id);

                if (funcionarios is null)
                {
                    return NotFound("Informacao nao encontrada!");
                }

                return Ok(funcionarios);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FuncionarioDto item)
        {
            try
            {
                var funcionarios = await _service.Create(item);

                if (funcionarios is null)
                {
                    return Problem("Ocorreram erros ao salvar!");
                }

                return Created("", funcionarios);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.InnerException?.Message ?? ex.Message);
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] FuncionarioDto item)
        {
            try
            {
                var funcionarios = await _service.Update(id, item);

                if (funcionarios is null)
                    return NotFound();

                return Ok(funcionarios);
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
