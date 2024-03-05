# Dapper CRUD Application

This is a CRUD (Create, Read, Update, Delete) application built using Dapper ORM in ASP.NET Core. The application consists of the following projects:

## Projects

1. **DapperCRUDFinal**: This is the main solution folder.
2. **BusinessLayer**: Contains business logic and interfaces.
3. **DapperCRUD**: ASP.NET Core web application project.
4. **ModelLayer**: Contains DTOs (Data Transfer Objects) used for communication between layers.
5. **RepositoryLayer**: Contains data access logic.

## Setup Instructions

To run the application locally, follow these steps:

1. Clone the repository to your local machine.
2. Open the solution file (`DapperCRUDFinal.sln`) in Visual Studio or your preferred IDE.
3. Make sure you have a compatible SQL Server instance running.
4. Update the connection string in the `appsettings.json` file of the `DapperCRUD` project to point to your SQL Server database.
5. Build and run the solution.

## Usage

Once the application is running, you can use it to perform CRUD operations on the `Companies` and `Employees` tables in your SQL Server database.

## Dependencies

The application relies on the following dependencies:

- ASP.NET Core
- Dapper
- SQL Server

## Contributing

Contributions are welcome! If you find any issues or have suggestions for improvements, please open an issue or submit a pull request.
