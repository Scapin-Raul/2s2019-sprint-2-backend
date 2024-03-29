﻿using Senai.Optus.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Optus.WebApi.Repository
{
    public class EstiloRepository
    {

        public List<Estilos> Listar()
        {
            using(OptusContext ctx = new OptusContext())
            {
                return ctx.Estilos.ToList();
            }
        }

        public void Cadastrar(Estilos estilo)
        {
            using(OptusContext ctx = new OptusContext())
            {
                ctx.Estilos.Add(estilo);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using(OptusContext ctx = new OptusContext())
            {
                var EstilosDeletar = ctx.Estilos.Find(id);
                ctx.Estilos.Remove(EstilosDeletar);
                ctx.SaveChanges();
            }
        }

        public Estilos BuscarPorId(int id)
        {
            using(OptusContext ctx = new OptusContext())
            {
                return ctx.Estilos.Find(id);

            }
        }

        public void Alterar(Estilos estilo)
        {
            using(OptusContext ctx = new OptusContext())
            {
                var EstiloAlterar = ctx.Estilos.FirstOrDefault(x => x.IdEstilo == estilo.IdEstilo);
                EstiloAlterar.Nome = estilo.Nome;
                ctx.Estilos.Update(EstiloAlterar);
                ctx.SaveChanges();
            }
        }

        public List<Artistas> BuscarArtista(int id)
        {
            using (OptusContext ctx = new OptusContext())
            {
                var artistas = ctx.Artistas.Where(x => x.IdEstilo == id).ToList();
                if (artistas.Count == 0) return null;
                return artistas;
            }
        }

        public List<Artistas> BuscarPeloNome(string nome)
        {
            using (OptusContext ctx = new OptusContext())
            {
                var artistas = ctx.Artistas.Where(x => x.IdEstiloNavigation.Nome.ToLower() == nome.ToLower()).ToList();
                if (artistas.Count == 0) return null;
                return artistas;
            }
        }

    }
}
