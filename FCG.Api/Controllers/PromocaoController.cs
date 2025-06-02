using FCG.Core.DTO;
using FCG.Core.Entity;
using FCG.Core.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCG.Api.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class PromocaoController : ControllerBase
    {
        private readonly IPromocaoRepository _promocaoRepository;
        private readonly IJogoRepository _jogoRepository;

        public PromocaoController(IPromocaoRepository promocaoRepository, IJogoRepository jogoRepository)
        {
            _promocaoRepository = promocaoRepository;
            _jogoRepository = jogoRepository;
        }

        [Authorize(Policy = "Admin")]
        [HttpPost]
        public IActionResult Post([FromBody] PromocaoDTO input)
        {
            try
            {

                Jogo jogo = _jogoRepository.GetById(input.JogoId);
                if (jogo == null)
                {
                    return StatusCode(StatusCodes.Status201Created, "Jogo não cadastrado");
                }
                var promocao = new Promocao()
                {
                    JogoId = input.JogoId,
                    DataInicio = input.DataInicio,
                    DataFim = input.DataFim,
                    ValorPromocao = input.ValorPromocao

                };
                
                _promocaoRepository.Insert(promocao);

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
                _promocaoRepository.Delete(id);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            return Ok();
        }
    }
}
