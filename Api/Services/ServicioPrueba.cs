using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api.Controllers;
using Datos.Datos.Pruebas;
using log4net;
using LogicaNegocio.Repositorios.Prueba;
using Modelos.Entidades;

namespace Api.Services
{
    public class ServicioPrueba
    {
        private readonly IRepositorioPrueba _pruebaRepositorio;

        private static readonly ILog Log = LogManager.GetLogger(typeof(ServicioPrueba));

        public ServicioPrueba(IRepositorioPrueba pruebaRepositorio)
        {
            _pruebaRepositorio = pruebaRepositorio;
        }

        public PruebaModelo get(string TipoBanca, decimal monto)
        {
            PruebaModelo resul = new PruebaModelo();
            resul = _pruebaRepositorio.get(TipoBanca, monto);
            return resul;
        }
    }
}