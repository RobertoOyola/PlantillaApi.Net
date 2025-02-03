using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos.Entidades;

namespace LogicaNegocio.Repositorios.Prueba
{
    public interface IRepositorioPrueba
    {
        PruebaModelo get(string TipoBanca, decimal monto);
    }
}
