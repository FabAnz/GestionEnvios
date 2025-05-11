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
            aRetornar.Cliente = new Usuario() { Id = dto.Cliente.Id };
            aRetornar.Peso = dto.Peso;
            if (dto.FechaEnvio != default(DateTime))
                aRetornar.FechaEnvio = dto.FechaEnvio;
            if (dto.FechaEntrega != default(DateTime))
                aRetornar.FechaEntrega = dto.FechaEntrega;
            if (dto.Comentarios != null)
                aRetornar.Comentarios = MapperComentario.ToListComentario(dto.Comentarios);

            return aRetornar;
        }

        internal static EnvioDTO ToDTO(Envio envio)
        {
            EnvioDTO aRetornar = null;

            if (envio != null)
            {
                aRetornar = new EnvioDTO();
                aRetornar.Id = envio.Id;
                aRetornar.NTracking = envio.NTracking;
                aRetornar.Vendedor = MapperUsuario.ToDTO(envio.Vendedor);
                aRetornar.Cliente = MapperUsuario.ToDTO(envio.Cliente);
                aRetornar.Peso = envio.Peso;
                aRetornar.Estado = Enum.GetName(envio.Estado);
                aRetornar.FechaEnvio = envio.FechaEnvio;
                aRetornar.FechaEntrega = envio.FechaEntrega;
                aRetornar.Comentarios = MapperComentario.ToListDTO(envio.Comentarios);

                if (envio is Comun)
                {
                    aRetornar.Agencia = MapperAgencia.ToDTO(((Comun)envio).Destino);
                }
                else
                {
                    aRetornar.Direccion = ((Urgente)envio).Direccion;
                    aRetornar.EntregaEficiente = ((Urgente)envio).EntregaEficiente;
                }
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
