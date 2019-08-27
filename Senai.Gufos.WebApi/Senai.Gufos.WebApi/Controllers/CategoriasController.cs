using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Gufos.WebApi.Domains;
using Senai.Gufos.WebApi.Repository;

namespace Senai.Gufos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        CategoriaRepository categoriaRepository = new CategoriaRepository();


        /// <summary>
        /// 
        /// </summary>
        /// <returns>Lista todas categorias</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(categoriaRepository.Listar());
        }
        
        [HttpPost]
        public IActionResult Cadastrar(Categorias Categoria)
        {
            try
            {
                categoriaRepository.Cadastrar(Categoria);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(new { mensagem = "a" + ex.Message });
            }
        }


        [Authorize (Roles = "Administrador")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Categorias Categoria = categoriaRepository.BuscarPorId(id);
            if(Categoria == null)
            {
                return NotFound();
            }
            return Ok(Categoria);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                categoriaRepository.Deletar(id);
                return Ok();
            }
            catch(Exception ex) {
                return BadRequest("Registro não encontrado. \n"+ ex);
            }
        }

        [HttpPut]
        public IActionResult Atualizar(Categorias categoria)
        {
            try
            {
                Categorias CategoriaBuscada = categoriaRepository.BuscarPorId(categoria.IdCategoria);
                if(CategoriaBuscada == null)
                {
                    return NotFound();
                }

                categoriaRepository.Atualizar(categoria);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex); 
            }
        }

    }
}