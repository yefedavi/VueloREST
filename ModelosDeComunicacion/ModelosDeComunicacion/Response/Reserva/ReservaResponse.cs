using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelosDeComunicacion.Response.Reserva
{
    public class ReservaResponse
    {
        public string Codigo { get; set; }
        public int Vuelo { get; set; }
        public int Usuario { get; set; }

        public StatusResponse ResponseStatus { set; get; }
    }
}
