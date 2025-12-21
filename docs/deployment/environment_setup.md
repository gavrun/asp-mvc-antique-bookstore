# Environment Setup – Antique Bookstore

## Purpose

This document describes how to prepare a machine to run the **AntiqueBookstore** ASP.NET Core MVC application, including database configuration and the default development startup behavior.

## Runtime dependencies

### .NET

The application is an ASP.NET Core MVC app started from `Program.cs` and configured through standard `appsettings*.json` files.

### Database

The application uses Entity Framework Core with a SQL Server connection string in `appsettings.json`.

## Configuration files

### `appsettings.json`

By default pointing to local **SQL Server**:

- `Server=(localdb)\mssqllocaldb;Database=AntiqueBookstore;Trusted_Connection=True;MultipleActiveResultSets=true`

Logging level defaults (Debug for ASP.NET Core and EF Core categories).

### `appsettings.Development.json`

Overrides logging.

### `launchSettings.json`

Environment name in `Properties/launchSettings.json` sets:

- `ASPNETCORE_ENVIRONMENT=Development`

and uses these URLs:

- `http://localhost:5230`
- `https://localhost:7091`

## Database initialization and migrations

### Automatic migrations (Development environment)

On application startup, in **Development**, the code runs Identity seeding which applies EF Core migrations.

### Non-Development environment

Running with `ASPNETCORE_ENVIRONMENT` not equal to `Development` will not execute the automatic migration/seed logic.

## Default users

In the Identity seed logic test users are created. Login page is available.

## Local file storage

The project includes file service which saves uploaded files under `wwwroot/<subfolder>`.

- Allowed file extensions: `.jpg`, `.jpeg`, `.png`
- Files are stored with a GUID filename.
