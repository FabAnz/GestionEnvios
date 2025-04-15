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
    public class Agencia : IValidable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public Coordenadas Coordenadas { get; set; }

        public Agencia()
        {

        }

        public void Validar()
        {
            if (Nombre == null)
                throw new DatosInvalidosException("El nombre no puede estar vacio");
            
            if (Direccion == null)
                throw new DatosInvalidosException("La dirrecion no puede estar vacia");
            
            if (Coordenadas == null)
                throw new DatosInvalidosException("Las coordenadas no pueden estar vacias");
        }
    }
}
