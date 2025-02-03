using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Entidades
{
    [DataContract]
    public class CsManejoErroresPr
    {
        private int _CodigoRetorno;
        private string _DescMensUser;
        private string _DescRetorno;
        private object _value;

        [DataMember]
        public int CodigoRetorno
        {
            get { return _CodigoRetorno; }
            set {  _CodigoRetorno = value;  }
        }

        [DataMember]
        public string DescMensUser
        {
            get { return _DescMensUser; }
            set { _DescMensUser = value; }
        }

        [DataMember]
        public string DescRetorno
        {
            get { return _DescRetorno; }
            set { _DescRetorno = value; }
        }

        [DataMember]
        public object Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}
