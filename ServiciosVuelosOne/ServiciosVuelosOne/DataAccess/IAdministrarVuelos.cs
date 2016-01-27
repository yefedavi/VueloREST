using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiciosVuelosOne.Models;

namespace ServiciosVuelosOne.DataAccess
{
    public interface IAdministrarVuelos
    {
        /// <summary>
        /// Mètodo encargado de consultar los vuelos disponibles en dos ciudades
        /// </summary>
        /// <param name="ciudadOrigen"></param>
        /// <param name="ciudadDestino"></param>
        /// <returns></returns>
        List<Vuelo> ConsultarVuelosDisponiblesHorarios(Ciudad ciudadOrigen, Ciudad ciudadDestino);

        /// <summary>
        /// Mètodo encargado de consultar los vuelos disponibles dando prioridad al costo,
        /// entre dos ciudades
        /// </summary>
        /// <param name="tarifa"></param>
        /// <returns></returns>
        List<Vuelo> ConsultarVuelosDisponiblesTarifa(Ciudad ciudadOrigen, Ciudad ciudadDestino);

        /// <summary>
        /// Mètodo encargado de obtener las ciudades donde vuelan las aerolineas
        /// </summary>
        /// <returns></returns>
        List<Ciudad> ObtenerCiudadesVuelos();

        /// <summary>
        /// Mètodo encargado de consultar una ciudad en la base de datos
        /// mediante el codigo
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns>Ciudad a la que corresponde el codigo</returns>
        Ciudad obtenerCiudadCodigo(string codigo);

        /// <summary>
        /// Mètodo encargado de consultar un vuelo mediante el identificador
        /// </summary>
        /// <param name="idVuelo">Identificador del vuelo</param>
        /// <returns>Vuelo al que corresponde el identificador</returns>
        Vuelo consultarVueloId(int idVuelo);
    }
}
