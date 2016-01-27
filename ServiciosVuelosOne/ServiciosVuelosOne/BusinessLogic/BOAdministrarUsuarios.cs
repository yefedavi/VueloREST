using ServiciosVuelosOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using ServiciosVuelosOne.DataAccess;
using ServiciosVuelosOne.Util;

namespace ServiciosVuelosOne.BusinessLogic
{
    public class BOAdministrarUsuarios
    {
        //
        // GET: /Usuario/
        //Interfaz de negocio de la administraciòn de usuarios
        public IAdministrarUsuarios AdminUsuarios { get; set; }

        /// <summary>
        /// Contructor de la clase
        /// </summary>
        public BOAdministrarUsuarios()
        {
            AdminUsuarios = new AdministrarUsuarios();
        }

        /// <summary>
        /// Constructor de la clase con parametros
        /// </summary>
        /// <param name="interfaceAdminUsuarios"></param>
        public BOAdministrarUsuarios(IAdministrarUsuarios interfaceAdminUsuarios)
        {
            AdminUsuarios = interfaceAdminUsuarios;
        }

        /// <summary>
        /// Mètodo encargado de llaamar el mètodo de negocio para la creaciòn
        /// de un usuario en la base de datos
        /// </summary>
        /// <param name="usuario">usuario que se va a crear</param>
        /// <returns></returns>
        /// 
        public String IngresarUsuario(Usuario usuario)
        {
            Boolean respuesta = AdminUsuarios.CrearUsuario(usuario);
            if (respuesta)
            {
                return UtilVuelos.EXITO;
            }
            else
            {
                return UtilVuelos.FALLIDO;
            }

        }

        /// <summary>
        /// Mètodo encargado de loguear un usuario a la aplicaciòn
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        /// 
        public String LoguearUsuario(Usuario usuario)
        {
            Boolean respuesta = AdminUsuarios.LoguearUsuario(usuario.Username, usuario.Password);
            if (respuesta)
            {
                //Almaceno el usuario en sesion
                return UtilVuelos.EXITO;
            }
            else
            {
                return UtilVuelos.FALLIDO;
            }
        }
    }
}