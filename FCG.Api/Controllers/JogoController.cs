using FCG.Core.Entity;
using FCG.Core.DTO;
using FCG.Core.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCG.Api.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class JogoController : ControllerBase
    {
        private readonly IJogoRepository _jogoRepository;

        public JogoController(IJogoRepository jogoRepository)
        {
            _jogoRepository = jogoRepository;
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
        public IActionResult Post([FromBody] JogoDTO input)
        {
            try
            {
                var jogo = new Jogo()
                {
                    Nome = input.Nome,
                    Categoria = input.Categoria,
                    ValorCompra = input.Valor

                };
                _jogoRepository.Insert(jogo);

                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Authorize(Policy = "Admin")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _jogoRepository.Delete(id);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            return Ok();
        }
    }
}
