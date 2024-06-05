API RESTful de Creación de Usuarios
Esta es una aplicación que expone una API RESTful para la creación de usuarios. La API permite registrar nuevos usuarios con campos como nombre, correo electrónico, contraseña y números de teléfono.

Requisitos 
.NET 8 
sqlite3

Instalación
Clona este repositorio en tu máquina local:
git clone https://github.com/tu_usuario/api-restful-usuarios.git

Abre el proyecto en tu entorno de desarrollo preferido (Visual Studio 2022 o Visual Studio Code).



Restaura los paquetes NuGet:
dotnet restore

con el scrip BD puede crear la base de datos y las tablas o bien puede hacer uso del archivo Registro.sqlite 

Configura la base de datos según sea necesario en el archivo appsettings.json para la ubicacion


Ejecuta la aplicación:

La API estará disponible en https://localhost:5001 por defecto.


Ejemplo de cuerpo de solicitud:

json
Copiar código
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
La API responderá con el usuario registrado junto con un token de acceso y otros campos adicionales como id, created, modified, last_login y isactive.

Formato de Respuesta
Todos los mensajes de la API siguen el formato JSON:

json
Copiar código
{
  "mensaje": "mensaje de error"
}
Manejo de Errores
En caso de error, la API responderá con el código de estado HTTP adecuado y un mensaje de error en formato JSON.

Contribuir
Si encuentras algún error o tienes alguna sugerencia para mejorar esta aplicación, por favor abre un issue o envía un pull request. ¡Todas las contribuciones son bienvenidas!

Licencia
Este proyecto está bajo la licencia MIT.
