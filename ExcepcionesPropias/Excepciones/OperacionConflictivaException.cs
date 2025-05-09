using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesPropias.Excepciones
{
    public class OperacionConflictivaException : Exception
    {
        public OperacionConflictivaException()
        {

        }

        public OperacionConflictivaException(string mensaje) : base(mensaje)
        {

        }

        public OperacionConflictivaException(string mensaje, Exception interna) : base(mensaje, interna)
        {

        }
    }
}
