using EventPlus_.Domains.StringLenght;
using EventPlus_.Interfaces;
using EventPlus_.NovaPasta;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace EventPlus_.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _UsuarioRepository;
        public LoginController(IUsuarioRepository usuarioRepository)
        {
            _UsuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Endpoint para login
        /// </summary>
        /// <param name="loginDTO"></param>
        /// <returns></returns>
        [HttpPost]

        public IActionResult Login(loginDTO loginDTO)
        {
            try
            {
                Usuario usuarioBuscado = _UsuarioRepository.BuscarPorEmailESenha(loginDTO.Email!, loginDTO.Senha!);

                if (usuarioBuscado == null)
                {
                    return NotFound("Usuario nao encontrado, email ou senha invalidos");
                }

                //1 passo - definir as clains
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.UsuarioID.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email!),
                    new Claim(JwtRegisteredClaimNames.Name, usuarioBuscado.Nome!),

                    new Claim("Tipo do Usuario", usuarioBuscado.TipoUsuarios.TituloTipoUsuario!)
                };

                //2 passo - 
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Event-chave-autenticacao-webapi-dev"));

                //3 passo = definir as credenciais do token (header)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //4 passo - Gerar token
                var token = new JwtSecurityToken
                    (
                    //emissor do token
                    issuer: "EventPLus_",

                    //destinatario do token
                    audience: "EventPlus_",

                    claims: claims,

                    //Tempo de expiraçao do token
                    expires: DateTime.Now.AddMinutes(5),

                    //dados definidos nos claims
                    signingCredentials: creds



                    );

                //retorna o token criado
                return Ok
                    (
                    new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token)
                    }
                    );
            }

            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

    }
}

    

