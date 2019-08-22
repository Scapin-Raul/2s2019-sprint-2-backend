using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Filmes.WebApi.Domains;
using Senai.Filmes.WebApi.Repository;

namespace Senai.Filmes.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        GeneroRepository generoRepository = new GeneroRepository();
        List<GeneroDomain> generos = new List<GeneroDomain>();

        [HttpGet]
        public List<GeneroDomain> Listar()
        {
            generos = generoRepository.Listar();

            return generos;
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var Genero = generoRepository.BuscarPorId(id);


            if (Genero == null)
            {
                return NotFound();
            }
            return Ok(Genero);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(GeneroDomain genero, int id)
        {
            //if(genero.Nome == null)
            //{
            //    return NotFound();
            //}
            genero.IdGenero = id;
            generoRepository.Alterar(genero);

            return Ok();
        }

        [HttpPost]
        public IActionResult Cadastrar(GeneroDomain genero)
        {
            generoRepository.Cadastrar(genero);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            generoRepository.Deletar(id);
            return Ok();
        }

        [HttpGet("{id}/filmes")]
        public IActionResult FilmesDeGenero(int id)
        {
            List<FilmeDomain> filmes = generoRepository.FilmesDeGenero(id);

            return Ok(filmes);
        }

        [HttpGet("{nome}/buscar")]
        public IActionResult BuscarNome(string nome)
        {
            generos = generoRepository.BuscarNome(nome);

            return Ok(generos);
        }


    }
}