# ACME School

_Proyecto desarrollado en tecnologia .Net Core 9 , implementando arquitecura Limpia(Clean Code) para separacion de logica de negocio y para este caso en particular de la infrastructura, se impl,ento una base de datos Sql Lite para desarrollo que a futuro con las ventajas del Entity Framework se puede enlazar con otras base de datos como SQL, Orale, MySql, etc_

- School.Api: En este proyecto tenemos los Controladores, los contenedores de dependncias, ejecutamos las migraciones desde este proyecto y contiene la base de datops local Sqlite que se carga al iniciar el proyecto con datos de pruebas.
- School.Application: Tenemos el manejo de CQRS, paqra nuestro caso lo dividimos por entidad y creamos los command y los query, tenemos lalidaciones en la que usamos FLuentValidation, los Dto para traferencia de datos.
- School.Infrastructure: Tenemos el tema de persistencia con el contexto, se almacena el historico de migraciones, configuraciones de los modelos
- School.Domain: Es este proyecto tenemos las entidades, declaracion de interfaces y el manejo de UnitOfWork para manejar la transaccion
  
## Comenzando 🚀

_Descargue la aplicacion y ejecute el proyecto School.Api._
Ingrese a la url : http://localhost:5000/swagger

- Registrar estudiante:  (POST) http://localhost:5000/api/Student
- Registrar Curso:  (POST) http://localhost:5000/api/Course
- Listado de cursos con sus estrudiantes en rango de fechas: (GET) http://localhost:5000/api/Course/startDate=2021-01-01&endDate=2021-12-31
- Enrolar estudiante a curso: (PUT) http://localhost:5000/api/Course/enrollStudent

### Pre-requisitos 📋

_.Net Core en la version 9.0_preview6_

## Ejecutando las pruebas ⚙️

_Desde e explorador puede ejecutar los endpoint o existe un archivo en src/School.Api/School.Api.http teniendo previamente instalado la extension de REST Client_

### Analice las pruebas end-to-end 🔩

_Puede ejecutar las pruebas unitarias en el proyecto School.UnitTest _




## Librerias o Nugets usados 🛠️

_Se usaron las siguientes librerias _

* [Microsoft.EntityFrameworkCore.Design]) - Migracion 
* [FluentValidation.AspNetCore] - Validaciones en particular el contrl en el request para mayores de 18 años
* [MediatR] - Manejo de CQRS
* [Microsoft.Data.Sqlite] - Libreria para Base de datos Sqlite
* [EFCore.NamingConventions] - Manejo de convenciones Snake case, importante para si a futuro se implementa una BD como Postgres que es keysensitive, basicamente lo que hace es convertir la columnas a convension snake (courseId-> course_id)
* [Xunit] - Pruebas unitarias
* [Moq] - Mockear entidades para las pruebas unitrias


### Preguntas/respuestas 📋
- Que me gustaria hacer pero no hice? - Implementar mas casos de pruebas, validar mas los request con fluent validators para diferentes casos (Nulls, longitud de textos) e implementar los eventos para notioficaciones, adicionalmente agregarle attenticacion y autorizacion
- Qué cosas hice pero creo que podría mejorarse o sería necesario si se implementara? - Si se implementara seria necesario el tema de seguridad para consimo de los endpoint.
- Bibliotecas de tercero - De las mas imporantes MediatR opara manejo de CQRS  la cual nos brinda ventaja en un ambiente distribuido permitiendo tener los comman (Insert, update, delete) hacia una BD y los Query(Consultas) que es mas liviano el tema de transacciones en otra BD de lectura, XUnit para temas de pruebas y fluentvalidation para validar la edad que nos permite controlar los request.
- Este proyecto se inicio desde cero , se investigo la implementacion de Clean architecture y tomo aprox 1 semana con trabajo de 1h diaria, se investigo las pruebas unitarias especificamente para CQRS, recibi nuevos conceptos que pude entender mas como la implemntacion de CQRS, el patron Unit of Work y la implementacion de interfaces para desarrollo mas abstracto.
## Autor ✒️

* **Jorge Borrero** - *borrerodev* - [borrerodev](https://linkedin.com/in/jborrero)
