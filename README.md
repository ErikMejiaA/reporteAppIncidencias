# reporteAppIncidencias
Creación de la base de datos para llevar el registro de incidencias de las equipos de computo de CampusLands, creación de entidades y migraciones, interfaces y repositorios y endpoint y peticiones HTTP, creación de CRUD y muchas cosas mas, echas en Csharp C# y einplementando la nueva Arquitectura Dominio y Entity Framework API .net 7.0


Enunciado Ejercicio practica ha Desarrollar

El centro de apoyo tecnológico de Campus Lands la ha contratado para construir una aplicación que permita llevar la gestión de incidencias técnicas en cada una de las salas de Entrenamiento y Review.

El líder de IT desea que cada Trainner pueda reportar las incidencias ocurridas.

El departamento de IT ha clasificado las incidencias en las siguientes categorías:

Hardware y Software

Cada Trainner debe ingresar la siguiente información al momento de reportar la incidencia:

Categoría, tipo de incidencia descripción, fecha reporte, Área de incidencia y lugar de la incidencia.

Campus Lands cuenta con 4 areas generales en las culés se encuentran los equipos tecnológicos de uso diario de los campers y Trainners 

Las areas son las siguientes:
* Área Training (Apolo, Artemis, Sptnik y Skylab)
* Área Review 1 (Corvus)
* Área Review 2 (Endor)

Las incidencias se pueden categorizar en: Leve, Moderada y Critica.

El sistema debe permitir asignar Computadores, Teclados, Mouse, Diademas de sonido en cada uno de los salones.

El sistema debe permitir crear Trainner (id, nombre, Email personal, Email Corporativo, Teléfono Móvil, Teléfono Residencia, Teléfono Empresa, Teléfono Móvil Empresarial). 

guia base para el registro de un Usuario:

{
  "email": "tomas@gmail.com",
  "username": "Tomas",
  "password": "123456"
}

Se realizo la creacion de entidades para la representacion de las tablas de la base de datos, sus respectivas configuraciones en donde sie le asignaban las propiedades de los atributos para cada entidad, se creo las interfaces y los repositrios, Dtos, Controladores y la unidad de trabajo (interfaz y repositorio). ademas se creo el archivo para el versionado de los Endpoint, tambien se realizo la paginacion a los registros que se crean en cada interfaz, de igual forma se creo un nuero maximo de peticiones o solicitud a realizar a los Enbpoint. adicionalmente se el JWT (Json web token) que permite enviar informacion segura de una aplicaciona otra, para este caso se implemento para poder tener la autorizacion de quien puede realizar o enviar una solicitud a una determinada url, asi como tambien asignar a un determinado rol una autorizacion por medio de un token. 

{
  "email": "oscar@gmail.com",
  "username": "Oscar",
  "password": "123"
}
{
  "email": "carlos@gmail.com",
  "username": "Carlos",
  "password": "1234"
}
{
  "email": "luisa@gmail.com",
  "username": "Luisa",
  "password": "12345"
}
{
  "email": "maria@gmail.com",
  "username": "Maria",
  "password": "123456"
}
{
  "email": "erik@gmail.com",
  "username": "Erik",
  "password": "1234567"
}
