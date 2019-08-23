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
    public class AutoresController : ControllerBase
    {
        AutorRepository autorRepository = new AutorRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(autorRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(AutorDomain autorDomain)
        {
            autorRepository.Cadastrar(autorDomain);

            return Ok();
        }

        [HttpGet("{id}/livros")]
        public IActionResult BuscarLivrosPorId(int id)
        {
            List<LivroDomain> livros = autorRepository.BuscarLivrosPorId(id);
            if(livros.Count() == 0)
            {
                return NotFound("Não há livros com o id deste autor");
            }

            return Ok(livros);
        }

        [HttpGet("ativos")]
        public IActionResult Ativos() {
            List<AutorDomain> autores = autorRepository.Ativos();

            return Ok(autores);
        }

        [HttpGet("{id}/ativos/livros")]
        public IActionResult LivrosDeAtivos(int id)
        {
            List<LivroDomain> livros = autorRepository.LivrosDeAtivos(id);

            if(livros.Count == 0)
            {
                return NotFound("Livro não existente ou Autor não ativo");
            }

            return Ok(livros);
        }
    }
}