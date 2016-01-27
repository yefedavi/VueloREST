using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiciosVuelosOne.DataAccess;
using ServiciosVuelosOne.Models;

namespace ServiciosVuelosOne.Tests.Mocks
{
    public class AdministrarVuelosMOCK : IAdministrarVuelos
    {

        public List<Vuelo> ConsultarVuelosDisponiblesHorarios(Ciudad ciudadOrigen, Ciudad ciudadDestino)
        {
            if (ciudadOrigen.Codigo == 3)
            {
                return new List<Vuelo>();
            }

            List<Vuelo> vuelos = new List<Vuelo>();

            Vuelo vueloUno = new Vuelo();
            vueloUno.Id = 1;
            vueloUno.Estado = "SALIO";
            vueloUno.Origen = 1;
            vueloUno.Destino = 2;

            Ciudad cOrigen = new Ciudad();
            cOrigen.Codigo = 1;
            vueloUno.Ciudad1 = cOrigen;

            Ciudad cDestino = new Ciudad();
            cDestino.Codigo = 2;
            vueloUno.Ciudad = cDestino;


            vueloUno.HorarioSalida = new DateTime();
            vueloUno.HorarioLlegada = new DateTime();

            Vuelo vueloDos = new Vuelo();
            vueloDos.Id = 2;
            vueloDos.Estado = "SALIO";
            vueloDos.Origen = 1;
            vueloDos.Destino = 2;
            vueloDos.HorarioSalida = new DateTime();
            vueloDos.HorarioLlegada = new DateTime();

            vueloDos.Ciudad1 = cOrigen;

            vueloDos.Ciudad = cDestino;

            vuelos.Add(vueloUno);
            vuelos.Add(vueloDos);
            return vuelos;
        }

        public List<Vuelo> ConsultarVuelosDisponiblesTarifa(Ciudad ciudadOrigen, Ciudad ciudadDestino)
        {

            if (ciudadOrigen.Codigo == 3)
            {
                return new List<Vuelo>();
            }

            List<Vuelo> vuelos = new List<Vuelo>();

            Vuelo vueloUno = new Vuelo();
            vueloUno.Id = 1;
            vueloUno.Estado = "SALIO";
            vueloUno.Origen = 1;
            vueloUno.Destino = 2;
            vueloUno.HorarioSalida = new DateTime();
            vueloUno.HorarioLlegada = new DateTime();
            Ciudad cOrigen = new Ciudad();
            cOrigen.Codigo = 1;
            vueloUno.Ciudad1 = cOrigen;

            Ciudad cDestino = new Ciudad();
            cDestino.Codigo = 2;
            vueloUno.Ciudad = cDestino;

            Vuelo vueloDos = new Vuelo();
            vueloDos.Id = 2;
            vueloDos.Estado = "ARRIBO";
            vueloDos.Origen = 1;
            vueloDos.Destino = 2;
            vueloDos.HorarioSalida = new DateTime();
            vueloDos.HorarioLlegada = new DateTime();
            vueloDos.Ciudad1 = cOrigen;
            vueloDos.Ciudad = cDestino;

            Vuelo vueloTres= new Vuelo();
            vueloTres.Id = 3;
            vueloTres.Estado = "ARRIBO";
            vueloTres.Origen = 1;
            vueloTres.Destino = 2;
            vueloTres.HorarioSalida = new DateTime();
            vueloTres.HorarioLlegada = new DateTime();
            vueloTres.Ciudad1 = cOrigen;
            vueloTres.Ciudad = cDestino;

            vuelos.Add(vueloUno);
            vuelos.Add(vueloDos);
            vuelos.Add(vueloTres);
            return vuelos;
        }

        public List<Ciudad> ObtenerCiudadesVuelos()
        {
            Ciudad ciudad1=new Ciudad();
            ciudad1.Codigo=1;
            ciudad1.Nombre="Medellin";
            Ciudad ciudad2=new Ciudad();
            ciudad2.Codigo=2;
            ciudad2.Nombre="Bogota";
            List<Ciudad>ciudades=new List<Ciudad>();
            ciudades.Add(ciudad1);
            ciudades.Add(ciudad2);
            return ciudades;
        }

        public Ciudad obtenerCiudadCodigo(string codigo)
        {
            Ciudad ciudad = new Ciudad();
            if (codigo.Equals("1"))
            { 
                ciudad.Codigo = 1;
                ciudad.Nombre = "Medellin";
            }
            else if (codigo.Equals("2")) {
                ciudad.Codigo = 2;
                ciudad.Nombre = "Bogota";
            }
            else if (codigo.Equals("3"))
            {
                ciudad.Codigo = 3;
                ciudad.Nombre = "Armenia";
            }
            return ciudad;
        }

         /// <summary>
        /// Mètodo encargado de consultar un vuelo mediante el identificador
        /// </summary>
        /// <param name="idVuelo">Identificador del vuelo</param>
        /// <returns>Vuelo al que corresponde el identificador</returns>
        public Vuelo consultarVueloId(int idVuelo)
        {
            return new Vuelo();
        }
    }
}
