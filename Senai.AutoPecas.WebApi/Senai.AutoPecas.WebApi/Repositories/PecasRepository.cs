using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai.AutoPecas.WebApi.Controllers;
using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interfaces;
using Senai.AutoPecas.WebApi.ViewModels;

namespace Senai.AutoPecas.WebApi.Repositories
{
    public class PecasRepository: IPecasRepository
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

        public int Calcular(int quantidade, int idPeca)
        {
            using(AutoPecasContext ctx = new AutoPecasContext())
            {
                Pecas Peca = ctx.Pecas.Find(idPeca);
                if (Peca == null) return -1;
                return (Convert.ToInt32(Peca.PrecoVenda) * quantidade);
            }
        }

        public List<PrecoViewModel> Precos()
        {
            using(AutoPecasContext ctx = new AutoPecasContext())
            {
                var listaDePecas = ctx.Pecas.ToList();
                List<PrecoViewModel> precoViewModel = new List<PrecoViewModel>();

                foreach (var item in listaDePecas)
                {
                    PrecoViewModel preco = new PrecoViewModel();
                    preco.PrecoVenda = Convert.ToInt32(item.PrecoVenda);
                    preco.PrecoCusto = Convert.ToInt32(item.PrecoCusto);
                    preco.Diferenca = Convert.ToInt32(item.PrecoVenda - item.PrecoCusto);
                    preco.Porcentagem = 100 -Convert.ToDouble(item.PrecoCusto * 100/ item.PrecoVenda);
                    precoViewModel.Add(preco);
                }
                return precoViewModel;
            }


        }

    }
}
