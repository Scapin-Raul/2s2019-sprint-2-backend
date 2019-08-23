using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.BookStore.Domains;
using Senai.BookStore.Repository;

namespace Senai.BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        GeneroRepository generoRepository = new GeneroRepository();
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(generoRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(GeneroDomain generoDomain)
        {
            generoRepository.Cadastrar(generoDomain);
            return Ok();
        }

        [HttpGet("{nome}/livros")]
        public IActionResult BuscarLivroPorGenero(string nome)
        {
            var livros = generoRepository.BuscarLivroPorGenero(nome);

            return Ok(livros);

        }


    }
}