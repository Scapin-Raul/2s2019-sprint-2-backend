using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.ViewModels
{
    public class PrecoViewModel
    {
        public double Porcentagem { get; set; }
        public int Diferenca { get; set; }
        public int PrecoCusto { get; set; }
        public int PrecoVenda { get; set; }
    }
}
