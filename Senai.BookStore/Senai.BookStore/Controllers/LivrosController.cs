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
    public class LivrosController : ControllerBase
    {
        LivroRepository livroRepository = new LivroRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(livroRepository.Listar());
        }
        
        [HttpPost]
        public IActionResult Cadastrar(LivroDomain livroDomain)
        {
            livroRepository.Cadastrar(livroDomain);

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            LivroDomain livro = livroRepository.BuscarPorId(id);

            return Ok(livro);
        }

        [HttpPut("{id}")]
        public IActionResult Alterar(int id, LivroDomain livroDomain)
        {
            livroDomain.IdLivro = id;
            livroRepository.Alterar(livroDomain);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            livroRepository.Deletar(id);
            return Ok();
        }
    }
}