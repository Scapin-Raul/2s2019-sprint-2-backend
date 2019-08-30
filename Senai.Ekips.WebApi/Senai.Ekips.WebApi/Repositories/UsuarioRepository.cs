using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class UsuarioRepository
    {


        public Usuarios BuscarPorEmailESenha(Usuarios usuario)
        {
            using(EkipsContext ctx = new EkipsContext())
            {
                return ctx.Usuarios.FirstOrDefault(x => x.Email == usuario.Email && x.Senha == usuario.Senha);
            }
        }

        public Usuarios BuscarPorId(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                var usuario = ctx.Usuarios.FirstOrDefault(x => x.IdUsuario == id);
                return usuario;
            }
        }
    }
}
