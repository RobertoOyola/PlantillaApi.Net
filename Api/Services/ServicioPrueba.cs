using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Datos.Datos.Pruebas;
using log4net;
using LogicaNegocio.Repositorios.Prueba;
using Modelos.Entidades;

namespace Api.Services
{
    public class ServicioPrueba
    {
        private readonly IRepositorioPrueba _pruebaRepositorio;

        public ILog Log { get; set; }

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