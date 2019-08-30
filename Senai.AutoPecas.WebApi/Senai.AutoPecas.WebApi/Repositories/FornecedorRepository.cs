using Senai.AutoPecas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Repositories
{
    public class FornecedorRepository
    {

        public Fornecedores BuscarPorUser(int IdUser)
        {
            using(AutoPecasContext ctx = new AutoPecasContext())
            {
                var fornecedorRecuperado = ctx.Fornecedores.FirstOrDefault(x => x.IdUsuario == IdUser);
                if (fornecedorRecuperado == null) return null;
                return fornecedorRecuperado;
            }
        }
        



    }
}
