using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Domains
{
    public class GeneroDomain
    {
        public int IdGenero { get; set; }
        [Required(ErrorMessage ="Precisa-se de nome")]
        public string Nome { get; set; }
    }
}
