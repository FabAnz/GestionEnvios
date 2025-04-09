using ExcepcionesPropias.Excepciones;
using LogicaNegocio.InterfacesDominio;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio
{
    public class RegistroAuditable : IValidable
    {
        public int Id { get; set; }
        public string Accion { get; set; }
        public Usuario UsuarioRealizoAcccion { get; set; }
        public DateTime Fecha { get; set; }
        public Usuario UsuarioAfectado { get; set; }

        public RegistroAuditable()
        {
            Fecha = DateTime.Now;
        }

        public void Validar()
        {
            if (String.IsNullOrEmpty(Accion))
                throw new DatosInvalidosException("La accion no puede estar vacia");
            if (UsuarioRealizoAcccion == null)
                throw new DatosInvalidosException("El usuario activo no puede estar vacio");
            if (UsuarioAfectado == null)
                throw new DatosInvalidosException("El usuario afectado no puede estar vacio");
        }
    }
}
