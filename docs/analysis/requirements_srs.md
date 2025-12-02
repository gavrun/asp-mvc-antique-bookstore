# Software Requirements Specification (SRS) - Antique Bookstore

Version 1.0
Date: []

## 1. Introduction

### 1.1 Purpose

This document defines the functional and non-functional requirements for the **Antique Bookstore**, intended to replace the store’s manual paper-based inventory, sales, and order management processes. 
The document is used by project stakeholders, analysts, architects, designers, and developers as the baseline for system design and implementation.

This document's structure is based on IEEE Std 830-1998. Content aligns with ISO/IEC/IEEE 29148:2018

### 1.2 Scope

**In Scope:**

The system will provide internal staff with tools for:

- managing rare and antiquarian book inventory
- maintaining author information
- maintaining customer information
- managing employees and positions
- processing orders and tracking sales
- ensuring accurate state transitions for inventory
- enforcing role-based access to sensitive data

The system is internal only. Customers do not access it directly.

**Out of Scope:**

Payment integration, delivery management, analytics.

### 1.3 Intended Audience

- Product Owner / Store Manager
- Business Analysts
- System Architects
- Software Developers
- Testers
- Documentation and support staff

### 1.4 Definitions, Acronyms, and Abbreviations

| Term            | Definition                                                           |
| --------------- | -------------------------------------------------------------------- |
| **Book Copy**   | A unique physical item tracked by an identifier.         |
| **Order**       | A customer purchase record, may contain multiple book copies.        |
| **Condition**   | Quality rating applied to a book copy.                               |
| **Status**      | Availability state of a book copy (Available, Reserved, Sold, etc.). |
| **Position**    | Job role assigned to an employee defining permissions.               |
| **Salesperson** | Employee handling orders and sales.                                  |

## 2. Overall Description

## 2.1 Product Perspective

The system is a standalone web-based application with a relational database backend. It replaces manual paper logs and serves as the central source of truth for all bookstore operational data.

### 2.2 Product Functions

The system provides:

- Book catalog and inventory management
- Author management
- Customer and delivery address management
- Employee and position management
- Order creation, payment status tracking, delivery status tracking
- Sales tracking per employee
- Role-based access security

### 2.3 User Classes and Characteristics

| User Class            | Description                   | Privileges                                          |
| --------------------- | ----------------------------- | --------------------------------------------------- |
| **Manager**           | Store owner or administrator  | Full access to all data and configuration           |
| **Assistant Manager** | Senior staff                  | Same as manager except optional policy restrictions |
| **Salesperson**       | Regular employee              | Create/manage orders, view catalog and customers    |
| **System**            | Internal automated operations | Validation, consistency, status updates             |

### 2.4 Constraints

- Publication year must be between 1600–2099.
- Book copy IDs must be unique identifiers.
- The system must maintain historical data for sold items.
- Only managers/assistants may modify staff records.
- The system must maintain referential integrity across all entities.

### 2.5 Assumptions and Dependencies

- All users operate from trusted internal workstations.
- The store may grow at approximately 10% per year.
- A standard SQL database is available for persistent storage.
- The system will operate in English in firts implementation.

## 3. Functional Requirements

### 3.1 Book and Inventory Management

#### 3.1.1 Description

The system maintains structured information about each physical book copy.

#### 3.1.2 Functional Requirements

* **FR-B1** The system shall allow creating book records with required fields: title, authors, publication year, condition, and status.
* **FR-B2** The system shall enforce unique identifiers for each book copy.
* **FR-B3** The system shall allow editing book metadata except the unique identifier.
* **FR-B4** The system shall maintain conditions and statuses as controlled vocabularies.
* **FR-B5** The system shall prevent deletion of books that are part of completed orders.
* **FR-B6** The system shall keep sold books visible in the catalog with “Sold” status.

### 3.2 Author Management

#### 3.2.1 Description

The system stores all authors relevant to the catalog.

#### 3.2.2 Functional Requirements

* **FR-A1** The system shall allow creating and updating authors with optional biography and life dates.
* **FR-A2** The system shall support many-to-many relationships between authors and books.
* **FR-A3** The system shall prevent deleting authors linked to existing books.

### 3.3 Customer Management

#### 3.3.1 Description

The system stores customer information for order processing.

#### 3.3.2 Functional Requirements

* **FR-C1** The system shall allow creating customer records with minimal required fields (first name, last name).
* **FR-C2** The system shall allow storing one or more delivery addresses per customer.
* **FR-C3** The system shall allow updating customer information.
* **FR-C4** The system shall provide access to customer purchase history.

### 3.4 Employee and Position Management

#### 3.4.1 Description

The system maintains employee profiles and associated job roles.

#### 3.4.2 Functional Requirements

* **FR-E1** Only manager-level roles shall create or modify employee records.
* **FR-E2** The system shall require each employee to have exactly one position.
* **FR-E3** The system shall allow managers to create or modify available positions.
* **FR-E4** The system shall track employee hire dates and active status.

### 3.5 Order and Sales Management

#### 3.5.1 Description

The system manages the full lifecycle of orders and sales.

#### 3.5.2 Functional Requirements

* **FR-O1** The system shall allow creating orders with one customer, one salesperson, and one or more book copies.
* **FR-O2** The system shall require specifying a payment method before delivery can be confirmed.
* **FR-O3** The system shall maintain order statuses: Pending Shipment, Pickup, Shipped, Received.
* **FR-O4** The system shall enforce valid status transitions and prevent delivering unpaid orders.
* **FR-O5** The system shall mark book copies included in completed orders as “Sold”.
* **FR-O6** The system shall allow viewing orders by customer, by employee, and by date.

### 3.6 Catalog Browsing

#### Functional Requirements

* **FR-S1** The system shall display detailed information for each book, including all authors.

### 3.7 Access Control and Security

#### Functional Requirements

* **FR-AC1** The system shall require authentication for all operations.
* **FR-AC2** The system shall enforce role-based access control.
* **FR-AC3** Only managers/assistants may modify books, authors, customers, employees.
* **FR-AC4** Salespersons may only create and manage orders and view catalog/customer data.

## 4. Non-Functional Requirements

### 4.1 Performance

* Rendering catalog operations should return results within 1 second for datasets up to 20k books.

### 4.2 Reliability

* Order creation and payment registration must be atomic and logged.
* No data loss is permitted for completed orders.

### 4.3 Usability

* Order creation workflow should require minimal navigation steps and be usable by non-technical staff.

### 4.4 Security

* All authenticated communications shall use HTTPS.
* System shall prevent unauthorized viewing or modification of sensitive data.

### 4.5 Scalability

* The system must support gradual data growth of at least 10% annually.

## 5. Data Requirements

* All entities must have stable primary keys.
* Referential integrity must be enforced by the database.
* Historical records (sold books, completed orders, inactive employees) must not be deleted.

## 6. System Interfaces

### 6.1 User Interface Requirements

* Browser-based UI, optimized for desktop.
* Simple forms for CRUD operations.

### 6.2 External System Interfaces

* None anticipated in the initial version.
* Future extension may include accounting/export functions.

## 7. Acceptance Criteria

* System allows staff to fully replace paper processes.
* All critical workflows (book creation, order processing, payment, delivery) function end-to-end.
* Access control prevents unauthorized modifications.
* Data validations prevent incorrect or inconsistent entries.

## 8. Appendices

### Appendix A — Glossary

### Appendix B — Future Extensions (Out of Scope)

* Online customer portal
* Analytics dashboards
* Full audit logging and reporting
