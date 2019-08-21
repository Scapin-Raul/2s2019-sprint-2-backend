using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domain;
using Senai.Peoples.WebApi.Repository;
using Senai.Peoples.WebApi.ViewModel;

namespace Senai.Peoples.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        FuncionarioRepository funcionarioRepository = new FuncionarioRepository();
        List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();

        [HttpGet]
        public IActionResult Listar()
        {
            funcionarios = funcionarioRepository.Listar();
            return Ok(funcionarios);
        }

        [HttpPost]
        public IActionResult Inserir(FuncionarioDomain funcionarioDomain)
        {
            funcionarioRepository.Inserir(funcionarioDomain);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            FuncionarioDomain funcionario = funcionarioRepository.BuscarPorId(id);
            if(funcionario == null)
            {
                return NotFound();
            }
            return Ok(funcionario);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, FuncionarioDomain funcionarioDomain)
        {
            funcionarioDomain.IdFuncionario = id;
            funcionarioRepository.Atualizar(funcionarioDomain);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            funcionarioRepository.Deletar(id);
            return Ok();
        }

        [HttpGet("nomescompletos")]
        public IActionResult NomesCompletos()
        {
            List<NomesCompletosViewModel> nomesCompletos = funcionarioRepository.NomesCompletos();
            return Ok(nomesCompletos);
        }

        [HttpGet("buscar/{nome}")]
        public IActionResult BuscarNome(string nome)
        {
            funcionarios = funcionarioRepository.BuscarNome(nome);
            return Ok(funcionarios);
        }

        [HttpGet("ordenacao/{ordem}")]
        public IActionResult Ordenacao(string ordem)
        {
            ordem = ordem.ToLower();
            if(ordem.Equals("asc") || ordem.Equals("desc"))
            {
                funcionarios = funcionarioRepository.Listar(ordem);
                return Ok(funcionarios);
            }
            return BadRequest();
        }



    }
}