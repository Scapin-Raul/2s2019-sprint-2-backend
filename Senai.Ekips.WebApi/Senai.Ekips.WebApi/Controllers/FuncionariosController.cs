using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.Repositories;

namespace Senai.Ekips.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        FuncionarioRepository funcionarioRepository = new FuncionarioRepository();

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {

            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var permissao = identity.FindFirst(ClaimTypes.Role).Value;

                if (permissao.Equals("ADMINISTRADOR"))
                {
                    return Ok(funcionarioRepository.Listar());
                }

                //IEnumerable<Claim> claims = identity.Claims;
                // or
                var id = identity.FindFirst(JwtRegisteredClaimNames.Jti).Value;

                return Ok(funcionarioRepository.BuscarPorId(Convert.ToInt32(id)));
            }
            return NotFound();
        }



        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Funcionarios funcionario)
        {
            try
            {
                funcionarioRepository.Cadastrar(funcionario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Funcionarios funcionario)
        {
            funcionario.IdFuncionario = id;
            try
            {
                funcionarioRepository.Alterar(funcionario);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                funcionarioRepository.Deletar(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }








    }
}