using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Usuarios BuscarPorEmailESenha(Usuarios user)
        {
            using(AutoPecasContext ctx = new AutoPecasContext())
            {
                var userRecuperado = ctx.Usuarios.FirstOrDefault(x => x.Email == user.Email && x.Senha == user.Senha);
                if (userRecuperado == null) return null;
                return userRecuperado;
            }
        }

        public List<Usuarios> Listar()
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                var listaDeUser = ctx.Usuarios.ToList();
                List<Usuarios> listaFinal = new List<Usuarios>();
                foreach (var item in listaDeUser)
                {
                    item.Senha = null;
                    listaFinal.Add(item);
                }
                return listaFinal;

            }
        }
    }
}
