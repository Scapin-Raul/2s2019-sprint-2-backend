using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.ViewModel;

namespace Senai.Ekips.WebApi.Repositories
{
    public class FuncionarioRepository
    {

        public List<Funcionarios> Listar()
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                // linq
                return ctx.Funcionarios.Include(x => x.IdDepartamentoNavigation).Include(x => x.IdCargoNavigation).ToList();
            }


        }

        public void Cadastrar(Funcionarios funcionario)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                ctx.Funcionarios.Add(funcionario);
                ctx.SaveChanges();
            }
        }

        public void Alterar(Funcionarios funcionario)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                var a = ctx.Funcionarios.Find(funcionario.IdFuncionario);
                a.Nome = funcionario.Nome;
                a.IdCargo = funcionario.IdCargo;
                a.IdDepartamento = funcionario.IdDepartamento;
                a.Salario = funcionario.Salario;
                ctx.Funcionarios.Update(a);
                ctx.SaveChanges();
            }
            
        }

        public FuncionariosViewModel BuscarPorId(int id)
        {
            using(EkipsContext ctx = new EkipsContext())
            {
                var a = ctx.Funcionarios.Include(x => x.IdDepartamentoNavigation).Include(x => x.IdCargoNavigation).FirstOrDefault(x=>x.IdUsuario == id);
                FuncionariosViewModel b = new FuncionariosViewModel();
                b.Nome = a.Nome;
                b.Email = a.IdUsuarioNavigation.Email;



                return b;
            }
        }

        public void Deletar(int id)
        {
            using(EkipsContext ctx = new EkipsContext())
            {
                ctx.Funcionarios.Remove(ctx.Funcionarios.Find(id));
                ctx.SaveChanges();
            }
        }
    }
}
