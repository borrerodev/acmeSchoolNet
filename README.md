# ACME School

_Proyecto desarrollado en tecnologia .Net Core 9 , implementando arquitecura Limpia(Clean Arquitecture) para separacion de logica de negocio y para este caso en particular de la infrastructura, se impl,ento una base de datos Sql Lite para desarrollo que a futuro con las ventajas del Entity Framework se puede enlazar con otras base de datos como SQL, Orale, MySql, etc_

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


##English version
# ACME School

Project developed in .Net Core 9 technology, implementing Clean Architecture for separation of business logic and for this particular case of the infrastructure, we implemented a Sql Lite database for development that in the future with the advantages of the Entity Framework can be linked with other databases such as SQL, Oracle, MySQL, etc_.

- School.Api: In this project we have the Controllers, the dependencies containers, we execute the migrations from this project and it contains the local Sqlite database that is loaded when starting the project with test data.
- School.Application: We have the CQRS management, in our case we divide it by entity and create the commands and queries, we have the validations in which we use FLuentValidation, the Dto for data transfer.
- School.Infrastructure: We have the topic of persistence with the context, we store the migration history, model configurations.
- School.Domain: In this project we have the entities, declaration of interfaces and the handling of UnitOfWork to handle the transaction.
  
## Getting started 🚀

Download the application and run the School.Api project.
Enter url : http://localhost:5000/swagger


- Register student: (POST) http://localhost:5000/api/Student
- Register Course: (POST) http://localhost:5000/api/Course
- List courses with their students in date range: (GET) http://localhost:5000/api/Course/startDate=2021-01-01&endDate=2021-12-31
- Enroll student to course: (PUT) http://localhost:5000/api/Course/enrollStudent

### Prerequisites 📋

_.Net Core in version 9.0_preview6_.

## Running the tests ⚙️

From the browser you can run the endpoints or there is a file in src/School.Api/School.Api.http having previously installed the REST Client_ extension.

### Analyze the end-to-end tests 🔩

You can run the unit tests in the School.UnitTest project _




## Libraries or Nugets used 🛠️

_The following libraries were used _.

* [Microsoft.EntityFrameworkCore.Design]) - Migration 
* [FluentValidation.AspNetCore] - Validations in particular the contrl in the request for over 18s
* [MediatR] - CQRS Management
* Microsoft.Data.Sqlite] - Library for Sqlite Database
* EFCore.NamingConventions] - Snake case conventions handling, important for future implementation of a database like Postgres which is keysensitive, basically what it does is to convert the columns to snake conventions (courseId-> course_id).
* Xunit] - Unit Tests
* [Moq] - Mock entities for unit tests



### Questions/answers 📋
- What I would like to do but I didn't do? - Implement more test cases, validate more requests with fluent validators for different cases (Nulls, text length) and implement events for notifications, additionally add attentivation and authorization.
- What things did I do but I think it could be improved or would be necessary if implemented? - If implemented it would be necessary the security issue for endpoint consimo.
- Third party libraries - Of the most important MediatR for CQRS management which gives us an advantage in a distributed environment allowing us to have the commands (Insert, update, delete) to a DB and the Query (Queries) which is lighter on the subject of transactions in another DB reading, XUnit for testing issues and fluentvalidation to validate the age that allows us to control the requests.
- This project started from scratch, we investigated the implementation of Clean architecture and it took about 1 week with 1h daily work, we investigated the unit tests specifically for CQRS, I received new concepts that I could understand more as the implementation of CQRS, the pattern Unit of Work and the implementation of interfaces for more abstract development.
## Author ✒️

** **Jorge Borrero** - *borrerodev* - [borrerodev](https://linkedin.com/in/jborrero)
