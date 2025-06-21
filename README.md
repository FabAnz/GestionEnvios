# Gestión de Envíos

**Gestión de Envíos** es un sistema web desarrollado en .NET que permite gestionar el envío de paquetes entre usuarios con diferentes roles: cliente, vendedor y administrador. La aplicación cuenta con una API protegida por JWT, persistencia mediante Entity Framework Core y una interfaz MVC para clientes.

## Funcionalidades principales

- 🔐 Autenticación con JWT y control de roles
- 📦 Registro y gestión de envíos (comunes y urgentes)
- 📍 Asociación de envíos a agencias o direcciones
- 📝 Seguimiento de envíos mediante comentarios
- 🔍 Filtros por fecha, estado y contenido del comentario
- 👤 Gestión de usuarios y cambio de contraseña
- 🗃️ Registro de acciones auditables

## Tecnologías utilizadas

- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- JWT para autenticación
- Bootstrap 5 para el frontend
- Swagger para documentación de API

## Arquitectura

El proyecto sigue una arquitectura en capas:
- **Presentación** (WebCliente / API REST)
- **Aplicación** (Casos de uso)
- **Dominio** (Entidades y lógica de negocio)
- **Datos** (EF Core + Repositorios)

## Ejecución

1. Configurar la conexión a la base de datos en `appsettings.json`.
2. Ejecutar migraciones con `Update-Database`.
3. Ejecutar el proyecto: el frontend MVC se conecta a la API REST autenticada.

## Requisitos

- Visual Studio 2022 o superior
- .NET SDK 8.0
- SQL Server o SQL Express

---

