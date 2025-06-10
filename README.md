# GestionDeEnvios

Proyecto de gestión de envíos desarrollado en **ASP.NET Core Web API** como parte del curso de Programación 3 (ORT).

## Descripción

La aplicación permite gestionar el flujo de envíos de paquetes entre agencias, clientes y vendedores.  
Proporciona endpoints para el manejo de usuarios, envíos y comentarios, con autenticación mediante **JWT** y roles.

## Tecnologías

- **ASP.NET Core 8** (Web API)
- **Entity Framework Core 8**
- **SQL Server**
- **JWT** (Json Web Tokens) para autenticación
- **Swagger** para documentación de la API

## Estructura del proyecto

- `/AccesoDatos` → Repositorios y contexto EF (`GestionDeEnviosContext`)
- `/CasosUso` → Casos de uso y DTOs
- `/LogicaNegocio` → Entidades de dominio, ValueObjects
- `/ExcepcionesPropias` → Excepciones personalizadas
- `/API` → Controllers y configuración de la API

## Principales funcionalidades

- Registro y autenticación de usuarios (JWT)
- Gestión de envíos (`Envio`, `Comun`, `Urgente`)
- Filtros avanzados de envíos (fecha, estado, comentarios)
- Gestión de agencias
- Registro de comentarios en envíos
- Auditoría de acciones de usuarios (`RegistroAuditable`)
- Roles de usuario: Cliente, Vendedor, etc.


## API endpoints principales

- `POST /api/Usuarios` → Login
- `PUT /api/Usuarios` → Modificar contraseña
- `GET /api/Envios` → Filtrar envíos
- `GET /api/Envios/{nTracking}` → Detalle de envío

## Autenticación

- El login retorna un JWT que debe ser usado en las llamadas protegidas.
- Ejemplo en Swagger: usar `Bearer <token>` en la autorización.

## Autor

- [FabAnz](https://github.com/FabAnz)

## Licencia

Este proyecto es de uso académico.

