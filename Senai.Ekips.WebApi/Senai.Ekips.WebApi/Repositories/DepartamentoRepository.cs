using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai.Ekips.WebApi.Domains;

namespace Senai.Ekips.WebApi.Repositories
{
    public class DepartamentoRepository
    {
        public List<Departamentos> Listar()
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                 return (ctx.Departamentos.ToList());
            }
        }

        public void Cadastrar(Departamentos departamento)
        {
            using(EkipsContext ctx = new EkipsContext())
            {
                ctx.Departamentos.Add(departamento);
                ctx.SaveChanges();
            }
        }

        public void Alterar(Departamentos departamento)
        {
            using(EkipsContext ctx = new EkipsContext())
            {
                var a =ctx.Departamentos.Find(departamento.IdDepartamento);
                a.Nome = departamento.Nome;
                ctx.Departamentos.Update(a);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using(EkipsContext ctx = new EkipsContext())
            {
                ctx.Departamentos.Remove(ctx.Departamentos.Find(id));
                ctx.SaveChanges();
            }
        }

        public Departamentos BuscarPorId(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                var departamento = ctx.Departamentos.FirstOrDefault(x => x.IdDepartamento == id);
                return departamento;
            }
        }

    }
}
