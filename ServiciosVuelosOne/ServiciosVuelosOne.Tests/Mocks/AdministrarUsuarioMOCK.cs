using ServiciosVuelosOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiciosVuelosOne.DataAccess;

namespace VuelosOne.Tests.Mocks
{
    public class AdministrarUsuarioMOCK : IAdministrarUsuarios
    {
        public Boolean CrearUsuario(Usuario usuario)
        {
            if (usuario.Username.Equals("1"))
            {
                return true;
            }
            return false;
        }

        public Usuario ConsultarUsuario(String username)
        {
            throw new NotImplementedException();
        }

        public Boolean LoguearUsuario(String username, String contraseña)
        {
            if (username.Equals("UsuarioLogin") && contraseña.Equals("contra123"))
            {
                return true;
            }
            else { return false; }
        }

        public List<Usuario> GetAllUsuarios()
        {
            throw new NotImplementedException();
        }


        public bool EsMayorDeEdad(string username)
        {
            throw new NotImplementedException();
        }
    }
}
