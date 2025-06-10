using ExcepcionesPropias.Excepciones;
using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio
{
    public class Rol : IValidable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Rol()
        {
            
        }
        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre)) throw new DatosInvalidosException("El nombre no puede estar vacio");
        }
    }
}
