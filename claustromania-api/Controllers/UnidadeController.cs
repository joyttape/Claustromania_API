using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Claustromania.Dtos;
using Claustromania.Models;
using Claustromania.DataContexts;
using Microsoft.EntityFrameworkCore;
using Claustromania.Services;

namespace Claustromania.Controllers
{

    [Route("unidades")]
    [ApiController]
    public class UnidadeController : ControllerBase
    {
        private readonly UnidadeService _service;

        public UnidadeController(UnidadeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var unidades = await _service.GetAll();
            return Ok(unidades);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var unidade = await _service.GetOneById(id);

                if (unidade is null)
                    return NotFound("Unidade não encontrada!");

                return Ok(unidade);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UnidadeDto item)
        {
            try
            {
                var unidade = await _service.Create(item);

                if (unidade is null)
                    return Problem("Erro ao criar unidade");

                return CreatedAtAction(nameof(GetById), new { id = unidade.Id }, unidade);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.InnerException?.Message ?? ex.Message);
                return Problem("Ocorreu um erro interno");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UnidadeDto item)
        {
            try
            {
                var unidade = await _service.Update(id, item);

                if (unidade is null)
                    return NotFound();

                return Ok(unidade);
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
                var unidade = await _service.Delete(id);

                if (unidade == null)
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
