using System;
using System.Collections.Generic;
using System.Linq;
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
    public class CargosController : ControllerBase
    {
        CargoRepository cargoRepository = new CargoRepository();

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(cargoRepository.Listar());
        }

        [Authorize]
        [HttpPost]
        public IActionResult Cadastrar(Cargos cargo)
        {
            try
            {
                cargoRepository.Cadastrar(cargo);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [Authorize]
        [HttpPut]
        public IActionResult Alterar(Cargos cargo)
        {
            try
            {
                cargoRepository.Alterar(cargo);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                cargoRepository.Deletar(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}