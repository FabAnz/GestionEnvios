using CasosUso.DTOs;
using LogicaNegocio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Mappers
{
    internal class MapperEnvioACliente
    {
        internal static EnvioAClienteDTOs ToDTO(Envio envio)
        {
            EnvioAClienteDTOs aRetornar = null;

            if (envio != null)
            {
                aRetornar = new EnvioAClienteDTOs();
                aRetornar.NTracking = envio.NTracking;
                aRetornar.Vendedor = envio.Vendedor.Nombre + " " + envio.Vendedor.Apellido;
                aRetornar.Cliente = envio.Cliente.Nombre + " " + envio.Cliente.Apellido;
                aRetornar.Peso = envio.Peso;
                aRetornar.Estado = envio.Estado.ToString();
                aRetornar.FechaEnvio = envio.FechaEnvio;
                aRetornar.FechaEntrega = envio.FechaEntrega;
                aRetornar.Comentarios = MapperComentarioACliente.ToListDTO(envio.Comentarios);
                aRetornar.Direccion = envio is Comun ? "Agencia " + ((Comun)envio).Destino.Nombre : ((Urgente)envio).Direccion;
            }

            return aRetornar;
        }

        internal static List<EnvioAClienteDTOs> ToListDTO(List<Envio> lista)
        {

            return lista.Select(e => ToDTO(e)).ToList();
      
        }
    }
}
