# Component Diagram - Antique Bookstore

## Introduction

This document provides the diagrams which show the component structure of a server-side monolithic ASP.NET Core MVC application, including the presentation layer, application logic, cross-slices, and data access.

## Diagram (Logical Structure)

```
@startuml

package "Presentation" {
  component "MVC Controllers"
  component "Razor Views"
}

package "Application Services" {
  component "Business Logic\n(Controllers + Services)"
  component "LocalFileStorageService"
}

package "Domain Model" {
  component "Entities\n(Book, Author, Customer, Order, Sale)"
}

package "Cross-Cutting" {
  component "ASP.NET Core Identity"
  component "Localization"
}

package "Data Access" {
  component "ApplicationDbContext\n(EF Core)"
  component "SalesAuditInterceptor"
}

"MVC Controllers" --> "Business Logic\n(Controllers + Services)"
"Business Logic\n(Controllers + Services)" --> "Entities\n(Book, Author, Customer, Order, Sale)"
"Business Logic\n(Controllers + Services)" --> "ApplicationDbContext\n(EF Core)"
"ApplicationDbContext\n(EF Core)" --> "SalesAuditInterceptor"

@enduml

```

## Diagram (Components)

```
@startuml

actor "User" as User

package "Client" {
  component "Web Browser (HTML/CSS)" as Browser
}

package "AntiqueBookstore (ASP.NET Core MVC)" {

  package "Presentation Layer" {
    component "MVC Controllers" as Controllers
    component "Razor Views" as Views
    component "ViewModels" as ViewModels
  }

  package "Application Logic" {
    component "Domain Logic\n(Controllers + Services)" as AppLogic
    component "LocalFileStorageService" as FileStorage
  }

  package "Cross-Cutting Concerns" {
    component "ASP.NET Core Identity\n(AuthN / AuthZ, RBAC)" as Identity
    component "Localization\n(IStringLocalizer)" as Localization
    component "Validation\n& Anti-forgery" as Validation
  }

  package "Data Access Layer" {
    component "ApplicationDbContext\n(EF Core)" as DbContext
    component "SalesAuditInterceptor\n(ISaveChangesInterceptor)" as Audit
  }
}

database "SQL Server\nAntiqueBookstore\n+ Identity tables" as DB

User --> Browser
Browser --> Controllers : HTTPS
Controllers --> Views
Controllers --> AppLogic
Controllers --> Identity
Controllers --> Localization
Controllers --> Validation

AppLogic --> DbContext
AppLogic --> FileStorage

DbContext --> Audit : SaveChanges
DbContext --> DB : SQL (TDS)

@enduml
```
