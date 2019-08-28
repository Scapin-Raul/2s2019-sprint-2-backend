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
    public class DepartamentosController : ControllerBase
    {
        DepartamentoRepository departamentoRepository = new DepartamentoRepository();

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            List<Departamentos> d = departamentoRepository.Listar();

            return Ok(d);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Cadastrar(Departamentos departamento)
        {
            try
            {
                departamentoRepository.Cadastrar(departamento);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpPut]
        public IActionResult Alterar(Departamentos departamento)
        {
            try
            {
                departamentoRepository.Alterar(departamento);
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
                departamentoRepository.Deletar(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


    }
}