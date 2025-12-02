# Functional Requirements - Antique Bookstore

## Introduction

This document specifies the functional requirements for the **Antique Bookstore**, based on the analyzed business scenario and domain semantics. The purpose is to define the behavior, constraints, and responsibilities of the system prior to implementation and testing.

The structure follows a IEEE-830/ISO-29148 style.

## Scope

The system supports internal bookstore operations:

* management of books and inventory copies
* management of authors
* management of customers
* management of employees and their positions
* creation and processing of orders and sales
* enforcement of access control
* basic catalog and retrieval

The system is for internal staff only; customers do not interact directly.

## Actors

**Manager** has full administrative access. Manages catalog, employees, customers, orders.

**Assistant Manager** same as Manager, except possible administrative restrictions defined by policy.

**Salesperson** creates and manages orders; registers sales; views catalog; views customers.

**System** performs validation, state transitions, enforcement of rules.

## Functional Requirements

### Book and Inventory Management

The system shall allow creating a new book copy with: title, author list, publication year (1600–2099), optional publisher, optional edition number, cost price, recommended price, condition, and status.

The system shall enforce that each physical book copy has an identifier.

The system shall allow editing book metadata except the unique identifier once assigned.

The system shall support multiple authors per book and maintain a many-to-many relationship.

The system shall prevent deletion of a book that has ever been sold; such books may only be archived or marked “Sold”.

The system shall maintain a list of predefined book conditions; each condition may include an optional description.

The system shall maintain a list of book statuses (“Available”, “Reserved”, “Sold”, “Archived”), and enforce valid transitions.

### Author Management

The system shall allow creating, viewing, and updating authors with: first name, last name, birth year (optional), death year (optional), and biography (optional).

The system shall prevent deletion of authors that are associated with at least one book.

The system shall allow searching authors by name.

### Customer Management

The system shall allow creating customer profiles with: first name (required), last name (required), phone (optional), email (optional), address information (optional).

The system shall support at least one delivery address per customer; additional addresses are optional.

The system shall allow updating customer data.

The system shall allow viewing purchase history for each customer.

### Employee and Position Management

The system shall allow manager-level users to create, update, and deactivate employee profiles.

The system shall allow defining positions with: title, schedule type, optional description.

The system shall enforce that each employee has exactly one assigned position.

The system shall allow modifying the list of available positions.

The system shall restrict access to employee records to managers and assistant managers only.

### Orders and Sales

The system shall allow creating new orders containing:

* customer
* salesperson
* list of book copies
* quantity per book
* order date
* initial order status

The system shall require specifying a payment method (cash, check, credit card) before an order may be marked as delivered.

The system shall allow updating the order status according to allowed transitions:

* Pending Shipment to Shipped
* Pending Shipment to Pickup
* Shipped to Received
* Pickup to Received

The system shall prevent marking an order as delivered until payment is recorded.

The system shall mark each book copy included in a completed order as “Sold”.

The system shall allow viewing order details and order history per customer and per employee.

The system shall support adding multiple book copies to a single order.

## Catalog Presentation

The system shall display list of books with title, author, publication year, and price.

The system shall display detailed information for each book on demand, including all metadata and authors.

## Security and Access Control

The system shall require user authentication for all operations.

The system shall enforce role-based access control:
* Managers and assistant managers may modify books, authors, customers, employees.
* Salespersons may modify only orders and view catalog/customer information.

The system shall restrict access to employee management screens to authorized roles only.

The system shall prevent any user from modifying order data they are not authorized to view.

## Data Validation and Business Rules

The system shall validate publication year to be between 1600 and 2099.

The system shall ensure mandatory fields are filled when creating or updating records.

The system shall maintain referential integrity between books, authors, customers, employees, orders, and addresses.

## Non-Functional Requirements

**Usability** The system shall support efficient workflows for salespeople (order creation within minimal screens).

**Performance** Rendering catalog shall return results within 1 second for datasets up to 20,000 books and 5,000 customers.

**Reliability** All business-critical operations (order creation, sale registration) shall be atomic and logged.

**Security** All authenticated sessions shall use secure transport (HTTPS).

**Scalability** The system shall support 10% per-year growth without requiring redesign.

## Assumptions and Constraints

Only internal staff uses the system; no public-facing UI.

System runs on a single database.

Workflow and permission model may evolve.
