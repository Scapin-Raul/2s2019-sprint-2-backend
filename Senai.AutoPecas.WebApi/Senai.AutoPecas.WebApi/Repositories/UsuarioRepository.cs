using Senai.AutoPecas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Repositories
{
    public class UsuarioRepository
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




    }
}
