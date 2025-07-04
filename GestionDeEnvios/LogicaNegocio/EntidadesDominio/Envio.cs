﻿using ExcepcionesPropias.Excepciones;
using LogicaNegocio.InterfacesDominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio
{
    [Index(nameof(NTracking), IsUnique = true)]
    public abstract class Envio : IValidable
    {
        public int Id { get; set; }
        public int NTracking { get; set; }
        public Usuario Vendedor { get; set; }
        public Usuario Cliente{ get; set; }
        public int Peso { get; set; }
        public EstadoEnvio Estado { get; set; }
        public DateTime FechaEnvio { get; set; }
        public DateTime FechaEntrega { get; set; }
        public List<Comentario> Comentarios { get; set; }


        public Envio()
        {
            Estado = EstadoEnvio.EN_PROCESO;
            FechaEnvio = DateTime.Now;
        }

        public virtual void FinalizarEnvio()
        {
            Estado = EstadoEnvio.FINALIZADO;
            FechaEntrega = DateTime.Now;
        }

        public virtual void Validar()
        {
            if (Vendedor == null)
                throw new DatosInvalidosException("El vendedor no puede estar vacio");
            if (Cliente == null)
                throw new DatosInvalidosException("El cliente no puede estar vacio");
            if (Peso == null || Peso <= 0)
                throw new DatosInvalidosException("El peso debe ser mayor a 0");
            if (FechaEnvio == null)
                throw new DatosInvalidosException("La fecha no puede estar vacia");
        }
    }
}
