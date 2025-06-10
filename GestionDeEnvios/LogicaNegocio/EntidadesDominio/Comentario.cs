using ExcepcionesPropias.Excepciones;
using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio
{
    public class Comentario : IValidable
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public DateTime Fecha { get; set; }
        public Usuario Usuario { get; set; }

        public Comentario()
        {
            Fecha = DateTime.Now;
        }

        public void Validar()
        {
            if (String.IsNullOrEmpty(Texto))
                throw new DatosInvalidosException("El comentario no puede estar vacio");
            if (Usuario == null)
                throw new DatosInvalidosException("El usuario no puede estar vacio");
        }
    }
}
