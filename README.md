# ACME School

_Proyecto desarrollado en tecnologia .Net Core 9 , implementando arquitecura Limpia(Clean Code) para separacion de logica de negocio y para este caso en particular de la infrastructura, se impl,ento una base de datos Sql Lite para desarrollo que a futuro con las ventajas del Entity Framework se puede enlazar con otras base de datos como SQL, Orale, MySql, etc_

## Comenzando 🚀

_Descargue la aplicacion y ejecute el proyecto School.Api._
Ingrese a la url : http://localhost:5000/swagger



### Pre-requisitos 📋

_.Net Core en la version 9.0_preview6




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




## Autor ✒️

* **Jorge Borrero** - *borrerodev* - [borrerodev](https://linkedin.com/in/jborrero)
