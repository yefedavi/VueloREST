using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiciosVuelosOne.Models;

namespace ServiciosVuelosOne.DataAccess
{
    public class AdministrarVuelos : IAdministrarVuelos
    {
        public ReservaVuelosEntities vuelosContext { get; set; }

        public AdministrarVuelos()
        {
            vuelosContext = new ReservaVuelosEntities();
        }
        /// <summary>
        /// Mètodo encargado de consultar los vuelos disponibles en dos ciudades
        /// </summary>
        /// <param name="ciudadOrigen"></param>
        /// <param name="ciudadDestino"></param>
        /// <returns></returns>
        public List<Vuelo> ConsultarVuelosDisponiblesHorarios(Ciudad ciudadOrigen, Ciudad ciudadDestino)
        {
            var vuelos = from v in vuelosContext.Vuelo
                         where v.Origen == ciudadOrigen.Codigo &&
                         v.Destino == ciudadDestino.Codigo
                         orderby v.HorarioSalida
                         select v;
            return vuelos.ToList();
        }
        /// <summary>
        /// Mètodo encargado de consultar los vuelos disponibles dando prioridad al costo,
        /// entre dos ciudades
        /// </summary>
        /// <param name="tarifa"></param>
        /// <returns></returns>
        public List<Vuelo> ConsultarVuelosDisponiblesTarifa(Ciudad ciudadOrigen, Ciudad ciudadDestino)
        {
            var vuelos = from v in vuelosContext.Vuelo
                         where v.Origen == ciudadOrigen.Codigo &&
                         v.Destino == ciudadDestino.Codigo
                         orderby v.Tarifa ascending
                         select v;
            return vuelos.ToList();
        }

         /// <summary>
        /// Mètodo encargado de obtener las ciudades donde vuelan las aerolineas
        /// </summary>
        /// <returns></returns>
        public List<Ciudad> ObtenerCiudadesVuelos()
        {
            var ciudades = from c in vuelosContext.Ciudad
                           select c;
            return ciudades.ToList();
        }

        /// <summary>
        /// Mètodo encargado de consultar una ciudad en la base de datos
        /// mediante el codigo
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public Ciudad obtenerCiudadCodigo(string codigo)
        {
            int condigoCiudad = Int32.Parse(codigo);
            var ciudad=from c in vuelosContext.Ciudad
                       where c.Codigo == condigoCiudad
                       select c;
            return ciudad.First();
        }

        /// <summary>
        /// Mètodo encargado de consultar un vuelo mediante el identificador
        /// </summary>
        /// <param name="idVuelo">Identificador del vuelo</param>
        /// <returns>Vuelo al que corresponde el identificador</returns>
        public Vuelo consultarVueloId(int idVuelo)
        {
            Vuelo vueloConsultado = vuelosContext.Vuelo.Single(v => v.Id == idVuelo);
            return vueloConsultado;
        }

    }
}