using VuelosWeb.Commons.ConsumeREST;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelosDeComunicacion.Request.Usuario;

namespace VuelosWeb.Commons.ConsumeOBJ
{
    /// <summary>
    /// Clase para generalizar el llamado a los servicios.
    /// </summary>
    /// <typeparam name="TRequest">Tipo genérico de parámetro del request.</typeparam>
    /// <typeparam name="TResponse">Tipo genérico de parámetro del response.</typeparam>
    public class GenericConsumer<TRequest, TResponse> : EConsumer
        where TRequest : new()
        where TResponse : new()
    {
        /// <summary>
        /// Variable de clase para crear el request genérico.
        /// </summary>
        private RestRequest request;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="GenericConsumer" /> class.
        /// </summary>
        public GenericConsumer()
        {
            this.request = new RestRequest();
        }

        /// <summary>
        /// Metodo para setear el Uri del servicio y el método Http.
        /// </summary>
        /// <param name="nameController">Uri del controlador.</param>
        /// <param name="nameAction">Uri de la acción.</param>
        /// <param name="method">Método Http.</param>
        public void SetServiceParameters(string nameController, string nameAction, Method method)
        {
            base.UriControler = nameController;
            base.UriAction = nameAction;
            base.MethodConsume = method;
        }

        /// <summary>
        /// Llamado al servicio.
        /// </summary>
        /// <param name="genericRequest">Request genérico.</param>
        /// <returns>Response genérico.</returns>
        public TResponse GetService(TRequest genericRequest)
        {
            this.request.Resource = base.UriControler + "/" + base.UriAction;
            this.request.Method = base.MethodConsume;
            this.request.AddObject(genericRequest);
            TResponse response = RestConsumer.InstanceRest.Execute<TResponse>(this.request);
            return response;
        }
    }
}