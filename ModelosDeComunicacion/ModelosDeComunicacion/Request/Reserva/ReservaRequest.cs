using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelosDeComunicacion.Request.Reserva
{
    public class ReservaRequest
    {
        public string Codigo { get; set; }
        public int Vuelo { get; set; }
        public int Usuario { get; set; }
    }
}
