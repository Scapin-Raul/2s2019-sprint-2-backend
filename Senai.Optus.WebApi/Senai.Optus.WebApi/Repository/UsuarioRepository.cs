using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai.Optus.WebApi.Domains;
using Senai.Optus.WebApi.ViewModel;

namespace Senai.Optus.WebApi.Repository
{
    public class UsuarioRepository
    {
        public Usuarios BuscarPorEmailESenha(LoginViewModel login)
        {
            using(OptusContext ctx = new OptusContext())
            {
                Usuarios usuarioRecuperado = ctx.Usuarios.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                return usuarioRecuperado;
            }
        }
    }
}
