using Senai.Gufos.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufos.WebApi.Repository
{
    public class CategoriaRepository
    {
        /// <summary>
        /// Listar todas categorias
        /// </summary>
        /// <returns>Retorna todas categorias</returns>
        public List<Categorias> Listar()
        {
            using(GufosContext ctx = new GufosContext())
            {

                return ctx.Categorias.ToList();
            }
        }

        public void Cadastrar(Categorias Categoria)
        {
            using (GufosContext ctx = new GufosContext())
            {
                ctx.Categorias.Add(Categoria);
                ctx.SaveChanges();
            }
        }

        public Categorias BuscarPorId(int id)
        {
            using(GufosContext ctx = new GufosContext())
            {
                return ctx.Categorias.FirstOrDefault(x => x.IdCategoria == id);
            }
        }

        public void Deletar(int id)
        {
            using(GufosContext ctx = new GufosContext())
            {
                Categorias CategoriaBuscada = ctx.Categorias.Find(id);
                ctx.Categorias.Remove(CategoriaBuscada);
                ctx.SaveChanges();

            }
        }

        public void Atualizar(Categorias Categoria)
        {
            using(GufosContext ctx = new GufosContext())
            {
                Categorias CategoriaBuscada = ctx.Categorias.FirstOrDefault(x => x.IdCategoria == Categoria.IdCategoria);
                CategoriaBuscada.Nome = Categoria.Nome;
                ctx.Categorias.Update(CategoriaBuscada);
                ctx.SaveChanges();

            }
        }
    }
}
