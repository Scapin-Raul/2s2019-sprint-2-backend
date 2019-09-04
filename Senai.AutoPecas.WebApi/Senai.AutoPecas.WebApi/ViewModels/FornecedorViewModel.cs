using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.ViewModels
{
    public class FornecedorViewModel
    {
        public int IdFornecedor { get; set; }
        public int Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Endereco { get; set; }
        public int IdUsuario { get; set; }
        public string Email { get; set; }
    }
}
