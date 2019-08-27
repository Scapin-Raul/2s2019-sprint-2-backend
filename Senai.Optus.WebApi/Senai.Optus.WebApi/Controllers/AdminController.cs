using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Optus.WebApi.Repository;

namespace Senai.Optus.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        EstiloRepository estiloRepository = new EstiloRepository();
        ArtistaRepository artistaRepository = new ArtistaRepository();

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            return Ok("Há "+ artistaRepository.Listar().Count() + " artistas e "+ estiloRepository.Listar().Count() + " estilos.");
        }


    }
}