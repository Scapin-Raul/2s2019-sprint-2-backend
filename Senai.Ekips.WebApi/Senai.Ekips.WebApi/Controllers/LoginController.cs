using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.Repositories;

namespace Senai.Ekips.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        UsuarioRepository usuarioRepository = new UsuarioRepository();

        [HttpPost]
        public IActionResult Login(Usuarios login)
        {
            try
            {
                Usuarios Usuario = usuarioRepository.BuscarPorEmailESenha(login);
                if (Usuario == null)
                    return NotFound(new { mensagem = "Email ou senha inválidos." });

                var claims = new[]
                {
                    // email
                    new Claim(JwtRegisteredClaimNames.Email, Usuario.Email),
                    // id
                    new Claim(JwtRegisteredClaimNames.Jti, Usuario.IdUsuario.ToString()),
                    // é a permissão do usuário
                    new Claim(ClaimTypes.Role, Usuario.Permissao),
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Ekips-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "Ekips.WebApi",
                    audience: "Ekips.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                // gerar a chave pra vocês
                // return Ok(new { mensagem = "Sucesso, bro." });
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });

            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro." + ex.Message });
            }
        }

    }
}