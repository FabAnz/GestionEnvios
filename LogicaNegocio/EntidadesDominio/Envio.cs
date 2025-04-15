using ExcepcionesPropias.Excepciones;
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
        public int Id { get; set; }
        public int NTracking { get; set; }
        public Usuario Vendedor { get; set; }
        public string EmailCliente { get; set; }
        public int Peso { get; set; }
        public EstadoEnvio Estado { get; set; }
        public DateTime FechaEnvio { get; set; }


        public Envio()
        {
            Estado = EstadoEnvio.EN_PROCESO;
            FechaEnvio = DateTime.Now;
        }

        public virtual void FinalizarEnvio()
        {
            Estado = EstadoEnvio.FINALIZADO;
        }

        public virtual void Validar()
        {
            if (Vendedor == null)
                throw new DatosInvalidosException("El vendedor no puede estar vacio");
            if (EmailCliente == null)
                throw new DatosInvalidosException("El cliente no puede estar vacio");
            if (Peso == null || Peso <= 0)
                throw new DatosInvalidosException("El peso debe ser mayor a 0");
            if (FechaEnvio == null)
                throw new DatosInvalidosException("La fecha no puede estar vacia");
        }
    }
}
