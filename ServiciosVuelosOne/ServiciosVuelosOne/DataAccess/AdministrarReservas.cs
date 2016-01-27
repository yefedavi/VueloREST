using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiciosVuelosOne.Models;
using ServiciosVuelosOne.DataAccess;
using System.Data;
using System.Data.SqlClient;

namespace ServiciosVuelosOne.DataAccess
{
    public class AdministrarReservas : IAdministrarReservas
    {
        public ReservaVuelosEntities vuelosContext { get; set; }
        private IAdministrarUsuarios AdminUsuarios;
        /// <summary>
        /// Contructor de la clase
        /// </summary>
        public AdministrarReservas()
        {
            AdminUsuarios = new AdministrarUsuarios();
            vuelosContext = new ReservaVuelosEntities();
        }

        public AdministrarReservas(IAdministrarUsuarios adminUsuarios)
        {
            vuelosContext = new ReservaVuelosEntities();
            AdminUsuarios = adminUsuarios;
        }

        /// <summary>
        /// Mètodo encargado de realizar una reserva para el usuario
        /// </summary>
        /// <param name="vuelo"></param>
        /// <param name="username"></param>
        /// <returns>true si se realizò la reserva,de lo contrario false</returns>
        public bool RealizarReserva(Vuelo vuelo, string username)
        {
            Boolean reservaExitosa = false;
            //Valido si el usuario es mayor de edad,si lo es,realizo la reserva
            Boolean esMayorEdad = AdminUsuarios.EsMayorDeEdad(username);
            if (esMayorEdad)
            {
                //Valido si ya hay un vuelo reservado para esa hora.
                Boolean puedeReservar = PuedeReservarVuelo(vuelo);
                if (puedeReservar)
                {
                    //Si puede reservar,reservo el asiento y agrego la reserva
                    int asientosDispVuelo = vuelo.AsientosDisponibles;
                    asientosDispVuelo = asientosDispVuelo - 1;
                    vuelo.AsientosDisponibles = asientosDispVuelo;
                    vuelosContext.Database.ExecuteSqlCommand("UPDATE Vuelo SET AsientosDisponibles =@asiento WHERE " +
                    "Id=@id ", new SqlParameter("asiento", asientosDispVuelo), new SqlParameter("id", vuelo.Id));
                    //Creo la resuerva
                    Usuario usuarioReserva = AdminUsuarios.ConsultarUsuario(username);
                    Reserva reserva = new Reserva();
                    reserva.Codigo = "RSVV-" + vuelo.Id;
                    reserva.Usuario = usuarioReserva.Codigo;
                    reserva.Vuelo = vuelo.Id;
                    vuelosContext.Reserva.Add(reserva);
                    vuelosContext.SaveChanges();
                    reservaExitosa = true;
                }
            }

            return reservaExitosa;
        }

        /// <summary>
        /// Mètodo encargado de consultar las reservas de un usuario
        /// </summary>
        /// <param name="username"></param>
        /// <returns>reservas de un usuario</returns>
        public List<Reserva> ConsultarReservasUsuario(string username)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Mètodo encargado de validar si el usuario tiene un vuelo reservado para esa misma hora
        /// </summary>
        /// <param name="vuelo">vuelo que se va a reservar</param>
        /// <returns>true si si puede realizar la reserva,de lo contrario false</returns>
        public bool PuedeReservarVuelo(Vuelo vuelo)
        {
            Boolean puedeReservar = false;
            //Consulto en la base de datos los vuelos que esten a la misma hora
            var vuelosReservados = from r in vuelosContext.Reserva
                                   join v in vuelosContext.Vuelo on r.Vuelo equals v.Id
                                   where (v.HorarioSalida == vuelo.HorarioSalida) &&
                                   (v.HorarioLlegada == vuelo.HorarioLlegada)
                                   select v;
            if (vuelosReservados.Count() > 0){
                puedeReservar = false;
            }else{
                puedeReservar = true;
            }

            return puedeReservar;
        }
    }
}