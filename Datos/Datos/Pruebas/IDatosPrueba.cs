using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos.Entidades;

namespace Datos.Datos.Pruebas
{
    public interface IDatosPrueba
    {
        PruebaModelo get(string TipoBanca, decimal monto);
    }
}
