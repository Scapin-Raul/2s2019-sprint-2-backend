using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class CargoRepository
    {
        public List<Cargos> Listar()
        {
            using(EkipsContext ctx = new EkipsContext())
            {
                return (ctx.Cargos.ToList());
            }
        }

        public void Cadastrar(Cargos cargo)
        {
            using(EkipsContext ctx = new EkipsContext())
            {
                ctx.Cargos.Add(cargo);
                ctx.SaveChanges();

            }

        }

        public void Alterar(Cargos cargo)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                var a = ctx.Cargos.Find(cargo.IdCargo);
                a.Nome = cargo.Nome;
                ctx.Cargos.Update(a);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                ctx.Cargos.Remove(ctx.Cargos.Find(id));
                ctx.SaveChanges();
            }
        }

        public Cargos BuscarPorId(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                var cargo = ctx.Cargos.FirstOrDefault(x => x.IdCargo == id);
                return cargo;
            }
        }


    }
}
