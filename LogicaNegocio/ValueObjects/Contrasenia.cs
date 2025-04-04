using ExcepcionesPropias.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects
{
    public class Contrasenia:IEquatable<Contrasenia>
    {
        public string Valor { get; private set; }

        public Contrasenia(string valor)
        {
            Valor = valor;
            Validar();
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Valor))
                throw new DatosInvalidosException("La contraseña no puede estar vacía.");

            // Validar longitud mínima (por ejemplo, 8 caracteres)
            if (Valor.Length < 8)
                throw new DatosInvalidosException("La contraseña debe tener al menos 8 caracteres.");

            // Validar que contenga al menos una letra mayúscula
            if (!Regex.IsMatch(Valor, @"[A-Z]"))
                throw new DatosInvalidosException("La contraseña debe contener al menos una letra mayúscula.");

            // Validar que contenga al menos una letra minúscula
            if (!Regex.IsMatch(Valor, @"[a-z]"))
                throw new DatosInvalidosException("La contraseña debe contener al menos una letra minúscula.");

            // Validar que contenga al menos un número
            if (!Regex.IsMatch(Valor, @"\d"))
                throw new DatosInvalidosException("La contraseña debe contener al menos un número.");

            // Validar que no contenga espacios
            if (Valor.Contains(" "))
                throw new DatosInvalidosException("La contraseña no puede contener espacios.");
        }

        public bool Equals(Contrasenia? other)
        {
            if (other == null) return false;
            return Valor.Equals(other.Valor);
        }
    }
}
