using ServiciosVuelosOne.DataAccess;
using ServiciosVuelosOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ServiciosVuelosOne.BusinessLogic
{
    public class BOAdministrarVuelos
    {
        //
        // GET: /Vuelo/
        public IAdministrarVuelos AdminVuelos;

        /// <summary>
        /// Controlador de la clase vuelo controller
        /// </summary>
        public BOAdministrarVuelos()
        {
            AdminVuelos = new AdministrarVuelos();
        }
        /// <summary>
        /// Controlador de la clase vuelo controller,con un parametro adicional
        /// </summary>
        /// <param name="iAdministrarVuelos"></param>
        public BOAdministrarVuelos(IAdministrarVuelos iAdministrarVuelos)
        {
            AdminVuelos = iAdministrarVuelos;
        }

        /// <summary>
        /// Mètodo encargado de listar las ciudades donde vuelan las aerolineas
        /// </summary>
        /// <returns></returns>
        public List<Ciudad> ListarCiudades()
        {
            List<Ciudad> ciudades = AdminVuelos.ObtenerCiudadesVuelos();
            return ciudades;
        }

        /// <summary>
        /// Mètodo encargado de listar todos los vuelos entre dos ciudades de las 
        /// diferentes aerolineas
        /// </summary>
        /// <param name="ciudadOrigen"></param>
        /// <param name="ciudadDestino"></param>
        /// <returns></returns>
        [HttpPost]
        public List<Vuelo> ListarVuelosTipoHorario(string ciudadOrigen, String ciudadDestino)
        {
            Ciudad origen = AdminVuelos.obtenerCiudadCodigo(ciudadOrigen);
            Ciudad destino = AdminVuelos.obtenerCiudadCodigo(ciudadDestino);
            List<Vuelo> vuelosDisponibles = AdminVuelos.ConsultarVuelosDisponiblesHorarios(origen, destino);
            return vuelosDisponibles;
        }

        /// <summary>
        /// Mètodo encargado de listar todos los vuelos entre dos ciudades de las 
        /// diferentes aerolineas ,organizado por tarifa
        /// </summary>
        /// <param name="ciudadOrigen"></param>
        /// <param name="ciudadDestino"></param>
        /// <returns></returns>
        [HttpPost]
        public List<Vuelo> ListarVuelosTipoTarifa(string ciudadOrigen, String ciudadDestino)
        {
            Ciudad origen = AdminVuelos.obtenerCiudadCodigo(ciudadOrigen);
            Ciudad destino = AdminVuelos.obtenerCiudadCodigo(ciudadDestino);
            List<Vuelo> vuelosDisponibles = AdminVuelos.ConsultarVuelosDisponiblesTarifa(origen, destino);
            return vuelosDisponibles;
        }

    }
}