using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.BookStore.Domains
{
    public class LivroDomain
    {
        public int IdLivro { get; set; }
        public string Titulo { get; set; }
        public AutorDomain Autor { get; set; }
        public GeneroDomain Genero { get; set; }
        public int AutorId { get; set; }
        public int GeneroId { get; set; }
    }
}
