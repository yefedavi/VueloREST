using VuelosWeb.Commons.ConsumeREST;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuelosWeb.Commons.ConsumeOBJ
{
    public class EConsumer
    {
        public string UriControler { get; set; }
        public string UriAction { get; set; }

        public List<ParametrosREST> listaParametros { get; set; }

        public Method MethodConsume { get; set; }

    }
}
