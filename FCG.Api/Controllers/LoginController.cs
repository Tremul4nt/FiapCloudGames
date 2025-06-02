using FCG.Core.Entity;
using FCG.Core.Repository;
using FCG.Core.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FCG.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioService _usuarioService;

        public LoginController(IConfiguration configuration, IUsuarioRepository usuarioRepository, IUsuarioService usuarioService)
        {
            _configuration = configuration;
            _usuarioRepository = usuarioRepository;
            _usuarioService = usuarioService;
        }

        [HttpPost()]
        public IActionResult Login(string username, string password)
        {
            try
            {
                Usuario? usuario = _usuarioRepository.GetByNome(username);
                if (usuario == null)
                {
                    return NotFound("Usuário não cadastrado");
                }
                
                if (!_usuarioService.ValidaSenha(usuario, password))
                {
                    return BadRequest("Senha Incorreta");
                }


                if (usuario.Admin)
                {
                    var token = GenerateToken(username, "Admin", usuario.Id);
                    return Ok(new { token });
                }
                else
                {
                    var token = GenerateToken(username, "User", usuario.Id);
                    return Ok(new { token });
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }                
        }

        private string GenerateToken(string username, string role, int userId)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(ClaimTypes.Role, role),
                new Claim("userId",userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],                
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }       
    }
}
