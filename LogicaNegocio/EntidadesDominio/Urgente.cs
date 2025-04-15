using ExcepcionesPropias.Excepciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio
{
    [Table("Urgentes")]
    public class Urgente : Envio
    {
        public string Direccion { get; set; }
        public bool EntregaEficiente { get; set; }

        public Urgente() : base()
        {

        }
        public void Entrega24Hs()
        {
            if ((FechaEntrega - FechaEnvio) < TimeSpan.FromHours(24))
            {
                EntregaEficiente = true;
            }
            else
            {
                EntregaEficiente = false;
            }

        }

        public override void FinalizarEnvio()
        {
            base.FinalizarEnvio();
            Entrega24Hs();
        }

        public override void Validar()
        {
            base.Validar();
            if (Direccion == null)
                throw new DatosInvalidosException("La dirección no puede estar vacia");
        }
    }
}
