using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using ModelosDeComunicacion.Response.Usuario;
using System.Configuration;
using System.IO;
using ModelosDeComunicacion.Request.Usuario;
using System.Net;
using VuelosWeb.Models;
using VuelosWeb.Commons.ConsumeOBJ;

namespace VuelosOne.Controllers
{
    public class UsuarioController : Controller
    {
        private static String EXITO="Exitoso";
        private static String FALLIDO = "Fallido";

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public UsuarioController()
        {
        }

        /// <summary>
        /// Mètodo encargado de cargar la pagina principal de la aplicaciòn
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View("~/Views/Index.cshtml");
        }

        /// <summary>
        /// Mètodo encargado de llamar el servicio que nos permite registrar un usuario 
        /// en el sistema
        /// </summary>
        /// <param name="usuario">usuario que se va a crear</param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public string IngresarUsuario(Usuario usuario)
        {
            //Invoco el servicio
            UsuarioResponse response = new UsuarioResponse();
            UsuarioRequest request = new UsuarioRequest();
            request.Username = usuario.Username;
            request.Password = usuario.Password;
            request.FechaNacimiento = usuario.FechaNacimiento;
            try
            {
                GenericConsumer<UsuarioRequest, UsuarioResponse> gc = new GenericConsumer<UsuarioRequest, UsuarioResponse>();
                gc.SetServiceParameters("Usuario", "IngresarUsuario", RestSharp.Method.POST);
                response = gc.GetService(request);

                if (response.ResponseStatus.StatusCode.Equals(HttpStatusCode.OK))
                {
                    return EXITO;
                }
                else
                {
                    return FALLIDO;
                }
            }
            catch (Exception e)
            {
                return FALLIDO;
            }

        }

        /// <summary>
        /// Mètodo encargado de loguear un usuario a la aplicaciòn,Llamando el servicio 
        /// de loguear usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public String LoguearUsuario(Usuario usuario) 
        {
            UsuarioResponse response = new UsuarioResponse();
            UsuarioRequest request = new UsuarioRequest();
            request.Username = usuario.Username;
            request.Password = usuario.Password;
            try
            {
                GenericConsumer<UsuarioRequest, UsuarioResponse> gc = new GenericConsumer<UsuarioRequest, UsuarioResponse>();
                gc.SetServiceParameters("Usuario", "LoguearUsuario", RestSharp.Method.POST);
                response = gc.GetService(request);

                if (response.ResponseStatus.StatusCode.Equals(HttpStatusCode.OK))
                {
                    //Almaceno el usuario en sesion
                   Session["usuario"] = usuario.Username;
                   return EXITO;
                }
                else
                {
                    return FALLIDO;
                }
            }
            catch (Exception e)
            {
                return FALLIDO;
            }

        }

        /// <summary>
        /// Método encargado de llamar la pagina registrar usuario
        /// </summary>
        /// <returns></returns>
        public ActionResult RegistrarUsuario()
        {
            return View();
        }

        /// <summary>
        /// Mètodo encargado de llamar la pagina login
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View("");
        }

        /// <summary>
        /// Mètodo encargado de desloguear al usuario de la aplicacion
        /// </summary>
        /// <returns></returns>
        public ActionResult Salir()
        {
            Session["usuario"] = null;
            return View("~/Views/Index.cshtml");
        }




    }
}
