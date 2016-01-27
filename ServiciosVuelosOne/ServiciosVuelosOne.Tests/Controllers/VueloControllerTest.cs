using ModelosDeComunicacion.Modelos;
using ModelosDeComunicacion.Request.Vuelo;
using ModelosDeComunicacion.Response.Vuelo;
using NUnit.Framework;
using ServiciosVuelosOne.Controllers;
using ServiciosVuelosOne.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ServiciosVuelosOne.Tests.Controllers
{
    [TestFixture]
    public class VueloControllerTest
    {
        private static string URLApi = "http://localhost:51256/api/";
        private HttpConfiguration Config = new HttpConfiguration();
        private HttpRequestMessage Request;

        private VueloController VueloController { set; get; }

        [SetUp]
        public void Initialize()
        {
            AdministrarVuelosMOCK mock = new AdministrarVuelosMOCK();
            Request = new HttpRequestMessage(HttpMethod.Post, URLApi + "ListarCiudades");
            VueloController = new VueloController(mock);
            VueloController.Request = new HttpRequestMessage();
            VueloController.Request.SetConfiguration(new HttpConfiguration());
        }

        [TearDown]
        public void TearDown()
        {
            //Liberar recursos, en caso de ser necesario
            VueloController = null;
        }

        [Test]
        public void ListarCiudadesExitoso()
        {
            //Arrange
            VueloRequest vueloReq = new VueloRequest();

            //ACT
            var response = VueloController.RequestListarCiudades(Request, vueloReq);
            dynamic objresponse = response.Content.ReadAsAsync<VueloResponse>().Result;
            VueloResponse DataResponse = (VueloResponse)objresponse;

            //Assert
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            Assert.AreEqual(DataResponse.ResponseStatus.StatusCode, System.Net.HttpStatusCode.Found);
        }

        [Test]
        public void ListarVuelosDisponiblesTipoHorarioExitosaTest()
        {
            // Arrange
            VueloRequest vueloReq = new VueloRequest();
            DatosVuelo datosVuelo = new DatosVuelo();
            DatosCiudad ciudadOrigen = new DatosCiudad();
            ciudadOrigen.Codigo = 1;
            datosVuelo.Origen = ciudadOrigen;
            DatosCiudad ciudadDestino = new DatosCiudad();
            ciudadDestino.Codigo = 2;
            datosVuelo.Destino = ciudadDestino;
            vueloReq.InformacionVuelo = datosVuelo;


            // Act
            var response = VueloController.RequestListarVuelosXHorario(Request, vueloReq);
            dynamic objresponse = response.Content.ReadAsAsync<VueloResponse>().Result;
            VueloResponse DataResponse = (VueloResponse)objresponse;

            // Assert
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            Assert.AreEqual(DataResponse.ResponseStatus.StatusCode, System.Net.HttpStatusCode.Found);
            Assert.Greater(DataResponse.vuelos.Count, 0);
            Assert.That(DataResponse.vuelos.Count > 0);
        }

        [Test]
        public void ListarVuelosDisponiblesTipoHorarioFallidaTest()
        {
            // Arrange
            VueloRequest vueloReq = new VueloRequest();
            DatosVuelo datosVuelo = new DatosVuelo();
            DatosCiudad ciudadOrigen = new DatosCiudad();
            ciudadOrigen.Codigo = 3;
            datosVuelo.Origen = ciudadOrigen;
            DatosCiudad ciudadDestino = new DatosCiudad();
            ciudadDestino.Codigo = 3;
            datosVuelo.Destino = ciudadDestino;
            vueloReq.InformacionVuelo = datosVuelo;


            // Act
            var response = VueloController.RequestListarVuelosXHorario(Request, vueloReq);
            dynamic objresponse = response.Content.ReadAsAsync<VueloResponse>().Result;
            VueloResponse DataResponse = (VueloResponse)objresponse;

            // Assert
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            Assert.AreEqual(DataResponse.ResponseStatus.StatusCode, System.Net.HttpStatusCode.NotFound);
            Assert.IsNull(DataResponse.vuelos);
        }

        [Test]
        public void ListarVuelosDisponiblesTipoTarifaExitosaTest()
        {
            // Arrange
            VueloRequest vueloReq = new VueloRequest();
            DatosVuelo datosVuelo = new DatosVuelo();
            DatosCiudad ciudadOrigen = new DatosCiudad();
            ciudadOrigen.Codigo = 1;
            datosVuelo.Origen = ciudadOrigen;
            DatosCiudad ciudadDestino = new DatosCiudad();
            ciudadDestino.Codigo = 2;
            datosVuelo.Destino = ciudadDestino;
            vueloReq.InformacionVuelo = datosVuelo;


            // Act
            var response = VueloController.RequestListarVuelosXTarifa(Request, vueloReq);
            dynamic objresponse = response.Content.ReadAsAsync<VueloResponse>().Result;
            VueloResponse DataResponse = (VueloResponse)objresponse;

            // Assert
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            Assert.AreEqual(DataResponse.ResponseStatus.StatusCode, System.Net.HttpStatusCode.Found);
            Assert.Greater(DataResponse.vuelos.Count, 0);
            Assert.That(DataResponse.vuelos.Count > 0);
        }

        [Test]
        public void ListarVuelosDisponiblesTipoTarifaFallidaTest()
        {
            // Arrange
            VueloRequest vueloReq = new VueloRequest();
            DatosVuelo datosVuelo = new DatosVuelo();
            DatosCiudad ciudadOrigen = new DatosCiudad();
            ciudadOrigen.Codigo = 3;
            datosVuelo.Origen = ciudadOrigen;
            DatosCiudad ciudadDestino = new DatosCiudad();
            ciudadDestino.Codigo = 3;
            datosVuelo.Destino = ciudadDestino;
            vueloReq.InformacionVuelo = datosVuelo;


            // Act
            var response = VueloController.RequestListarVuelosXTarifa(Request, vueloReq);
            dynamic objresponse = response.Content.ReadAsAsync<VueloResponse>().Result;
            VueloResponse DataResponse = (VueloResponse)objresponse;

            // Assert
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            Assert.AreEqual(DataResponse.ResponseStatus.StatusCode, System.Net.HttpStatusCode.NotFound);
            Assert.IsNull(DataResponse.vuelos);
        }
    }
}
