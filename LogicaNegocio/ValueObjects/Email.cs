using ExcepcionesPropias.Excepciones;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects
{
    [Owned]
    public class Email : IEquatable<Email>
    {
        public string Valor { get; private set; }

        public Email(string valor)
        {
            Valor = valor;
            Validar();
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Valor))
                throw new DatosInvalidosException("El Email no puede estar vacio");

            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (!Regex.IsMatch(Valor, patron))
                throw new DatosInvalidosException("Formato de email invalido");

            try
            {
                MailAddress email = new MailAddress(Valor);
            }
            catch (FormatException ex)
            {
                throw new DatosInvalidosException("Formato de email invalido");
            }
        }

        public bool Equals(Email? other)
        {
            if (other == null)
                return false;
            return Valor.Equals(other.Valor);
        }
    }
}
