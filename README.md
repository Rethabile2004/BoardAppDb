
# BoardAppDb

A database-backed ASP.NET Core MVC application for managing microcontroller development boards. The project demonstrates CRUD operations using Entity Framework Core, SQL Server, MVC, and the Repository Pattern.

## Overview

BoardAppDb extends the basic BoardApp application by introducing persistent database storage and a repository-based data access layer.

The application allows users to view, create, edit, view details, and delete microcontroller development boards.

Each board contains:

- Board code
- Manufacturer
- Model
- Flash memory size
- Price

## Technologies

![.NET](https://img.shields.io/badge/.NET-10-512BD4?style=flat&logo=dotnet&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-MVC-512BD4?style=flat&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=csharp&logoColor=white)
![Entity Framework Core](https://img.shields.io/badge/Entity%20Framework%20Core-8.0-512BD4?style=flat&logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=flat&logo=microsoftsqlserver&logoColor=white)

## Features

- View all boards
- View board details
- Add new boards
- Edit existing boards
- Delete boards
- Model validation using Data Annotations
- Entity Framework Core database integration
- SQL Server persistence
- Repository Pattern for data access
- Dependency Injection
- Automatic database creation
- Initial database seeding

## Architecture

The application follows an ASP.NET Core MVC architecture with a repository-based data access layer.

```text
Browser
   ↓
BoardController
   ↓
IBoard
   ↓
BoardRepo
   ↓
BoardContext
   ↓
SQL Server
````

## Data Model

The `Board` entity contains the following properties:

| Property  | Description                       |
| --------- | --------------------------------- |
| BoardCode | Unique four-character board code  |
| Make      | Board manufacturer                |
| Model     | Board model                       |
| FlashKb   | Flash memory size in KB           |
| Price     | Board price in South African Rand |

Validation rules are applied using Data Annotations, including required fields, board code length, and price range validation.

## Database Seeding

When the application starts, the database initializer creates the database if required and inserts an initial collection of microcontroller boards when no records exist.

The seed data includes boards from manufacturers such as Espressif, STMicroelectronics, Microchip, WCH, and Raspberry Pi.

## Project Structure

```text
BoardAppDB
│
├── Controllers
│   └── BoardController.cs
│
├── Data
│   └── BoardContext.cs
│
├── Infrastructure
│   └── Custom validation
│
├── Interfaces
│   ├── IBoard.cs
│   └── IDBInitializer.cs
│
├── Models
│   ├── Board.cs
│   └── ErrorViewModel.cs
│
├── Repositories
│   ├── BoardRepo.cs
│   └── DBInitializerRepo.cs
│
├── Views
│   ├── Board
│   └── Shared
│
├── wwwroot
│
├── Program.cs
└── BoardAppDB.csproj
```

## Getting Started

### Prerequisites

* .NET SDK
* SQL Server
* Visual Studio or another compatible .NET IDE

### Clone the Repository

```bash
git clone https://github.com/Rethabile2004/BoardAppDb.git
cd BoardAppDb
```

### Configure the Database

Update the `DefaultConnection` connection string in `appsettings.json` to point to your SQL Server instance.

### Run the Application

```bash
dotnet restore
dotnet run
```

The application will initialize the database and seed the default board records when required.

## Learning Objectives

This project provides practical experience with:

* ASP.NET Core MVC
* Entity Framework Core
* SQL Server
* CRUD operations
* Repository Pattern
* Dependency Injection
* Data validation
* Database initialization and seeding
* Razor Views
* MVC routing

## Project Status

Completed practical assessment project demonstrating a database-backed ASP.NET Core MVC application.

## Author

**Rethabile Eric Siase**

Advanced Diploma in Information Technology
Central University of Technology

## License

This project was developed for educational purposes.

[1]: https://github.com/Rethabile2004/BoardAppDb "GitHub - Rethabile2004/BoardAppDb · GitHub"
