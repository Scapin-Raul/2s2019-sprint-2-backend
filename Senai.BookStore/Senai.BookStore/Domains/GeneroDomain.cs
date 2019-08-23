using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.BookStore.Domains
{
    public class GeneroDomain
    {
        public int IdGenero { get; set; }
        [Required(ErrorMessage ="Erro: é necessario conter descrição do genero.")]
        public string Descricao { get; set; }
    }
}
