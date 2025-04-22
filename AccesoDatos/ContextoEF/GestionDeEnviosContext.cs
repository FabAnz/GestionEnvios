using LogicaNegocio.EntidadesDominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.ContextoEF
{
    public class GestionDeEnviosContext : DbContext
    {
        public DbSet<RegistroAuditable> RegistroSAuditables { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Agencia> Agencias { get; set; }
        public DbSet<Envio> Envios { get; set; }
        public DbSet<Comun> Comunes { get; set; }
        public DbSet<Urgente> Urgentes { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }

        public GestionDeEnviosContext(DbContextOptions opciones) : base(opciones)
        {

        }

    }
}
