using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using VuelosOne.Tests.Mocks;
using System.Web;
using NUnit.Framework;
using ServiciosVuelosOne.Controllers;
using ServiciosVuelosOne.Models;
using ServiciosVuelosOne.DataAccess;
using System.Net.Http;
using System.Web.Http.Hosting;
using System.Web.Http;
using ModelosDeComunicacion.Request.Usuario;
using ModelosDeComunicacion.Response.Usuario;

namespace VuelosOne.Tests.Controllers
{


    [TestFixture]
    public class UsuarioControllerTest
    {
        private static string URLApi = "http://localhost:51256/api/";
        private HttpConfiguration Config = new HttpConfiguration();
        private HttpRequestMessage Request;

        private UsuarioController UsuarioControlador;

        [SetUp]
        public void Initialize() {
            AdministrarUsuarioMOCK mock = new AdministrarUsuarioMOCK();
            Request = new HttpRequestMessage(HttpMethod.Post, URLApi + "IngresarUsuario");
            UsuarioControlador = new UsuarioController(mock);
            UsuarioControlador.Request = new HttpRequestMessage();
            UsuarioControlador.Request.SetConfiguration(new HttpConfiguration());
        }

        [TearDown]
        public void TearDown()
        {
            //Liberar recursos, en caso de ser necesario
            UsuarioControlador = null;
        }

        [Test]
        public void IngresarUsuarioTest()
        {
            //Arrange

            UsuarioRequest userReq = new UsuarioRequest();
            userReq.Codigo = 999;
            userReq.Username = "1";
            userReq.Password = "prueba123";
            userReq.FechaNacimiento = new DateTime();

            //Act
            var response = UsuarioControlador.RequestIngresarUsuario(Request,userReq);
            dynamic objresponse = response.Content.ReadAsAsync<UsuarioResponse>().Result;
            UsuarioResponse DataResponse = (UsuarioResponse)objresponse;

            // Assert
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            Assert.AreEqual(DataResponse.ResponseStatus.StatusCode, System.Net.HttpStatusCode.Found);
        }

        [Test]
        public void IngresarUsuarioTestFalla()
        {
            //Arrange
            UsuarioRequest userReq = new UsuarioRequest();
            userReq.Codigo = 999;
            userReq.Username = "2";
            userReq.Password = "prueba123";
            userReq.FechaNacimiento = new DateTime();

            //Act
            var response = UsuarioControlador.RequestIngresarUsuario(Request,userReq);
            dynamic objresponse = response.Content.ReadAsAsync<UsuarioResponse>().Result;
            UsuarioResponse DataResponse = (UsuarioResponse)objresponse;

            // Assert
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            Assert.AreEqual(DataResponse.ResponseStatus.StatusCode, System.Net.HttpStatusCode.NotFound);
        }

        [Test]
        public void LoguearUsuarioExitosoAplicacionTest()
        {
            //Arrange
            UsuarioRequest userReq = new UsuarioRequest();
            userReq.Username = "UsuarioLogin";
            userReq.Password = "contra123";

            //Act
            var response = UsuarioControlador.RequestLoguearUsuario(Request, userReq);
            dynamic objresponse = response.Content.ReadAsAsync<UsuarioResponse>().Result;
            UsuarioResponse DataResponse = (UsuarioResponse)objresponse;

            // Assert
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            Assert.AreEqual(DataResponse.ResponseStatus.StatusCode, System.Net.HttpStatusCode.Found);
        }
        [Test]
        public void LoguearUsuarioFallidoAplicacionTest()
        {
            //Arrange
            UsuarioRequest userReq = new UsuarioRequest();
            userReq.Username = "UsuarioLogin";
            userReq.Password = "contra1";

            //Act
            var response = UsuarioControlador.RequestLoguearUsuario(Request, userReq);
            dynamic objresponse = response.Content.ReadAsAsync<UsuarioResponse>().Result;
            UsuarioResponse DataResponse = (UsuarioResponse)objresponse;

            // Assert
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            Assert.AreEqual(DataResponse.ResponseStatus.StatusCode, System.Net.HttpStatusCode.NotFound);
        }


    }
}
