using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelosDeComunicacion.Modelos
{
    public class DatosVuelo
    {
        public int Id { get; set; }
        public string Estado { get; set; }
        public int AsientosDisponibles { get; set; }
        public System.DateTime HorarioSalida { get; set; }
        public System.DateTime HorarioLlegada { get; set; }
        public DatosCiudad Origen { get; set; }
        public DatosCiudad Destino { get; set; }
        public decimal Tarifa { get; set; }
        public DatosAerolinea Aerolinea { get; set; }
    }
}
