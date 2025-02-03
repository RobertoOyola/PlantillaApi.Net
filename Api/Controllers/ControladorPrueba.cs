using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Api.Services;
using log4net;
using Modelos.Entidades;
using static System.Net.Mime.MediaTypeNames;

namespace Api.Controllers
{
    public class ControladorPrueba : ApiController
    {
        private readonly ServicioPrueba _pruebaServicio;

        public ILog Log { get; set; }
        public ControladorPrueba(ServicioPrueba pruebaServicio)
        {
            _pruebaServicio = pruebaServicio;
        }

        [HttpPost]
        [Route("get")]
        public IHttpActionResult get(string TipoBanca, decimal monto)
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
