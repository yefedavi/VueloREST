using ServiciosVuelosOne.DataAccess;
using ServiciosVuelosOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ServiciosVuelosOne.BusinessLogic
{
    public class BOAdministrarReservas
    {
        public IAdministrarUsuarios AdminUsuarios { get; set; }
        public IAdministrarReservas AdminReservas { get; set; }
        public IAdministrarVuelos AdminVuelos { get; set; }
        //
        // GET: /Reserva/
        /// <summary>
        /// Contructor de la clase
        /// </summary>
        public BOAdministrarReservas()
        {
            AdminUsuarios = new AdministrarUsuarios();
            AdminReservas = new AdministrarReservas();
            AdminVuelos = new AdministrarVuelos();
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="administrarUsuarios"></param>
        /// <param name="administrarReservas"></param>
        /// <param name="administrarVuelos"></param>
        public BOAdministrarReservas(IAdministrarUsuarios administrarUsuarios, IAdministrarReservas administrarReservas, IAdministrarVuelos administrarVuelos)
        {
            AdminUsuarios = administrarUsuarios;
            AdminReservas = administrarReservas;
            AdminVuelos = administrarVuelos;
        }

        /// <summary>
        /// Mètodo encargado de realizar la reserva de un vuelo
        /// para un usuario
        /// </summary>
        /// <param name="codigoVuelo"></param>
        /// <returns></returns>
        [HttpPost]
        public String RealizarReserva(string codigoVuelo,string username)
        {
            String resultado = Util.UtilVuelos.FALLIDO;
            // Realizo la consulta del usuario en la base de datos.
            Usuario usuarioReserva = AdminUsuarios.ConsultarUsuario(username);
            // Realizo la consulta del vuelo en la base de datos
            Vuelo vueloReserva = AdminVuelos.consultarVueloId(int.Parse(codigoVuelo));

            if ((usuarioReserva != null) && (vueloReserva != null))
            {
                Boolean seReservo = AdminReservas.RealizarReserva(vueloReserva, usuarioReserva.Username);
                if (seReservo)
                {
                    resultado = Util.UtilVuelos.EXITO;
                }
                else
                {
                    resultado = Util.UtilVuelos.FALLIDO;
                }
            }

            return resultado;
        }

    }
}