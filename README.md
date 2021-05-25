# Altioracorp Solution - Backend
Esta solución contiene los APIs necesarios para gestionar Clientes, Productos y Órdenes de Clientes.

### Antes de empezar
Es importante mencionar que este proyecto funciona conjuntamente con un frontend, por lo que no podrás probarlo sin haber descargado y ejecutado el proyecto ***altioracorp-frontend***. [Ir a Descargar](https://github.com/eddavidva/altioracorp-frontend)

### Empecemos
Estas instrucciones te permitirán descargar una copia de la solución y ejecutarla en un ambiente de desarrollo.

### Estructura
* __AltioracorpDataAccess:__ Proyecto con la lógica para el acceso a la información de la base de datos.
* __AltioracorpWebApi:__ Proyecto con el contenido para la publicación de las APIs.

### Instalación
##### General
1. Descarga o clona el proyecto .
2. Abre el proyecto descargado en Visual Studio.

##### Base de Datos
1. Navega hacia  ___App_Data/DB___ que está dentro del Proyecto AltioracorpWebApi.
2. Copia el script  del archivo ___AltioracorpDB.sql___
1. Abre SQL Server Management Studio.
2. Ejecuta el script copiado.

##### Proyectos
1. Abre el archivo ___Web.config___ q se encuentra dentro del Proyecto AltioracorpWebApi.
2. Cambia el ___Data Source___ del ___connectionString___ por el nombre de tu servidor de SQL Server. De ser el caso modifica el ___connectionString___ con las credenciales de tu usuario para acceder a la base de datos.
`<connectionStrings>
    <add name="AltioracorpContext" connectionString="Data Source=EC-NBO0511\SQLEXP2008;Initial Catalog=AltioracorpDB;Integrated Security=True" providerName="System.Data.SqlClient" />
  </connectionStrings>`
3. Ejecuta la solución.

### Herramientas
* [EntityFramework](https://docs.microsoft.com/en-us/ef/)
* [AutoMapper](https://automapper.org/)
* [Cors](https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-5.0)
* [OWIN](https://docs.microsoft.com/en-us/aspnet/aspnet/overview/owin-and-katana/getting-started-with-owin-and-katana)

### Autor
* Edison David Valdivieso Arias


