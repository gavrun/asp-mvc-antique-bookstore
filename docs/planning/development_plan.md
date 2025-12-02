# Development Plan - Antique Bookstore 

## 1. Introduction

The purpose of this document is to describe the **technical development approach** for the Antique Bookstore system.
It defines how the solution will be implemented, the development methodology, coding principles, testing strategy, branching model, and the iteration structure that guides the full engineering lifecycle.

The project follows a **hybrid implementation** strategy, combining:

* A structured **SDLC (Software Development Life Cycle)**
* **Iterative** and **Agile-inspired** development cycles
* **TDD** selectively applied to mission-critical business rules
* **Unit testing** for supporting functionality where needed

This document explains the philosophy and model of development. The detailed listings of specific tasks appear in `development_plan_tasks.md`.

## 2. Technical Approach

### 2.1 Architectural Model

The Antique Bookstore system follows a **clean, layered architecture**, composed of:

* **Presentation Layer**
  ASP.NET Core MVC controllers, Razor views, view models

* **Domain Layer**
  Domain entities (Book, Author, Order, Sale, Employee, etc.)
  Business rules and domain constraints

* **Data Layer**
  EF Core DbContext, entity configurations, migrations, interceptors
  SQL database schema defined through EF Core

* **Infrastructure Components**
  File storage service
  Audit interceptor
  Identity and authorization components

### 2.2 Coding Standards

* C# 10+
* ASP.NET Core MVC conventions
* Naming and formatting as per .NET guidelines
* Lean controllers
* Strong EF Core constraints 
* Use of async/await 
* Dependency Injection 

### 2.3 Development Style

* Implement features in **small iterations**
* Keep commits incremental and focused
* Maintain readable, self-describing code
* Favor early validation in the domain layer
* Use automated tests for critical rules
* Ensure UI consistency via layout and reusable partials
* Prefer configuration over conventions when domain rules require it

## 3. SDLC Methodology

The project uses a hybrid iterative **SDLC model**, similar to Agile but aligned with formal SDLC phases.

Each iteration contains:

1. **Iteration Planning**
   Define feature goals and required changes.

2. **Analysis and Design**
   Review functional requirements and identify affected domain areas.

3. **Implementation**
   Code features, configuration, UI, and logic.

4. **Testing**
   Execute unit tests, TDD cycles, and manual validation.

5. **Demo/Review**
   Verify stability and confirm requirements are met.

6. **Retrospective (optional)**
   Evaluate process and adjust future iterations.

### Why a Hybrid Model?

* The structured workflows (Orders, Sales, Audit, Employees) require formal documentation and well-defined SDLC phases.
* Iterative development allows quick feedback and visible progress.
* Selective TDD increases correctness at early stages without excessive test overhead.

### Why TDD for Core Business Rules?

TDD is applied where:

* Behavior is **critical**
* Logic is **not trivial**
* Logic is **reusable**
* Incorrect implementation risks bad data or workflow issues

TDD is *not* used for testing Razor views, CRUD scaffolding, EF Core mapping, UI rendering, etc. These areas provide low return on test-first development.

## 4. Testing Strategy

### 4.1 Testing Layers

1. **TDD Unit Tests (Core Business Rules)**

   * Written before implementation
   * Describe expected domain behavior
   * Cover deterministic logic
   * Validate order transitions, sale logic, and similar

2. **Standard Unit Tests**

   * Additional tests written after implementation
   * Validate helper utilities, calculations, simple validations (where needed)

3. **Integration/Flow Tests**

   * Optional, minimal
   * Validate end-to-end creation of an order or sale

4. **Manual UI Testing**

   * For Razor views and workflows
   * Confirm visual and interactive correctness

### 4.2 Categories of Tests

* **Domain rules tests** (highest value)
* **Validation tests**
* **Error-handling tests**
* **Data integrity tests** (EF behavior)
* **Permission/security checks** (role-based access)

### 4.3 Goals

* Provide a stable safety net for core logic
* Support future refactoring
* Avoid unnecessary test overhead

## 5. Branching and Commit Strategy

### 5.1 Branching Model

A lightweight Git model is used:

* **main**
  Stable, release-ready code
* **release/* branches**
  Created for releases and patches
* **feature/* branches**
  Created for specific features or iterations before merging
* **test/* branches**
  Used when developing test logic before merging
* **docs/**
  Optional branch for documentation refinement

### 5.2 Commit Guidelines

* **Small, atomic commits**
* Each commit should represent one conceptual change
* Commit messages follow `<Category>(optional): <Short description>`
  Examples:

  * `feature: added Author CRUD`
  * `test: added Order lifecycle TDD test`
  * `refactor: extracted Sale Price logic`
  * `fix: corrected Book cover deletion`

### 5.3 Iteration-Driven Commits

Commits reflect the evolution of:

* Entities
* Controllers
* Views
* EF Core configuration
* Tests

Each iteration ends with a stable, test-passing version.

## 6. Tooling

### Development Tools

* **IDE:** Visual Studio 2022
* **Runtime:** .NET 8+
* **Frontend:** Razor Views, Bootstrap 
* **Database:** SQL Server LocalDB or SQL Express
* **ORM:** EF Core 8
* **Authentication:** ASP.NET Identity
* **Test Framework:** xUnit + FluentAssertions
* **Build Tools:** dotnet CLI
* **Version Control:** Git + GitHub
* **Diagram Tools:** PlantUML / draw.io / dbdiagram.io (DBML)

### Additional Libraries

* CsvHelper (export functionality)

## 7. Dependencies and Integration

### External Dependencies

* Bootstrap/Bootswatch UI theme framework
* EF Core packages
* Identity UI components
* CsvHelper for export
* jQuery Validation for client-side validation

### Internal Integrations

* **File Storage Service**
  Local storage for book cover images
* **Audit Logging System**
  Custom EF Core interceptor recording table changes
* **Role-Based Access Control**
  Identity + authorization policies

### Database Integration

* Database schema generated by EF Core migrations
* Strong referential integrity
* Seed data for testing and evaluation (where needed)

## 8. Risks

| Risk                         | Impact                         | Mitigation                            |
| ---------------------------- | ------------------------------ | ------------------------------------- |
| Insufficient test coverage   | Logic bugs in workflows        | Focus tests on core business rules    |
| Complex workflows            | Higher defect risk             | Validate early via TDD tests          |
| Security misconfiguration    | Unauthorized access            | RBAC + Identity + threat modeling     |
| Data inconsistency           | Broken relationships           | EF Core constraints and validation    |
| UI usability issues          | Staff workflow inefficiency    | Wireframes + usability guidelines     |
| Schema drift                 | Migrations become inconsistent | Controlled iteration-based migrations |

## 9. Deliverables

### Technical Deliverables

* Complete source code
* Domain model and EF configurations
* Razor page views and controllers
* File storage infrastructure
* Audit logging subsystem
* Unit tests
* Migrations and schema files
* Configuration files 

### Documentation Deliverables

* Architecture Overview
* Conceptual Model
* ERD/DBML schema
* API reference
* Test Plan and test cases
* Deployment guide
* Release notes
* Support/maintenance documentation

