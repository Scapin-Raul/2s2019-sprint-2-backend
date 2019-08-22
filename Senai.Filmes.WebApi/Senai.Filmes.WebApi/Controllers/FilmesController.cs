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
    public class FilmesController : ControllerBase
    {
        FilmeRepository filmeRepository = new FilmeRepository();

        [HttpPost]
        public IActionResult Cadastrar(FilmeDomain filmeDomain)
        {
            filmeRepository.Cadastrar(filmeDomain);

            return Ok();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(filmeRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var filme = filmeRepository.BuscarPorId(id);


            return Ok(filme);
        }

        [HttpGet("{nome}/buscar")]
        public IActionResult BuscarNome(string nome)
        {
            List<FilmeDomain> filmes = filmeRepository.BuscarNome(nome);

            return Ok(filmes);
        }


    }
}