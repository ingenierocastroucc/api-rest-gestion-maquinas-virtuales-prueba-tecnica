# 🖥️ API de Gestión de Máquinas Virtuales (.NET Core)

Este proyecto es una API RESTful desarrollada con **.NET Core** como parte de una prueba técnica de backend. Permite la **gestión de máquinas virtuales (VMs)**, integrando autenticación JWT, control de roles (Administrador/Cliente) y, opcionalmente, funcionalidades en tiempo real.

---

## 🚀 Tecnologías Utilizadas

- [.NET 7/8](https://dotnet.microsoft.com/)
- Entity Framework Core
- JWT (JSON Web Tokens)
- SignalR (para real-time, opcional)
- Swagger (Documentación interactiva)
- SQL Server o SQLite

---

## 🔐 Autenticación y Roles

Se utiliza JWT para autenticar usuarios. El token incluye el rol del usuario para autorizar accesos a los distintos endpoints.

### Roles

- 🛠️ **Administrador**: Acceso total (crear, editar, eliminar y visualizar VMs).
- 👤 **Cliente**: Solo puede visualizar VMs.

---

## 📚 Endpoints Disponibles

| Método | Endpoint        | Descripción                                     | Rol requerido     |
|--------|------------------|-------------------------------------------------|-------------------|
| POST   | `/login`         | Autenticación. Retorna JWT.                    | Público            |
| POST   | `/vms`           | Crear nueva VM                                 | Administrador      |
| GET    | `/vms`           | Obtener todas las VMs                          | Admin / Cliente    |
| GET    | `/vms/{id}`      | Obtener VM por ID                              | Admin / Cliente    |
| PUT    | `/vms/{id}`      | Actualizar detalles de una VM                  | Administrador      |
| DELETE | `/vms/{id}`      | Eliminar VM por ID                             | Administrador      |

---

## 🧪 Validación de Roles y Seguridad

- Middleware de autorización basado en roles.
- Respuestas estándar:
  - `401 Unauthorized`: Token inválido o no presente.
  - `403 Forbidden`: Rol sin permisos para el recurso solicitado.

---

## ⚡ Real-Time (Plus Opcional)

Utilizando **SignalR** para enviar notificaciones a los clientes cada vez que una VM es creada, actualizada o eliminada. Esto permite mantener sincronizadas las interfaces sin necesidad de recarga manual.

---

## 💻 Frontend Recomendado

Puedes desarrollar el frontend usando:

- Angular
- React
- Blazor
- ASP.NET MVC o Razor Pages

### Funcionalidades clave

- Formulario de login con `email` y `password`.
- Crear/Editar/Eliminar VM (solo visible para Administradores).
- Lista de VMs con datos actualizados en tiempo real.
- Protección de vistas según el rol obtenido del JWT.

---

## ▶️ Cómo Ejecutar el Proyecto

### 1. Clonar el repositorio

```bash
git clone https://github.com/ingenierocastroucc/api-rest-gestion-maquinas-virtuales-prueba-tecnica.git
cd api-rest-gestion-maquinas-virtuales
```

### 2. Configurar la base de datos

Edita el archivo `appsettings.json` con la cadena de conexión a tu base de datos.  
A continuación se muestra un ejemplo para **SQL Server**:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=VMManagerDB;Trusted_Connection=True;"
  },
  "Jwt": {
    "Key": "ClaveSuperSecreta123456!",
    "Issuer": "TuApp",
    "Audience": "TuAppUsuarios",
    "ExpireMinutes": 60
  }
}
```

### 3. Ejecutar migraciones

Aplica las migraciones iniciales para crear la base de datos utilizando Entity Framework Core.

Si aún no has creado una migración, primero ejecuta:

```bash
dotnet ef migrations add InitialCreate
```

### 4. Ejecutar el proyecto

Una vez configurada la base de datos y aplicadas las migraciones, puedes iniciar la API con el siguiente comando:

```bash
dotnet run
```

### 5. Acceder a la documentación Swagger

Abre tu navegador y accede a la siguiente URL para explorar y probar la API desde Swagger UI:

https://localhost:{puerto}/swagger

## 📁 Estructura del Proyecto

La siguiente es una estructura recomendada para organizar tu API RESTful en .NET Core:

- `/Controllers` → Controladores de la API (manejan las rutas y peticiones HTTP)
- `/Models` → Modelos de datos o entidades utilizadas por Entity Framework
- `/DTOs` → Objetos de Transferencia de Datos usados para entrada/salida segura
- `/Services` → Lógica de negocio desacoplada de los controladores
- `/Middleware` → Middleware personalizados (por ejemplo: validación de roles, manejo de errores)
- `/Data` → Configuración del DbContext y acceso a la base de datos (EF Core)
- `/Hubs` → Hubs para comunicación en tiempo real vía WebSockets (opcional)


### 6. Crear la base de datos y ejecutar los scripts

Para la ejecución correcta del proyecto, debes crear una base de datos llamada **VMManagerDB** en tu servidor de SQL Server. Luego, ejecuta los archivos de tablas y semillas para configurar la estructura y los datos iniciales.

Asegúrate de tener los archivos de **tablas** y **semillas** listos y ejecútalos en la base de datos **VMManagerDB**.

## 📝 Ejemplos de Solicitudes y Respuestas JSON

### **POST** `/api/auth/login`

**Body:**

```json
{
  "email": "admin@example.com",
  "password": "Admin123*"
}
```

**Respuesta (200 OK):**

```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```

### **GET** `/api/virtualmachine/`

**Respuesta (200 OK):**

```json
[
  {
    "id": 2,
    "name": "VM-Ubuntu",
    "os": "Ubuntu 22.04",
    "ram": 4096,
    "cpu": 2,
    "disk": 50,
    "status": 0,
    "createdAt": "2025-05-05T17:12:17.317",
    "updatedAt": "2025-05-05T17:12:17.317",
    "userId": 0,
    "user": null
  }
]
```

### **GET** `/api/virtualmachine/{id}`

**Respuesta (200 OK):**

```json
{
  "id": 2,
  "name": "VM-Ubuntu",
  "os": "Ubuntu 22.04",
  "ram": 4096,
  "cpu": 2,
  "disk": 50,
  "status": 0,
  "createdAt": "2025-05-05T17:12:17.317",
  "updatedAt": "2025-05-05T17:12:17.317",
  "userId": 0,
  "user": null
}
```

### **POST** `/api/virtualmachine/`

**Body:**

```json
{
  "name": "VM-NewServer",
  "os": "Ubuntu 20.04",
  "ram": 1024,
  "cpu": 4,
  "disk": 200,
  "status": "Running",
  "userId": 1
}
```

**Respuesta (201 Created):**

```json
{
  "id": 5,
  "name": "VM-NewServer",
  "os": "Ubuntu 20.04",
  "ram": 1024,
  "cpu": 4,
  "disk": 200,
  "status": 1,
  "createdAt": "2025-05-06T02:34:03.0943496Z",
  "updatedAt": "2025-05-06T02:34:03.0944103Z",
  "userId": 0,
  "user": null
}
```

### **PUT** `/api/virtualmachine/{id}`

**Body:**

```json
{
  "id": 2,
  "name": "VM-NewServer-Updated",
  "os": "Ubuntu 22.04",
  "ram": 600,
  "cpu": 8,
  "disk": 500,
  "status": 1,
  "createdAt": "2025-05-05T17:12:17.317",
  "updatedAt": "2025-05-06T02:34:31.3741428Z",
  "userId": 0,
  "user": null
}
```

### **DELETE** `/api/virtualmachine/{id}`

**Respuesta (204 No Content):**

```json
{}
```

## 📬 Contacto

Para más información, dudas o soporte sobre el desarrollo del proyecto:

📧 [ingenierocastroucc@gmail.com](mailto:ingenierocastroucc@gmail.com)

## ⚖️ Licencia

Este proyecto se proporciona únicamente con fines educativos, de evaluación o uso personal.

**No se permite su uso con fines comerciales sin autorización previa.**

El autor se reserva todos los derechos relacionados con la distribución o reutilización de este código en contextos comerciales.

Si deseas utilizar este código con fines distintos a los expresamente autorizados, por favor contacta al autor.

