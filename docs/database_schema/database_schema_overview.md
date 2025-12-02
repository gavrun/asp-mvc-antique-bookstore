# Database Schema Overview – Antique Bookstore

## 1. Introduction

This document provides a short overview of the Antique Bookstore database logical/physical schema. 
The schema aligns with the conceptual data model and class diagrams and reflects the final table structure, keys, and relationships.

## 2. Domain Areas and Main Tables

### 2.1 Books, Catalog, and Authors

The tables representing the main catalog of books:

- `Book` — physical book copy with unique identifier and core metadata.  
- `BookCondition` — predefined quality classification.  
- `BookStatus` — availability state of a copy.  
- `Author` — author information and biography.  
- `BookAuthor` — many-to-many link between books and authors.

### 2.2 Customers and Addresses

Customer data and their possible delivery locations:

- `Customer` — customer profile with minimal required fields (first/last name) and optional contact info.  
- `DeliveryAddress` — one-to-many addresses per customer, including country, city and detailed address fields.

### 2.3 Orders and Sales

The tables for order processing and sales history:

- `Order` — customer purchase, linked to customer, employee, status, payment method, and optional delivery address.  
- `OrderStatus` — order lifecycle stages.  
- `PaymentMethod` — how the order is paid.  
- `Sale` — order lines, linking each sold book copy to an order and sale price.  
- `SaleEvent` — promotional events that may affect pricing.

### 2.4 Customers & Delivery


### 2.5 Employees, Positions, and Roles

Staff and roles hierarchy, both current assignment and historical tracking of employee roles:

- `Employee` — staff member records.  
- `Position` — job positions (e.g. Manager, Sales), with work schedule and linked role.  
- `Role` — abstract role level for access and responsibility grouping.  
- `PositionHistory` — history of employee–position assignments over time.

### 2.6 Application Access and Audit

The application user account itself is managed at the application layer and mapped to a staff member record.

Audit records provide change tracking and reference the login used at the database level.

- `SalesAuditLog` — audit trail of changes to critical business data (table name, column, old/new values, timestamp, login).  

## 3. Design Decisions

### 3.1 Normalization

The schema is normalized approximately to **Third Normal Form (3NF)**:

- Repeated values are extracted into lookup/reference tables.  
- Many-to-many relationships use explicit link tables.  
- History and status information are kept in separate tables.

### 3.2 Historical Data Preservation

Historical records are **not physically deleted** to support auditability and long-term reporting:
- Sold books remain in the database with an updated status.  
- Past orders and sales remain in the database.  
- Employee role changes are tracked via and remain in the database. 

### 3.3 Use of Lookup and Reference Tables

Several lookup tables are used to control vocabularies and states.
Boolean flags allow soft deactivation of reference values **without breaking referential integrity**.

### 3.4 Keys and Identifiers

Surrogate primary keys are used for most tables (integer identity fields). Composite keys are used where appropriate. 

### 3.5 Referential Integrity

Foreign key relationships enforce consistency between domain areas. The audit log table is **intentionally not enforced with foreign keys** to remain flexible and independent of transactional operations.

