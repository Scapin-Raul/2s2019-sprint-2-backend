using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai.AutoPecas.WebApi.Controllers;
using Senai.AutoPecas.WebApi.Domains;

namespace Senai.AutoPecas.WebApi.Repositories
{
    public class PecasRepository
    {
        public void Cadastrar(Pecas pecas)
        {
            using(AutoPecasContext ctx = new AutoPecasContext())
            {
                ctx.Pecas.Add(pecas);
                ctx.SaveChanges();
            }
        }

        public List<Pecas> ListarPorId(int idFornecedor)
        {
            using(AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Pecas.Where(x => x.IdFornecedor == idFornecedor).ToList();
            }



        }

        public Pecas BuscarPorId(int idPeca, int idFornecedor)
        {
            using(AutoPecasContext ctx= new AutoPecasContext())
            {
                var pecaRecuperada = ctx.Pecas.Find(idPeca);
                if (pecaRecuperada.IdFornecedor == idFornecedor)
                {
                    return pecaRecuperada;
                }
                return null;

            }

        }

        public void Alterar(Pecas peca,int idFornecedor)
        {
            using(AutoPecasContext ctx = new AutoPecasContext())
            {
                var pecaRecuperada = ctx.Pecas.Find(peca.IdPeca);
                if (pecaRecuperada.IdFornecedor == idFornecedor)
                {
                    pecaRecuperada.Peso = peca.Peso;
                    pecaRecuperada.Codigo = peca.Codigo;
                    pecaRecuperada.Descricao = peca.Descricao;
                    pecaRecuperada.PrecoCusto = peca.PrecoCusto;
                    pecaRecuperada.PrecoVenda = peca.PrecoVenda;
                    ctx.Pecas.Update(pecaRecuperada);
                    ctx.SaveChanges();
                }
            }
        }



    }
}
