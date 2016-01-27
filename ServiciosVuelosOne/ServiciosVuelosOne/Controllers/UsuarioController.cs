using ModelosDeComunicacion.Request.Usuario;
using ModelosDeComunicacion.Response.Usuario;
using ServiciosVuelosOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ServiciosVuelosOne.Util;
using ModelosDeComunicacion.Response;
using ServiciosVuelosOne.DataAccess;
using ServiciosVuelosOne.BusinessLogic;

namespace ServiciosVuelosOne.Controllers
{
    public class UsuarioController : ApiController
    {
        //
        // GET: /Usuario/
        // Objeto de negocio de la administraciòn de usuarios
        public BOAdministrarUsuarios AdminUsuariosBO { get; set; }

        private static readonly log4net.ILog logAppender = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public UsuarioController()
        {
            AdminUsuariosBO = new BOAdministrarUsuarios();
        }

        public UsuarioController(IAdministrarUsuarios adminUsuariosInterface)
        {
            AdminUsuariosBO = new BOAdministrarUsuarios(adminUsuariosInterface);
        }

        [HttpPost]
        [System.Web.Http.ActionName("IngresarUsuario")]
        public HttpResponseMessage RequestIngresarUsuario(HttpRequestMessage requestMessage, [FromBody] UsuarioRequest request)
        {
            Usuario usuario = UtilVuelos.TransformarUsuarioRequest(request);
            String respuesta = AdminUsuariosBO.IngresarUsuario(usuario);
            if (respuesta.Equals(UtilVuelos.EXITO))
            {
                //Se ingreso exitosamente,establezco la respuesta
                UsuarioResponse respuestaUsuario = new UsuarioResponse();
                StatusResponse estadoRespuesta = new StatusResponse();
                estadoRespuesta.StatusCode = HttpStatusCode.Found;
                estadoRespuesta.Message = MessagesConstantsUsuario.USUARIO_REGISTRO_EXITO;
                respuestaUsuario.ResponseStatus = estadoRespuesta;
                var response = Request.CreateResponse<UsuarioResponse>(HttpStatusCode.OK, respuestaUsuario);
                return response;
            }
            else
            {
                //Error al registrar un registro
                UsuarioResponse respuestaUsuario = new UsuarioResponse();
                StatusResponse estadoRespuesta = new StatusResponse();
                estadoRespuesta.StatusCode = HttpStatusCode.NotFound;
                estadoRespuesta.Message = MessagesConstantsUsuario.USUARIO_REGISTRO_FALLIDO;
                respuestaUsuario.ResponseStatus = estadoRespuesta;
                var response = Request.CreateResponse<UsuarioResponse>(HttpStatusCode.OK, respuestaUsuario);
                return response;
            }

        }

        [System.Web.Http.ActionName("LoguearUsuario")]
        [HttpPost]
        public HttpResponseMessage RequestLoguearUsuario(HttpRequestMessage requestMessage, [FromBody] UsuarioRequest request)
        {
            Usuario usuario = UtilVuelos.TransformarUsuarioRequest(request);
            String respuesta = AdminUsuariosBO.LoguearUsuario(usuario);
            if (respuesta.Equals(UtilVuelos.EXITO))
            {
                //Se ingreso exitosamente,establezco la respuesta
                UsuarioResponse  respuestaUsuario = new UsuarioResponse();
                StatusResponse estadoRespuesta = new StatusResponse();
                estadoRespuesta.StatusCode = HttpStatusCode.Found;
                estadoRespuesta.Message = MessagesConstantsUsuario.USUARIO_LOGUEO_EXITO;
                respuestaUsuario.ResponseStatus = estadoRespuesta;
                var response = Request.CreateResponse<UsuarioResponse>(HttpStatusCode.OK, respuestaUsuario);
                //Permitir  que sel servicio sea accedido de diferentes dominios
                response.Headers.Add("Access-Control-Allow-Origin", "*");
                return response;
            }
            else
            {
                //Logueo Fallido
                UsuarioResponse respuestaUsuario = new UsuarioResponse();
                StatusResponse estadoRespuesta = new StatusResponse();
                estadoRespuesta.StatusCode = HttpStatusCode.NotFound;
                estadoRespuesta.Message = MessagesConstantsUsuario.USUARIO_LOGUEO_FALLIDO;
                respuestaUsuario.ResponseStatus = estadoRespuesta;
                var response = Request.CreateResponse<UsuarioResponse>(HttpStatusCode.OK, respuestaUsuario);
                //Permitir  que sel servicio sea accedido de diferentes dominios
                response.Headers.Add("Access-Control-Allow-Origin", "*");
                return response;
            }
        }

    }
}