using Claustromania.Dtos;
using Claustromania.Services;
using Microsoft.AspNetCore.Mvc;

namespace Claustromania.Controllers
{
    [Route("caixa")]
    [ApiController]
    public class CaixaController : ControllerBase
    {
        private readonly CaixaService _service;

        public CaixaController(CaixaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var caixas = await _service.GetAll();
            return Ok(caixas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(Guid id)
        {
            try
            {
                var caixa = await _service.GetOneById(id);

                if (caixa is null)
                    return NotFound("Caixa não encontrado!");

                return Ok(caixa);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CaixaDto dto)
        {
            try
            {
                var caixa = await _service.Create(dto);

                if (caixa is null)
                    return Problem("Erro ao salvar caixa!");

                return Created("", caixa);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] CaixaDto dto)
        {
            try
            {
                var caixa = await _service.Update(id, dto);

                if (caixa is null)
                    return NotFound("Caixa não encontrado!");

                return Ok(caixa);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var caixa = await _service.Delete(id);

                if (caixa is null)
                    return NotFound("Caixa não encontrado!");

                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
