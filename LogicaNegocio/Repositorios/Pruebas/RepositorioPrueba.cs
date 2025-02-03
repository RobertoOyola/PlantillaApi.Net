using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Datos.Pruebas;
using log4net;
using Modelos.Entidades;

namespace LogicaNegocio.Repositorios.Prueba
{
    public class RepositorioPrueba : IRepositorioPrueba
    {
        private readonly IDatosPrueba _pruebaDatos;

        public ILog Log { get; set; }

        public RepositorioPrueba(IDatosPrueba pruebaDatos)
        {
            _pruebaDatos = pruebaDatos;
        }

        public PruebaModelo get(string TipoBanca, decimal monto)
        {
            PruebaModelo resultado = new PruebaModelo();
            try
            {
                resultado = _pruebaDatos.get(TipoBanca, monto);
            }
            catch (System.InvalidCastException exC)
            {
                Log.Error("get==> Error:" + exC.Message + " Trace: " + exC.StackTrace);
                resultado.Codigo = 40;
                resultado.Nombre = exC.Message;
                return resultado;
            }
            catch (System.ArrayTypeMismatchException exA)
            {
                Log.Error("get==> Error:" + exA.Message + " Trace: " + exA.StackTrace);
                resultado.Codigo = 40;
                resultado.Nombre = exA.Message;
                return resultado;
            }
            catch (TimeoutException ext)
            {
                Log.Error("get==> Error:" + ext.Message + " Trace: " + ext.StackTrace);
                resultado.Codigo = 40;
                resultado.Nombre = ext.Message;
                return resultado;
            }
            return resultado;
        }
    }
}
