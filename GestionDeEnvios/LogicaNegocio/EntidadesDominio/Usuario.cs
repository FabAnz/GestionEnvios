﻿using ExcepcionesPropias.Excepciones;
using LogicaNegocio.InterfacesDominio;
using LogicaNegocio.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio
{
    public class Usuario : IValidable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public Email Email { get; set; }
        public Contrasenia Contrasenia { get; set; }
        public Rol Rol { get; set; }

        public Usuario()
        {

        }

        public void Validar()
        {
            if (String.IsNullOrEmpty(Nombre))
                throw new DatosInvalidosException("El nombre no puede estar vacio");
            if (String.IsNullOrEmpty(Apellido))
                throw new DatosInvalidosException("El apellido no puede estar vacio");
            if (String.IsNullOrEmpty(Direccion))
                throw new DatosInvalidosException("La direccion no puede estar vacio");
            if (String.IsNullOrEmpty(Telefono))
                throw new DatosInvalidosException("El telefono no puede estar vacio");
            if (Email == null)
                throw new DatosInvalidosException("El email no puede estar vacio");
            if (Contrasenia == null)
                throw new DatosInvalidosException("La contraseña no puede estar vacia");
            if (Rol == null)
                throw new DatosInvalidosException("El rol no puede estar vacio");
        }
    }
}
