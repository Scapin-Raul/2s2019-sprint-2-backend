using Senai.Gufos.WebApi.Domains;
using Senai.Gufos.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufos.WebApi.Repository
{
    public class UsuarioRepository
    {

        public Usuarios BuscarPorEmailESenha(LoginViewModel login)
        {
            using(GufosContext ctx = new GufosContext())
            {
                Usuarios usuarioBuscado = ctx.Usuarios.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                if(usuarioBuscado == null) return null;
                return usuarioBuscado;
                
            }
        }

    }
}
