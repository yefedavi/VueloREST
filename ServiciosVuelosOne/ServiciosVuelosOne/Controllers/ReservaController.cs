using ServiciosVuelosOne.BusinessLogic;
using ServiciosVuelosOne.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiciosVuelosOne.Controllers
{
    public class ReservaController : ApiController
    {
        private static readonly log4net.ILog logAppender = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BOAdministrarReservas  AdminReservasBO{ set;get;}

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public ReservaController()
        {
            AdminReservasBO = new BOAdministrarReservas();
        }

        public ReservaController(IAdministrarReservas adminReservasInterface,IAdministrarUsuarios adminUserInterface,IAdministrarVuelos adminVuelosInterface)
        {
            AdminReservasBO = new BOAdministrarReservas(adminUserInterface,adminReservasInterface, adminVuelosInterface);
        }
    }
}
