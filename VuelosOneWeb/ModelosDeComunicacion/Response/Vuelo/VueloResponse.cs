using ModelosDeComunicacion.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelosDeComunicacion.Response.Vuelo
{
    public class VueloResponse
    {
        public List<DatosVuelo> vuelos { set; get; }

        public List<DatosCiudad> ciudades { set; get; }

        public StatusResponse ResponseStatus { set; get; }

    }
}
