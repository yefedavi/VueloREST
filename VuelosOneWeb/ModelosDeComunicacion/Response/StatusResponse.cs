using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelosDeComunicacion.Response
{
    public class StatusResponse
    {
        public System.Net.HttpStatusCode StatusCode { set; get; }
        public String Message { set; get; }
    }
}
