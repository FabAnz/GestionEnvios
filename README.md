# Sistema de Gestión de Envíos

Este proyecto consiste en el desarrollo de un sistema de gestión interna y de comunicación con los clientes para una empresa dedicada a la logística de envíos de paquetes, que operará en todo el territorio nacional. Se hace especial énfasis en la trazabilidad de cada envío y en mantener una buena comunicación con los clientes.

## Funcionalidades

### Gestión de Agencias
Registro de agencias con información de:
- Nombre
- Dirección postal
- Ubicación (coordenadas de latitud y longitud)

### Usuarios y Roles
Registro de usuarios con sus datos personales, email, contraseña y rol asignado. Los roles pueden ser:
- **Administrador** (empleado de la empresa)
- **Funcionario** (empleado de la empresa)
- **Cliente**

### Gestión de Envíos
Cada envío se identifica por:
- Un id y un número de tracking
- Empleado que toma el pedido
- Cliente que realiza el envío
- Peso del paquete
- Estado, que puede ser **EN_PROCESO** o **FINALIZADO**

Además, se manejan dos tipos de envíos:
- **Envío Común:**
  - Se entrega en una agencia para ser retirado en persona.
  - Al recibir el paquete, el empleado cambia el estado del envío a FINALIZADO (sin operaciones adicionales).

- **Envío Urgente:**
  - Se envía a una dirección postal específica.
  - Incluye un valor que indica si la entrega fue realizada de forma eficiente (entregada en menos de 24 horas desde su salida).
  - Al recibir el paquete, el cambio de estado a FINALIZADO genera el cálculo de la eficiencia del envío.

### Seguimiento de Envíos
Cada envío posee etapas de seguimiento que permiten conocer el recorrido del paquete desde la agencia de origen hasta la entrega final.  
Los empleados pueden ingresar comentarios junto con la fecha y su identificación. Algunos ejemplos de comentarios son:
- "Ingresado en agencia de origen"
- "En camino"
- "Listo para retirar"

Los comentarios quedan a criterio del empleado.

