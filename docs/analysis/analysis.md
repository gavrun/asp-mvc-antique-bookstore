# Semantic Analysis of Business Scenario

The semantic analysis of the initial business scenario resulted in the formulation of functional requirements, the SRS document prospect, and the identification of key entities for a project conceptual model.

## Domain Overview

The business scenario describes a small bookstore specializing in rare and antiquarian books. All operational processes are currently handled on paper. The owner wants a centralized information system to support inventory management, order processing, sales tracking, customer records, and employee management.

The bookstore’s domain entities can be categorized into:
- Books and related metadata
- Authors
- Inventory copies / unique identifiers
- Employees and roles/positions
- Customers and purchases
- Orders and order fulfillment workflow
- Payment methods and statuses

The system must support both data accuracy and access control because only some staff may modify sensitive data (employees, books, customers).

## Key Concepts and Semantics

### Books

Each book title may have many physical copies, and each copy has a unique identifier.

A book includes:
- title (required)
- author(s) (one or many)
- publisher (optional)
- publication date/year (1600–2099; year only)
- edition number (optional)
- purchase cost and recommended retail price
- condition (categorical: Excellent → Damaged, each with optional description)
- status: available/reserved/sold/etc.

A “book” in business terms is a distinct copy (inventory item), not merely a “title”. Even multiple identical copies are distinct units with their own identifiers.

### Authors

About 2,500 authors are recorded.

Each author has:
- first name (required)
- last name (required)
- birth year (optional)
- death year (optional)
- short biography (optional)

A book may have multiple authors; an author may have multiple books many-to-many.

### Employees and Positions

Store staff: about 12 workers; one manager and one assistant with elevated permissions.

Employee data includes:
- first/last name
- address
- phone, birth date
- hire date
- position (manager/assistant/full-time salesperson/part-time salesperson)

Positions may change over time; new positions may be added.
Only manager and assistant may view/modify employee information.

### Customers

Around 2,000 customers tracked.
Required fields: first name, last name. Optional: phone, address.
A customer may or may not have purchases.

### Orders and Sales

An order includes:
- the customer
- the employee who created/sold
- one or more books
- quantity per book
- order date
- delivery date (filled only when delivered)
- payment method: cash, check, credit card
- status: pending shipment, pickup, shipped, received

A book cannot be delivered until it is paid.
A sold copy must remain in the database but with “sold” status.
Orders track the entire lifecycle from creation, payment, delivery, completion.

## Actors and Responsibilities

### Manager

Edit all catalog data, manage employees, oversee orders.
Full read/write access.

### Assistant Manager

Same as manager for employees and catalog.
Same elevated access.

### Salesperson

Create and manage orders, register sales, view catalog, view customers.
Limited write; no access to employee management.

### Customer (external)

Purchases books. No system access.

## Operational Processes

### Book Inventory Management

Add a new book copy with required metadata and unique ID.
Update condition or status.
Maintain historical availability (sold copies stay in system).
Maintain author relationships.

### Customer Management

Register a customer with minimal required info.
Optionally add address/phone.
Track history of purchases.

### Employee and Role Management

Add or update employee records.
Assign positions that define permissions.
Modify role list itself (manager-level).

### Order Lifecycle

Create order.
Add one or more book copies.
Register payment (mandatory before delivery).
Perform delivery or confirm pickup.
Finalize/completion.

### Sales Tracking

The system must track which employee sold which books.
Historical audit is required to prevent errors in manual processes.

## Implicit Requirements and Constraints

The scenario implies several unspoken requirements:

### Data Quality Constraints

Publication year validation (1600–2099).
Required fields per entity (titles, names, etc.).
Prevent deleting sold books.

### Security and Access Control

Only managers/assistants can modify employees.
Salespeople cannot modify catalog or authors.
Only authenticated staff use the system (internal system).

### Scalability and Growth

Expected 10% yearly growth of books, authors, customers, orders.
System must operate with ~thousands of records.

### Reliability

Centralized source of truth replaces paper forms.
Must enforce data consistency (e.g., sold books and status changed).

### Usability Requirements

Quick access to catalog for salespeople.
Reducing error rate vs. paper-based processes.
Simplified order creation.

## Derived Domain Model

From the scenario narrative, the system domain includes at least:

- Book
- Book Condition
- Book Status
- Author
- BookAuthor (mapping)
- Customer
- Delivery Address
- Employee
- Position
- Order
- Order Item 
- Payment Method
- Order Status
- Sale (per-book sale record)

## Gaps and Ambiguities

To pass this scenario to a complete requirement set, several ambiguities must be clarified or resolved, for example:

- Order items: scenario says “order may include multiple books” but doesn’t define structure
- Book unique ID format: scenario says 8 characters; system must enforce rules
- Inventory and sold status: scenario requires keeping sold books records; system must control state transitions
- Access control: scenario defines general rules; RBAC must be formalized
- Multiple delivery addresses per customer need clarification: scenario suggests “postal address”
- Internationalization or locale constraints are not mentioned

