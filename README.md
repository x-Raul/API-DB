# API-DB

Se crea el proyecto
Se instalan las dependencias 
  Microsoft.EntityFrameworkCore.Tools
  Microsoft.EntityFrameworkCore.SqlServer

https://learn.microsoft.com/en-us/ef/core/cli/powershell
En la consola del Packahe manager ingreso al proyecto 
  dir
  cd ./API-DB
Importo la base de datos
//Scaffold-DbContext "Server=(localdb)\mssqllocaldb;Database=ProductosDB;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
