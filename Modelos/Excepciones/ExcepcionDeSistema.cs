using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Excepciones
{
    [Serializable]
    public class ExcepcionDeSistema : Exception
    {
        public string CodigoError { get; }
        public DateTime Fecha { get; }

        public ExcepcionDeSistema(int codigoError, string mensajeError)
            : base(mensajeError)
        {
            CodigoError = codigoError.ToString();
            Fecha = ObtenerFechaUtcMenos5();
        }

        public ExcepcionDeSistema(decimal codigoError, string mensajeError)
            : base(mensajeError)
        {
            CodigoError = codigoError.ToString();
            Fecha = ObtenerFechaUtcMenos5();
        }

        public ExcepcionDeSistema(string codigoError, string mensajeError)
            : base(mensajeError)
        {
            CodigoError = codigoError;
            Fecha = ObtenerFechaUtcMenos5();
        }

        public ExcepcionDeSistema(string mensajeError)
            : base(mensajeError)
        {
            Fecha = ObtenerFechaUtcMenos5();
        }

        public ExcepcionDeSistema(string mensajeError, Exception innerException)
            : base(mensajeError, innerException)
        {
            Fecha = ObtenerFechaUtcMenos5();
        }

        private DateTime ObtenerFechaUtcMenos5()
        {
            TimeZoneInfo ecuatorianaZonaHoraria = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, ecuatorianaZonaHoraria);
        }

        public override string ToString()
        {
            return $"Error Sistema: {CodigoError}, Mensaje: {Message}, Fecha: {Fecha:yyyy-MM-dd HH:mm:ss} UTC-5, {base.ToString()}";
        }
    }
}
