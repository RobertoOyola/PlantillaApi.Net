using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Api.Services;
using log4net;
using Modelos.Entidades;

namespace Api.Controllers
{
    [RoutePrefix("SimuladorAhorro")]
    [RemoveMvcVersionHeaderFilter]
    public class DefaultController : ApiController
    {
        private readonly ServicioPrueba _pruebaServicio;

        private static readonly ILog Log = LogManager.GetLogger(typeof(DefaultController));

        public DefaultController(ServicioPrueba pruebaServicio)
        {
            _pruebaServicio = pruebaServicio;
        }

        [HttpPost]
        [Route("get")]
        public IHttpActionResult Get(string TipoBanca, decimal monto)
        {
            PruebaModelo resul = new PruebaModelo();
            try
            {
                resul = _pruebaServicio.get(TipoBanca, monto);
            }
            catch (Exception ex)
            {
                Log.Error("get==> Error:" + ex.Message + " Trace: " + ex.StackTrace);
            }

            return Ok(resul);
        }

    }
}
