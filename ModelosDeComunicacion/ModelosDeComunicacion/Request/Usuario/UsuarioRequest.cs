using ModelosDeComunicacion.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelosDeComunicacion.Request.Usuario
{
    public class UsuarioRequest
    {
        public int Codigo { get; set; }
        public System.DateTime FechaNacimiento { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }

        public StatusResponse ResponseStatus { set; get; }
    }
}
