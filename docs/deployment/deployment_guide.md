# Deployment Guide – Antique Bookstore

## 1. Overview

This document describes a practical, manual deployment flow for the ASP.NET Core MVC web application.

## 2. Pre-deployment checklist

* Confirm the target environment has a reachable SQL Server instance.

* Decide how `ConnectionStrings:DefaultConnection` will be provided on the target:
  - `appsettings.json` / environment-specific settings file;
  - environment configuration (secrets).

* Decide whether Identity seed users should exist in the target environment:
  - project seeds users/roles only when `ASPNETCORE_ENVIRONMENT=Development`.

## 3. Build and publish

Publish the web application project using the standard .NET publish flow.

Expected output:
- A folder containing the compiled application
- `wwwroot` included (required for static assets and uploaded files)

## 4. Configure the database connection

The app reads a single required connection string:

- `ConnectionStrings:DefaultConnection`

Ensure the target environment uses a valid SQL Server connection string and that the configured database is accessible to the application process.

## 5. Migrations and seed behavior

### 5.1 What happens in Development

When running with `ASPNETCORE_ENVIRONMENT=Development`:

- The app calls Identity Seeder
- The seeder applies migrations 
- Roles/users are created if missing (Manager/Sales and default user accounts)

### 5.2 What happens outside Development

When running with `ASPNETCORE_ENVIRONMENT` not equal to `Development`:

- Identity Seeder is not called
- Automatic migration + default user/role creation does not occur

Operational implication:
- If you deploy as non-Development, plan a separate step for database migrations and Identity initialization.

## 6. Static files and uploaded covers

The application stores uploaded cover images under:

- `wwwroot/<subfolder>`

Deployment requirement:
- The published `wwwroot` must be writable by the application process if uploads are enabled.
- Ensure the upload folder persists across redeployments if you want to keep previously uploaded covers.

## 7. Post-deployment checks

- Open the application root page and confirm the site loads.
- Navigate to the login page and confirm authentication works.
- Confirm database connectivity by visiting any page that reads from the database.

## 8. Rollback strategy (manual)

For a manual project deployment, rollback means:

- Replace the deployed application folder with the previous published version
- Restore the database only if a schema change must be reverted 
