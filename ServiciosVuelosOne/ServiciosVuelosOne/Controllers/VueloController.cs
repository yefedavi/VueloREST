using ModelosDeComunicacion.Modelos;
using ModelosDeComunicacion.Request.Vuelo;
using ModelosDeComunicacion.Response;
using ModelosDeComunicacion.Response.Vuelo;
using ServiciosVuelosOne.BusinessLogic;
using ServiciosVuelosOne.DataAccess;
using ServiciosVuelosOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiciosVuelosOne.Controllers
{
    public class VueloController : ApiController
    {
        //
        // GET: /Usuario/
        //objeto de negocio de la administraciòn de vuelos
        public BOAdministrarVuelos AdminVuelosBO { get; set; }

        public VueloController()
        {
            AdminVuelosBO = new BOAdministrarVuelos();
        }

        public VueloController (IAdministrarVuelos adminVuelosInterface)
        {
            AdminVuelosBO = new BOAdministrarVuelos(adminVuelosInterface);
        }

        /// <summary>
        /// Mètodo encargado de exponer el servicio de listar las ciudades
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [System.Web.Http.ActionName("ListarCiudades")]
        public HttpResponseMessage RequestListarCiudades(HttpRequestMessage requestMessage, [FromBody] VueloRequest request)
        {
            List<Ciudad> ciudades = AdminVuelosBO.ListarCiudades();
            if(ciudades!=null && ciudades.Count > 0)
            {
                List<DatosCiudad> ciudadesResp = ConvertirCiudadDatosCiudadList(ciudades);
                VueloResponse vueloRep = new VueloResponse();
                StatusResponse estadoRespuesta = new StatusResponse();
                estadoRespuesta.StatusCode = HttpStatusCode.Found;
                estadoRespuesta.Message = "Lista de ciudades";
                vueloRep.ResponseStatus = estadoRespuesta;
                vueloRep.ciudades = ciudadesResp;
                var response = Request.CreateResponse<VueloResponse>(HttpStatusCode.OK, vueloRep);
                return response;
            }
            else
            {
                VueloResponse vueloRep = new VueloResponse();
                StatusResponse estadoRespuesta = new StatusResponse();
                estadoRespuesta.StatusCode = HttpStatusCode.NotFound;
                estadoRespuesta.Message = "Sin Resultados";
                vueloRep.ResponseStatus = estadoRespuesta;
                var response = Request.CreateResponse<VueloResponse>(HttpStatusCode.OK, vueloRep);
                return response;
            }
        }

        /// <summary>
        /// Mètodo encargado de convertir del tipo de dato Ciudad a el tipo de dato
        /// DatosCiudad
        /// </summary>
        /// <param name="ciudades"></param>
        /// <returns></returns>
        public List<DatosCiudad> ConvertirCiudadDatosCiudadList(List<Ciudad> ciudades)
        {
            List<DatosCiudad> DatosCiudadList = new List<DatosCiudad>();
            foreach (Ciudad ciudad in ciudades)
            {
                DatosCiudad datosCiudad = new DatosCiudad();
                datosCiudad.Codigo = ciudad.Codigo;
                datosCiudad.Nombre = ciudad.Nombre;
                DatosCiudadList.Add(datosCiudad);
            }
            return DatosCiudadList;
        }

        /// <summary>
        /// Mètodo encargado de convertir del tipo de dato Vuelo a el tipo de dato
        /// DatosVuelo
        /// </summary>
        /// <param name="ciudades"></param>
        /// <returns></returns>
        public List<DatosVuelo> ConvertirVueloDatosVueloList(List<Vuelo> vuelos)
        {
            List<DatosVuelo> datosVueloList = new List<DatosVuelo>();
            foreach (Vuelo vuelo in vuelos)
            {
                DatosVuelo datosVuelo = new DatosVuelo();
                datosVuelo.Id = vuelo.Id;
                datosVuelo.HorarioSalida = vuelo.HorarioSalida;
                datosVuelo.HorarioLlegada = vuelo.HorarioLlegada;
                datosVuelo.Estado = vuelo.Estado;
                datosVuelo.AsientosDisponibles = datosVuelo.AsientosDisponibles;
                DatosCiudad datosCiudadOrigen = new DatosCiudad();
                datosCiudadOrigen.Codigo = vuelo.Ciudad1.Codigo;
                datosCiudadOrigen.Nombre = vuelo.Ciudad1.Nombre;
                datosVuelo.Origen = datosCiudadOrigen;
                DatosCiudad datosCiudadDestino = new DatosCiudad();
                datosCiudadDestino.Codigo = vuelo.Ciudad.Codigo;
                datosCiudadDestino.Nombre = vuelo.Ciudad.Nombre;
                datosVuelo.Destino = datosCiudadDestino ;
                datosVuelo.Tarifa = vuelo.Tarifa;
                datosVueloList.Add(datosVuelo);
            }
            return datosVueloList;
        }

        /// <summary>
        /// Mètodo encargo de exponer el servicio de listar los vuelos
        /// discriminados por horario
        ///
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [System.Web.Http.ActionName("ListarVuelosHorario")]
        public HttpResponseMessage RequestListarVuelosXHorario(HttpRequestMessage requestMessage, [FromBody] VueloRequest request)
        {
            Vuelo vuelo = Util.UtilVuelos.TransformarVueloRequest(request);
            List<Vuelo> vuelosObtenidos = AdminVuelosBO.ListarVuelosTipoHorario(vuelo.Ciudad1.Codigo.ToString(), vuelo.Ciudad.Codigo.ToString());
            if(vuelosObtenidos!=null && vuelosObtenidos.Count > 0)
            {
                List<DatosVuelo> vuelosResp = ConvertirVueloDatosVueloList(vuelosObtenidos);
                VueloResponse vueloRep = new VueloResponse();
                StatusResponse estadoRespuesta = new StatusResponse();
                estadoRespuesta.StatusCode = HttpStatusCode.Found;
                estadoRespuesta.Message = "Lista de vuelos";
                vueloRep.ResponseStatus = estadoRespuesta;
                vueloRep.vuelos = vuelosResp;
                var response = Request.CreateResponse<VueloResponse>(HttpStatusCode.OK, vueloRep);
                return response;
            }else{
                VueloResponse vueloRep = new VueloResponse();
                StatusResponse estadoRespuesta = new StatusResponse();
                estadoRespuesta.StatusCode = HttpStatusCode.NotFound;
                estadoRespuesta.Message = "vuelos no encontrados";
                vueloRep.ResponseStatus = estadoRespuesta;
                var response = Request.CreateResponse<VueloResponse>(HttpStatusCode.OK, vueloRep);
                return response;
            }
        }

        /// <summary>
        /// Mètodo encargado de exponer el servicio de listar los vuelos
        /// discriminados por tarifa
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [System.Web.Http.ActionName("ListarVuelosTarifa")]
        public HttpResponseMessage RequestListarVuelosXTarifa(HttpRequestMessage requestMessage, [FromBody] VueloRequest request)
        {
            Vuelo vuelo = Util.UtilVuelos.TransformarVueloRequest(request);
            List<Vuelo> vuelosObtenidos = AdminVuelosBO.ListarVuelosTipoTarifa(vuelo.Ciudad1.Codigo.ToString(), vuelo.Ciudad.Codigo.ToString());
            if (vuelosObtenidos != null && vuelosObtenidos.Count > 0)
            {
                List<DatosVuelo> vuelosResp = ConvertirVueloDatosVueloList(vuelosObtenidos);
                VueloResponse vueloRep = new VueloResponse();
                StatusResponse estadoRespuesta = new StatusResponse();
                estadoRespuesta.StatusCode = HttpStatusCode.Found;
                estadoRespuesta.Message = "Lista de vuelos";
                vueloRep.ResponseStatus = estadoRespuesta;
                vueloRep.vuelos = vuelosResp;
                var response = Request.CreateResponse<VueloResponse>(HttpStatusCode.OK, vueloRep);
                return response;
            }
            else {
                VueloResponse vueloRep = new VueloResponse();
                StatusResponse estadoRespuesta = new StatusResponse();
                estadoRespuesta.StatusCode = HttpStatusCode.NotFound;
                estadoRespuesta.Message = "vuelos no encontrados";
                vueloRep.ResponseStatus = estadoRespuesta;
                var response = Request.CreateResponse<VueloResponse>(HttpStatusCode.OK, vueloRep);
                return response;
            }
        }
    }
}
