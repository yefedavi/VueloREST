using ModelosDeComunicacion.Modelos;
using ModelosDeComunicacion.Request.Usuario;
using ModelosDeComunicacion.Request.Vuelo;
using ServiciosVuelosOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosVuelosOne.Util
{
    public class UtilVuelos
    {
        public static String EXITO = "Exitoso";
        public static String FALLIDO = "Fallido";
        public static Usuario TransformarUsuarioRequest(UsuarioRequest request)
        {
            Usuario user = new Usuario();
            user.Codigo = request.Codigo;
            user.Username = request.Username;
            user.FechaNacimiento = request.FechaNacimiento;
            user.Password = request.Password;
            return user;
        }

        public static Vuelo TransformarVueloRequest(VueloRequest request)
        {
            Vuelo vuelo = new Vuelo();
            if (request != null)
            {
                if (request.InformacionVuelo != null)
                {
                    DatosVuelo datosVuelo = request.InformacionVuelo;
                    vuelo.Id = datosVuelo.Id;
                    vuelo.HorarioSalida = datosVuelo.HorarioSalida;
                    vuelo.HorarioLlegada = datosVuelo.HorarioLlegada;
                    vuelo.Estado = datosVuelo.Estado;
                    vuelo.AsientosDisponibles = datosVuelo.AsientosDisponibles;
                    Aerolinea aerolinea = null;
                    if (datosVuelo.Aerolinea != null)
                    {
                        aerolinea = new Aerolinea();
                        aerolinea.Codigo = datosVuelo.Aerolinea.Codigo;
                        aerolinea.Nombre = datosVuelo.Aerolinea.Nombre;
                    }
                    vuelo.Aerolinea1 = aerolinea;
                    Ciudad ciudadOrigen = null;
                    if (datosVuelo.Origen != null)
                    {
                        ciudadOrigen = new Ciudad();
                        ciudadOrigen.Codigo = datosVuelo.Origen.Codigo;
                        ciudadOrigen.Nombre = datosVuelo.Origen.Nombre;
                    }
                    vuelo.Ciudad1 = ciudadOrigen;
                    Ciudad ciudadDestino = null;
                    if(datosVuelo.Destino != null)
                    {
                        ciudadDestino = new Ciudad();
                        ciudadDestino.Codigo = datosVuelo.Destino.Codigo;
                        ciudadDestino.Nombre = datosVuelo.Destino.Nombre;
                    }
                    vuelo.Ciudad = ciudadDestino;

                }
               
            }
            return vuelo;
        }
    }
}