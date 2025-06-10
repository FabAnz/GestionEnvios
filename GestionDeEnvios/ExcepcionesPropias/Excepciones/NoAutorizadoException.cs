using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesPropias.Excepciones
{
    public class NoAutorizadoException : Exception
    {
        public NoAutorizadoException()
        {

        }

        public NoAutorizadoException(string mensaje) : base(mensaje)
        {

        }

        public NoAutorizadoException(string mensaje, Exception interna) : base(mensaje, interna)
        {

        }
    }
}
