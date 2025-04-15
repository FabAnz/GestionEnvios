using CasosUso.DTOs;
using LogicaNegocio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Mappers
{
    internal class MapperEnvio
    {
        internal static Envio ToEnvio(EnvioDTO dto)
        {
            Envio aRetornar = null;

            if (dto.Agencia.Id == 0)
            {
                aRetornar = new Urgente();
                ((Urgente)aRetornar).Direccion = dto.Direccion;
            }
            else
            {
                aRetornar = new Comun();
                ((Comun)aRetornar).Destino = new Agencia() { Id = dto.Agencia.Id };
            }
            aRetornar.Id = dto.Id;
            aRetornar.NTracking = dto.NTracking;
            aRetornar.Vendedor = new Usuario() { Id = dto.Vendedor.Id };
            aRetornar.EmailCliente = dto.EmailCliente;
            aRetornar.Peso = dto.Peso;
            if (dto.FechaEnvio != default(DateTime))
                aRetornar.FechaEnvio = dto.FechaEnvio;
            if (dto.FechaEntrega != default(DateTime))
                aRetornar.FechaEntrega = dto.FechaEntrega;

            return aRetornar;
        }

        internal static EnvioDTO ToDTO(Envio envio)
        {
            EnvioDTO aRetornar = new EnvioDTO();

            aRetornar.Id = envio.Id;
            aRetornar.NTracking = envio.NTracking;
            aRetornar.Vendedor = MapperUsuario.ToDTO(envio.Vendedor);
            aRetornar.EmailCliente = envio.EmailCliente;
            aRetornar.Peso = envio.Peso;
            aRetornar.Estado = Enum.GetName(envio.Estado);
            aRetornar.FechaEnvio = envio.FechaEnvio;
            aRetornar.FechaEntrega = envio.FechaEntrega;

            if (envio is Comun)
            {
                aRetornar.Agencia = MapperAgencia.ToDTO(((Comun)envio).Destino);
            }
            else
            {
                aRetornar.Direccion = ((Urgente)envio).Direccion;
                aRetornar.EntregaEficiente = ((Urgente)envio).EntregaEficiente;
            }

            return aRetornar;
        }

        internal static List<EnvioDTO> ToListDTO(List<Envio> lista)
        {
            List<EnvioDTO> aRetornar = new List<EnvioDTO>();

            foreach (Envio envio in lista)
            {
                aRetornar.Add(ToDTO(envio));
            }

            return aRetornar;
        }
    }
}
