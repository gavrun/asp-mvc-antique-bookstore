# Test Plan – Antique Bookstore

## 1. Introduction

This Test Plan describes the testing activities, resources, schedule, and environments required to validate the Antique Bookstore system according to the Test Strategy.

## 2. Test Items

- ASP.NET Core MVC application
- EF Core data access layer
- Identity-based authentication subsystem
- Database schema (migrations + seed data)
- UI views and controllers
- Application services and domain rules

## 3. Features to Be Tested

### 3.1 Order and Sales Workflow
- Order creation (single and multiple books)
- Payment registration and constraints
- Order status transitions and rules
- Automatic book status updates (Available → Sold)
- Sale line creation and total calculation

### 3.2 Access Control and Authorization
- Manager-only permissions (catalog, employees, customers)
- Salesperson permissions (orders only)
- Unassigned user access behavior
- Position/Role consistency and restrictions

### 3.3 Inventory and Catalog Management
- Book CRUD with unique identifier and metadata
- Author management (CRUD + many-to-many linking)
- Condition and status handling
- Prevention of delete for sold books
- Cover image upload and file storage behavior

### 3.4 Customer and Delivery Information
- Customer CRUD
- DeliveryAddress management (one-to-many)
- Purchase history display

### 3.5 Employee and Position Management
- Employee CRUD 
- Position and Role management
- PositionHistory updates

### 3.6 Validation and Data Integrity
- Required fields per entity
- Publication year range (1600–2099)
- Identifier constraints
- Referential integrity across entities

### 3.7 Lookup Tables and Seeding
- Book conditions, statuses, order statuses
- Payment methods
- Initialization of roles and seed users

### 3.8 UI Behavior
- Navigation flows
- Form validation messages
- Modal author creation

## 4. Features Not to Be Tested

- Non-functional requirements outside of baseline performance
- Performance beyond basic UI responsiveness
- Security penetration / resilience testing
- Load or stress testing
- External integrations (none)

## 5. Test Approach

- Unit tests executed automatically through build pipeline.
- Integration tests executed against an in-memory or test SQL database.
- System tests executed manually following scripted Test Cases.
- UAT conducted using Manager and Sales accounts.

## 6. Test Environment

### 6.1 Hardware/Software

- Windows workstation
- .NET 8 SDK
- SQL Server LocalDB or SQL Server instance
- Browser: Chrome / Edge

### 6.2 Test Database

- Automatically created by EF Core migrations
- Seeded with initial roles, users, lookup tables, sample books/authors/customers
- Local file storage for cover image upload (wwwroot/images)

## 7. Test Schedule

- Unit test development: continuous throughout implementation
- Integration tests: post-data-access stabilisation
- System testing: after feature freeze
- UAT: final iteration before release

## 8. Roles and Responsibilities

| Role            | Responsibility                         |
|-----------------|-----------------------------------------|
| QA Engineer     | Prepare and execute tests               |
| Developer       | Fix defects and provide clarifications  |
| Manager         | Participate in UAT                      |

## 9. Entry and Exit Criteria

### Entry

- All migrations applied
- Database seeds successful
- Application feature-complete
- Authentication subsystem configured and operational

### Exit

- All high/critical defects resolved
- No unhandled runtime exceptions during testing
- System tests pass
- UAT acceptance obtained

## 10. Deliverables

- Test Cases
- Test Data
- Test Execution Reports
- Bug Reports
