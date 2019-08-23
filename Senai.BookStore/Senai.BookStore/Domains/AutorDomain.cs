using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.BookStore.Domains
{
    public class AutorDomain
    {
        public int IdAutor { get; set; }
        [Required(ErrorMessage = "Erro: é necessario conter nome do genero.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Erro: é necessario conter email do genero.")]
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
