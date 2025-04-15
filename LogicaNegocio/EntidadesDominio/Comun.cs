using ExcepcionesPropias.Excepciones;
using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio
{
    [Table("Comunes")]
    public class Comun : Envio
    {
        public Agencia Destino { get; set; }

        public Comun() : base()
        {

        }

        public override void Validar()
        {
            base.Validar();
            if (Destino == null)
                throw new DatosInvalidosException("La agencia de destino no puede estar vacio");
        }

    }
}
