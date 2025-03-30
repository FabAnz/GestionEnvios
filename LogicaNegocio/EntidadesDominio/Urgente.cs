using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio
{
    public class Urgente : Envio
    {
        public bool EntregaEficiente()
        {
            bool entregaEficiente = false;

            return entregaEficiente;
        }

        public override void FinalizarEnvio()
        {
            base.FinalizarEnvio();
            //ToDo
        }
    }
}
