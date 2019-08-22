using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Sstop.WebApi.Domains;
using Senai.Sstop.WebApi.Repository;

namespace Senai.Sstop.WebApi.Controllers
{

    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ArtistasController : ControllerBase
    {
        ArtistaRepository ArtistaRepository = new ArtistaRepository();
        
        [HttpGet]
        public IActionResult Listar()
        {
            List<ArtistaDomain> artistas = new List<ArtistaDomain>();
            artistas = ArtistaRepository.Listar();
                
            if(artistas == null)
            {
                return NotFound();
            }
            return Ok(artistas);
        }

        [HttpPost]
        public IActionResult Cadastrar(ArtistaDomain artista)
        {
            try
            {
                ArtistaRepository.Cadastrar(artista);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu um erro." + ex.Message });
            }
        }
    }
}