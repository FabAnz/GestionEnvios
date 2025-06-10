using ExcepcionesPropias.Excepciones;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects
{
    [Owned]
    public class Coordenadas : IEquatable<Coordenadas>
    {
        [Column(TypeName = "decimal(10,6)")]
        public decimal Latitud { get; private set; }
        [Column(TypeName = "decimal(10,6)")]
        public decimal Longitud { get; private set; }

        public Coordenadas(decimal latitud, decimal longitud)
        {
            Latitud = latitud;
            Longitud = longitud;
            Validar();
        }

        public void Validar()
        {
            if (Latitud == null)
                throw new DatosInvalidosException("La latitud no puede estar vacia.");

            if (Longitud == null)
                throw new DatosInvalidosException("La latitud no puede estar vacia.");

            if (Latitud < -90 || Latitud > 90)
                throw new DatosInvalidosException("La latitud debe estar entre -90 y 90 grados.");

            if (Longitud < -180 || Longitud > 180)
                throw new DatosInvalidosException("La longitud debe estar entre -180 y 180 grados.");
        }

        public bool Equals(Coordenadas? other)
        {
            if (other == null) return false;

            return Latitud.Equals(other.Latitud) && Longitud.Equals(other.Longitud);
        }
    }
}
