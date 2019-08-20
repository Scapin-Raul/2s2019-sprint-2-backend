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
    [ApiController]
    [Produces("application/json")]
    public class EstilosController : ControllerBase
    {
        List<EstiloDomain> estilos = new List<EstiloDomain>()
            {
                new EstiloDomain { IdEstilo = 1, Nome = "Rock"},
                new EstiloDomain { IdEstilo = 2, Nome = "Pop"}
            };

        EstiloRepository EstiloRepository = new EstiloRepository();

        [HttpGet]
        public IEnumerable<EstiloDomain> Listar()
        {

            return EstiloRepository.Listar();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var Estilo = EstiloRepository.BuscarPorId(id);
            //EstiloDomain Estilo = EstiloRepository.Listar().Find(x => x.IdEstilo == id);
            if(Estilo == null)
            {
                return NotFound();
            }
            return Ok(Estilo);
        }

        [HttpPost]
        public IEnumerable<EstiloDomain> Cadastrar(EstiloDomain estiloDomain)
        {
            EstiloRepository.Cadastrar(estiloDomain);

            return EstiloRepository.Listar();
        }

        [HttpPut]
        public IActionResult Alterar(EstiloDomain estiloDomain)
        {
            //if (estiloDomain.IdEstilo = null)
            //{
            //    return NotFound();
            //}
            EstiloRepository.Alterar(estiloDomain);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            EstiloRepository.Deletar(id);

            return Ok();
        }

    }
}