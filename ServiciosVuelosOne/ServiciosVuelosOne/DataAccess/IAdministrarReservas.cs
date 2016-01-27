using ServiciosVuelosOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosVuelosOne.DataAccess
{
    public interface IAdministrarReservas
    {
        /// <summary>
        /// Mètodo encargado de realizar una reserva para el usuario
        /// </summary>
        /// <param name="vuelo"></param>
        /// <param name="username"></param>
        /// <returns>true si se realizò la reserva,de lo contrario false</returns>
        Boolean RealizarReserva(Vuelo vuelo, String username);

        /// <summary>
        /// Mètodo encargado de consultar las reservas de un usuario
        /// </summary>
        /// <param name="username"></param>
        /// <returns>reservas de un usuario</returns>
        List<Reserva> ConsultarReservasUsuario(String username);

        /// <summary>
        /// Mètodo encargado de validar si el usuario tiene un vuelo reservado para esa misma hora
        /// </summary>
        /// <param name="vuelo">vuelo que se va a reservar</param>
        /// <returns>true si si puede realizar la reserva,de lo contrario false</returns>
        Boolean PuedeReservarVuelo(Vuelo vuelo);
    }
}
