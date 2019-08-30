using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.ViewModel;
using Senai.Ekips.WebApi.Repositories;
namespace Senai.Ekips.WebApi.Repositories
{
    public class FuncionarioRepository
    {
        CargoRepository cargoRepository = new CargoRepository();
        UsuarioRepository usuarioRepository = new UsuarioRepository();
        DepartamentoRepository departamentoRepository = new DepartamentoRepository();

        public List<FuncionariosViewModel> Listar()
        {
            using (EkipsContext ctx = new EkipsContext())
            {       
                var a = ctx.Funcionarios.Include(x => x.IdDepartamentoNavigation).Include(x => x.IdCargoNavigation).ToList();
                var b = new List<FuncionariosViewModel>();

                foreach (var item in a)
                {
                    var c = new FuncionariosViewModel();
                    c.IdFuncionario = item.IdFuncionario;
                    c.Nome = item.Nome;

                    try { c.Email = usuarioRepository.BuscarPorId(Convert.ToInt32(item.IdUsuario)).Email; }
                    catch (Exception) { c.Email = null; }

                    c.Cpf = item.Cpf;
                    c.DataNascimento = item.DataNascimento;
                    c.Salario = item.Salario;
                    try
                        { c.NomeDepartamento = departamentoRepository.BuscarPorId(Convert.ToInt32(item.IdDepartamento)).Nome; }
                    catch (Exception)
                        { c.NomeDepartamento = null; }
                    try
                        { c.NomeCargo = cargoRepository.BuscarPorId(Convert.ToInt32(item.IdCargo)).Nome; }
                    catch (Exception)
                        { c.NomeCargo = null;  }
                    b.Add(c);
                }

                return b;
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
                FuncionariosViewModel c = new FuncionariosViewModel();
                c.IdFuncionario = a.IdFuncionario;
                c.Nome = a.Nome;

                try { c.Email = usuarioRepository.BuscarPorId(Convert.ToInt32(a.IdUsuario)).Email; }
                catch (Exception) { c.Email = null; }

                c.Cpf = a.Cpf;
                c.DataNascimento = a.DataNascimento;
                c.Salario = a.Salario;
                try
                { c.NomeDepartamento = departamentoRepository.BuscarPorId(Convert.ToInt32(a.IdDepartamento)).Nome; }
                catch (Exception)
                { c.NomeDepartamento = null; }
                try
                { c.NomeCargo = cargoRepository.BuscarPorId(Convert.ToInt32(a.IdCargo)).Nome; }
                catch (Exception)
                { c.NomeCargo = null; }

                return c;
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
