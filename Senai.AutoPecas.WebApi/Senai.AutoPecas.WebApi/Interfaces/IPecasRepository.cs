using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Interfaces
{
    public interface IPecasRepository
    {
        void Cadastrar(Pecas pecas);
        List<Pecas> ListarPorId(int idFornecedor);
        Pecas BuscarPorId(int idPeca, int idFornecedor);
        void Alterar(Pecas peca, int idFornecedor);

        int Calcular(int quantidade, int idPeca);
        List<PrecoViewModel> Precos();


    }
}
