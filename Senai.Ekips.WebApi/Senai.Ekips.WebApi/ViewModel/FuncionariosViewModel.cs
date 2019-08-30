using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.ViewModel
{
    public class FuncionariosViewModel
    {
        public int IdFuncionario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public long? Cpf { get; set; }
        public DateTime? DataNascimento { get; set; }
        public int? Salario { get; set; }
        public string NomeDepartamento { get; set; }
        public string NomeCargo { get; set; }
    }
}
