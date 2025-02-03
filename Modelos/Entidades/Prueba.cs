using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Entidades
{
    [DataContract]
    public class PruebaModelo
    {
        private int _codigo;
        private string _nombre;

        [DataMember]
        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        [DataMember]
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
    }
}
