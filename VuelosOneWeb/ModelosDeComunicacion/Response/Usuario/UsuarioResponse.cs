using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelosDeComunicacion.Response.Usuario
{
    public class UsuarioResponse
    {
        public int Codigo { get; set; }
        public System.DateTime FechaNacimiento { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }

        public StatusResponse ResponseStatus { set; get; }
    }
}
