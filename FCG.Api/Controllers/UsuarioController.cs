using FCG.Core.Entity;
using FCG.Core.DTO;
using FCG.Core.Repository;
using Microsoft.AspNetCore.Mvc;
using FCG.Core.Services.Interface;

namespace FCG.Api.Controllers
{

    [ApiController]
    [Route("/[controller]")]
    public class UsuarioController: ControllerBase
    {

        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioRepository usuarioRepository, IUsuarioService usuarioService)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] UsuarioDTO input)
        {
            try
            {
                var usuario = new Usuario()
                {
                    Nome = input.Nome,
                    Email = input.Email,
                    Admin = input.Admin

                };

                if (!_usuarioService.CriptografaSenha(input.Senha, usuario))
                {
                    return BadRequest("Erro ao criar o usuário");
                };
                _usuarioRepository.Insert(usuario);

                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

    }
}
