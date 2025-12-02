# Architecture Overview - Antique Bookstore

## Introduction

This document provides a high-level architectural overview of the Antique Bookstore system.  
It describes the main architectural layers, system components, and data flows.  
The goal is to outline how the system is structured conceptually, without implementation or technology details.

## System Architecture

### Architectural Style (Logical Layers)

The system follows a **layered architecture**, separating:

- **Presentation Layer** — UI and user interactions  
- **Application Layer** — orchestration of use cases  
- **Domain Layer** — core business logic and entities  
- **Data Access Layer** — persistence and database access  

The system is a **monolithic web application**. Internal module boundaries follow the domain structure. 
No external APIs or message-based integration with third-party clients are used.

### High-Level Architecture Diagram

```
[ UI (Controllers & Views) ]
          |
          v
[ Application Services ]
          |
          v
[ Domain Model (Entities, Rules) ]
          |
          v
[ EF Core Data Access ]
          |
          v
[ Database (Relational) ]
```

## Main System Components

### Presentation Layer

- Implements employee-facing web-based UI for for internal use.
- Supports CRUD operations for catalog, customers, employees, and orders.
- Provides order workflow screens (create, process, ship, complete).
- Performs client-side validation and sends commands to application layer.
- Does not contain business rules

### Application Layer

- Acts as the single entry point for all use cases.
- Hosts services for:
  - Adding books, updating statuses
  - Creating orders and sales
  - Assigning employees to positions
  - Managing customers and delivery addresses
- Implements business workflows:
  - Order lifecycle transitions
  - Sales pricing and discount event application
- Enforces role/permission requirements using employee position/role.

### Domain Layer

- Contains the core business model used across the application.
- Defines relationships and invariants:
  - A book has exactly one condition and one status  
  - An order requires a customer, employee, status, and payment method  
  - A sale links one book to one order  
  - An employee holds exactly one active position (via history)  
- Ensures historical entities remain persistent.
- Independent of storage and presentation concerns.

### Data Access Layer

- Implements object-relational mapping between domain entities and tables.
- Provides configurations for all tables and relationships.
- Responsible for storing and retrieving data from a relational database.
- Implements repositories or data access services for:
  - Books, authors, customers, orders, employees, sales
- Ensures referential integrity and maintains audit logging for selected tables.

### Cross-Cutting Components

#### Security and Access Control

- Authentication provided by internal user accounts (ApplicationUser).
- Authorization based on Position to Role mapping.
- Prevents unauthorized access.
- Sensitive operations (employee management, price changes) restricted to manager-level roles.

#### Audit Logging

- Tracks changes for traceability and compliance.
- Stores before/after values, timestamps, and operator identity.
- Implemented at the data access layer through explicit logging operations.

#### Validation

- Business validations enforced in the domain layer.
- Workflow rules and constraints (e.g., “cannot ship unpaid order”) enforced in application layer.
- Performs UI-level checks for formats and required fields in the presentation layer.

#### Error Handling

- Application layer standardizes business and validation errors.
- Presentation layer displays user-friendly messages.
- Infrastructure errors are logged and surfaced minimally to users.

## Data and Persistence

### Interaction Between Components and Database

- Application services call repositories or EF directly.  
- Domain entities are tracked by EF and persisted.  
- Complex operations (e.g., completing an order) trigger multiple entity updates within a single transaction.  

### Data Flow Overview Diagram

```
UI → Application Service → Domain Entities → EF Core → SQL Database
↑ ↓
Validation + Rules Audit Log
```

## Runtime and Interaction Flows

### Example flow

```
    User (Salesperson)
            |
            v
Presentation Layer (Order Form)
            |
            v
Application Layer (OrderService)
- Validates requested items
- Ensures employee permission
- Applies workflow rules
            |
            v
Domain Layer (Order, Sale, Status)
- Creates order entity
- Applies business invariants
            |
            v
Data Access Layer
- Saves Order, Sales, updates Book status
- Writes audit log if applicable
            |
            v
        Database
```

## Design Considerations

### Design Patterns

- Layered architecture  
- Repository-like data access (via EF abstractions)  
- Aggregates around main domain entities
- Many-to-many bridging entities  
- Temporal pattern for employee role assignments 

### Design Principles

- Separation of concerns between UI, workflows, and domain logic  
- Domain-driven naming and concept alignment  
- Avoidance of business logic in controllers  
- Maintaining historical data for traceability  
- Minimizing coupling across modules

### Performance Optimization Techniques 

- Using navigation properties with controlled eager/lazy loading  
- Applying indexes on foreign keys 
- Reducing over-fetching in UI queries  
- Short transactions 

## Technology Overview

### Technology Stack

- C# as primary language
- ASP.NET Core MVC for web layer 
- Razor Views with HTML, CSS, Bootstrap (Bootswatch) for frontend 
- JavaScript/jQuery for frontend interactivity
- Entity Framework Core (EF Core) for Code-first/ORM
- SQL Server as relational database
- EF Core Interceptor for audit
- ASP.NET Core Identity for authentication and authorization 
- Local file storage
- xUnit + FluentAssertions for unit and integration tests

### File Structure

- controllers, views, UI models 
- entities, domain logic, invariants 
- DbContext, configurations, migrations, seeding 
- unit and integration tests 
- logging, identity, helpers 

```
```

## Deployment Architecture

### Deployment Model

- Monolithic web application.
- Runs on an internal network.
- Deployed on an internal web server (tested on Kestrel).
- Uses environment-based configuration
- Uses a relational SQL database for persistence.
- No external integrations.

## Scalability and xtensibility

The architecture allows adding new functionality.

## Appendix
