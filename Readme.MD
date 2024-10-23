# Proyecto Cursos Online

Este proyecto consiste en una plataforma de cursos en línea que incluye un **backend** desarrollado en **ASP.NET Core API** y un **frontend** desarrollado en **Angular**. Los usuarios pueden inscribirse en cursos, seguir etapas y realizar lecciones interactivas.

## Características principales

- **Autenticación de usuarios** (login, registro) con soporte para inicio de sesión con Google.
- **Gestión de cursos**: Los administradores pueden crear cursos con múltiples etapas y lecciones.
- **Visualización de etapas**: Los usuarios pueden ver el contenido del curso estructurado en etapas.
- **Lecciones**: Cada etapa contiene lecciones con ejercicios y evaluaciones.

## Estructura del proyecto

El proyecto está dividido en dos principales aplicaciones:

### 1. **Backend: ASP.NET Core API**
   - **Ruta principal**: `ProyectoCursosAPI/`
   - Proporciona la API RESTful para gestionar cursos, etapas y lecciones.
   - Base de datos: **SQL Server**
   - **Autenticación**: Implementación con **JWT (JSON Web Tokens)**.
   
   **Rutas API principales**:
   - `/api/Cursos`: Gestión de cursos (crear, obtener, actualizar, eliminar).
   - `/api/Etapas`: Gestión de etapas de los cursos.
   - `/api/Lecciones`: Gestión de lecciones dentro de las etapas.

### 2. **Frontend: Angular**
   - **Ruta principal**: `proyectocursosfrontend/`
   - Proporciona la interfaz de usuario para que los usuarios interactúen con los cursos.
   - Diseño moderno usando **Tailwind CSS**.
   - **Router**: Manejo de navegación entre cursos, etapas y lecciones.

## Instalación

### Requisitos previos

- **Node.js**: Para el frontend de Angular.
- **.NET SDK**: Para ejecutar el backend en ASP.NET Core.
- **SQL Server**: Para la base de datos.

### Clonación del repositorio

Clona el repositorio con el siguiente comando:

```bash
git clone https://github.com/AndresFelipe23/CursosOnline.git
