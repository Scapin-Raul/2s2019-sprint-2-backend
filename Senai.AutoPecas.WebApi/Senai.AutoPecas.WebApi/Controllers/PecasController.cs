using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interfaces;
using Senai.AutoPecas.WebApi.Repositories;

namespace Senai.AutoPecas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PecasController : ControllerBase
    {
        public IPecasRepository PecasRepository { get; set; }

        public PecasController()
        {
            PecasRepository = new PecasRepository();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Cadastrar(Pecas pecas)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            pecas.IdFornecedor = Convert.ToInt32(identity.FindFirst(ClaimTypes.Role).Value);

            try
            {
                PecasRepository.Cadastrar(pecas);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex });
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var idFornecedor = Convert.ToInt32(identity.FindFirst(ClaimTypes.Role).Value);
            return Ok(PecasRepository.ListarPorId(idFornecedor));
        }


        [Authorize]
        [HttpGet("{idPeca}")]
        public IActionResult BuscarPorId(int idPeca)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var idFornecedor = Convert.ToInt32(identity.FindFirst(ClaimTypes.Role).Value);

            try
            {
                var pecaRecuperada = PecasRepository.BuscarPorId(idPeca, idFornecedor);
                return Ok(pecaRecuperada);
            }
            catch (Exception)
            {
                return BadRequest("Id inválido ou não é seu.");
            }
        }

        [Authorize]
        [HttpGet("{idPeca}")]
        public IActionResult Alterar(int idPeca, Pecas peca)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var idFornecedor = Convert.ToInt32(identity.FindFirst(ClaimTypes.Role).Value);
            peca.IdPeca = idPeca;

            try
            {
                PecasRepository.Alterar(peca, idFornecedor);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }



        [HttpGet("calcular/{qtd}/{idpeca}")]
        public IActionResult Calcular(int qtd, int idpeca)
        {
            var preco =PecasRepository.Calcular(qtd, idpeca);
            if (preco == -1) return BadRequest(new { mensagem = "Peça não existente."});
            return Ok(new { preco = preco });
        }



        [HttpGet("precos")]
        public IActionResult Precos()
        {
            return Ok(PecasRepository.Precos());
        }



    }
}