﻿using CasosUso.DTOs;
using CasosUso.InterfacesCasosUso;
using ExcepcionesPropias.Excepciones;
using LogicaAplicacion.Mappers;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class ModificarUsuario : AccionAuditable, IModificarUsuario
    {
        public IRepositorioUsuario RepoUsuario { get; set; }

        public ModificarUsuario(
            IRepositorioUsuario repoUsuario,
            IRepositorioRegistroAuditable repoRegistro
            ) : base(repoUsuario, repoRegistro)
        {
            RepoUsuario = repoUsuario;
        }

        public void Modificar(UsuarioConContraseniaDTO dto, UsuarioDTO usuarioActivoDto)
        {
            if (dto == null)
                throw new DatosInvalidosException("Usuario vacio, intente nuevamente");
            Usuario usuario = MapperUsuarioConContrasenia.ToUsuario(dto);

            usuario.Validar();
            RepoUsuario.Update(usuario);

            GenerarRegistro("Modificación de usuario", usuarioActivoDto, dto.Email);
        }
    }
}
