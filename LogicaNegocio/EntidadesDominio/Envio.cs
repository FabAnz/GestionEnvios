using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio
{
    public abstract class Envio : IValidable
    {
        public virtual void FinalizarEnvio()
        {
            //ToDo
        }

        public void Validar()
        {
            //ToDo
        }
    }
}
