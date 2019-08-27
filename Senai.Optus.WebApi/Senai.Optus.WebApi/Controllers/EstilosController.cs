using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Optus.WebApi.Domains;
using Senai.Optus.WebApi.Repository;

namespace Senai.Optus.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class EstilosController : ControllerBase
    {
        EstiloRepository estiloRepository = new EstiloRepository();

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(estiloRepository.Listar());
        }


        [Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Estilos estilo = estiloRepository.BuscarPorId(id);
            if (estilo == null) return NotFound("Estilo não encontrado ");
            return Ok(estilo);    
        }

        [Authorize(Roles ="ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Estilos estilo)
        {
            try
            {
                estiloRepository.Cadastrar(estilo);
                return Ok();
            }
            catch (Exception ex) {
                return BadRequest();
            }
        }

        [Authorize(Roles ="ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                estiloRepository.Deletar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut]
        public IActionResult Alterar(Estilos estilo)
        {
            try
            {
                estiloRepository.Alterar(estilo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("quantidade")]
        public IActionResult Quantidade()
        {
            return Ok("O total de estilos é : "+estiloRepository.Listar().Count());
        }
          
        [HttpGet("{id}/artistas")]
        public IActionResult BuscarArtista(int id)
        {
            var a = estiloRepository.BuscarArtista(id);
            if (a == null) return NotFound("Não há artistas de tal estilo ou não há nenhum estilo com este id");
            return Ok(a);
        }
            
        [HttpGet("buscar/{nome}/artistas")]
        public IActionResult BuscarPeloNome(string nome)
        {
            var a = estiloRepository.BuscarPeloNome(nome);
            if (a == null) return NotFound("Não há artistas de tal estilo ou não há nenhum estilo com este nome");
            return Ok(a);
        }
        
    }
}