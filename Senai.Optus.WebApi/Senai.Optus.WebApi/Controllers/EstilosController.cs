using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(estiloRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastar(Estilos estilo)
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
            try
            {
                var a = estiloRepository.BuscarArtista(id);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }




}
}