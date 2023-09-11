using Chapter.Interfacies;
using Chapter.Models;
using Chapter.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Chapter.Controlers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _iUsuarioRepository; //variavel declarada do tipo IUsuarioRepository(interface)
        public LoginController(IUsuarioRepository iUsuarioRepository)
        {
            _iUsuarioRepository = iUsuarioRepository;
        }

        [HttpPost] //Post para enviar informações
        public IActionResult Login(LoginViewModel login)
        {
            Usuario UsuarioEncontrado = _iUsuarioRepository.Login(login.Email, login.Senha); //Irá passa o usuario e senha para a variavel UsuarioEncontrado do tipo _iUsuarioRepository que foi encontrado no banco

            if (UsuarioEncontrado == null)
            {
                 return Unauthorized(new {msg = "Email ou Senha Invalidos"}); //usuario ou senha não encontrados
            }

            var minhasclaims = new[]
            {
             new Claim(JwtRegisteredClaimNames.Email, UsuarioEncontrado.Email), //esta jogando o que agente pegou no claim
             new Claim(JwtRegisteredClaimNames.Jti, UsuarioEncontrado.Id.ToString()),
             new Claim(ClaimTypes.Role, UsuarioEncontrado.Tipo)
             
            };

            var chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("chapter-chave-autenticacao")); //passa a chave simetrica que está codifiacda
            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256); //passa o HmacSha para a variavel

            var meuTokem = new JwtSecurityToken(

                issuer: "Chapter.webapi",
                audience: "Chapter.webapi",
                claims: minhasclaims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credenciais

                 );

            return Ok(
                new {token = new JwtSecurityTokenHandler().WriteToken(meuTokem)  }
                );
        }
    }
}
