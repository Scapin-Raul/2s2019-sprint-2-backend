using Microsoft.EntityFrameworkCore;
using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interfaces;
using Senai.AutoPecas.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Repositories
{
    public class FornecedorRepository: IFornecedorRepository
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

        public List<FornecedorViewModel> Listar()
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                var fornecedores = ctx.Fornecedores.Include(x => x.IdUsuarioNavigation).ToList();
                List<FornecedorViewModel> fornecedoresViewModel = new List<FornecedorViewModel>(); 

                foreach (var f in fornecedores)
                {
                    var fornecedor = new FornecedorViewModel
                    {
                        IdFornecedor = f.IdFornecedor,
                        Cnpj = Convert.ToInt32(f.Cnpj),
                        RazaoSocial = f.RazaoSocial,
                        NomeFantasia = f.NomeFantasia,
                        Endereco = f.Endereco,
                        IdUsuario = Convert.ToInt32(f.IdUsuario),
                        Email = f.IdUsuarioNavigation.Email
                    };
                    fornecedoresViewModel.Add(fornecedor);

                }
                 
                return fornecedoresViewModel;
            }

        }
    }
}