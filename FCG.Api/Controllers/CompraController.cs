using FCG.Core.DTO;
using FCG.Core.Entity;
using FCG.Core.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCG.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly IJogoRepository _jogoRepository;
        private readonly IBibliotecaRepository _bibliotecaReposiory;

        public CompraController(IJogoRepository jogoRepository, IBibliotecaRepository bibliotecaReposiory)
        {
            _jogoRepository = jogoRepository;
            _bibliotecaReposiory = bibliotecaReposiory;
        }

        [HttpPost]
        [Authorize(Policy = "User")]
        public IActionResult Post([FromBody] CompraDTO input)
        {

            try
            {
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "userId");
                var userId = userIdClaim?.Value.ToString();
                if (!int.TryParse(userId, out int idUsuario))
                {
                    return BadRequest();
                }
                Jogo jogo = _jogoRepository.GetById(input.idJogo);
                if (jogo == null)
                {
                    return NotFound("Jogo não cadastrado");
                }

                var biblioteca = new Biblioteca()
                {
                    UsuarioId = idUsuario,
                    JogoId = input.idJogo
                };
                _bibliotecaReposiory.Insert(biblioteca);
                    

                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            
        }

    }
}
