# API RESTful de Creación de Usuarios

Esta es una aplicación que expone una API RESTful para la creación de usuarios. La API permite registrar nuevos usuarios con campos como nombre, correo electrónico, contraseña y números de teléfono.

## Requisitos

- .NET 8
- sqlite3

## Instalación

1. Clona este repositorio en tu máquina local:

```bash
git clone https://github.com/xoenalejandro/pruebaAlmapac.git
```

2. Abre el proyecto en tu entorno de desarrollo preferido (Visual Studio 2022 o Visual Studio Code).

3. Restaura los paquetes NuGet:

```bash
dotnet restore
```

4. Con el script BD puedes crear la base de datos y las tablas, o bien puedes hacer uso del archivo Registro.sqlite.

5. Configura la base de datos según sea necesario en el archivo appsettings.json para la ubicación.

6. Ejecuta la aplicación:

La API estará disponible en https://localhost:5001 por defecto.

## Uso

### Registro de Usuario

Envía una solicitud POST a este endpoint con un cuerpo JSON que contenga los datos del usuario a registrar, incluyendo nombre, correo electrónico, contraseña y números de teléfono.

Ejemplo de cuerpo de solicitud:

```json
{
  "name": "Juan Rodriguez",
  "email": "juan@rodriguez.org",
  "password": "hunter2",
  "phones": [
    {
      "number": "1234567",
      "citycode": "1",
      "countrycode": "57"
    }
  ]
}
```

La API responderá con el usuario registrado junto con un token de acceso y otros campos adicionales como `id`, `created`, `modified`, `last_login` y `isactive`.

### Formato de Respuesta

Todos los mensajes de la API siguen el formato JSON:

```json
{
  "mensaje": "mensaje de error"
}
```

### Manejo de Errores

En caso de error, la API responderá con el código de estado HTTP adecuado y un mensaje de error en formato JSON.

## Contribuir

Si encuentras algún error o tienes alguna sugerencia para mejorar esta aplicación, por favor abre un issue o envía un pull request. ¡Todas las contribuciones son bienvenidas!

## Licencia

Este proyecto está bajo la licencia MIT.

