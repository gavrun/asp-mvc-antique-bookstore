# Conceptual Data Model - Antique Bookstore

## 1. Introduction

This document provides a high-level conceptual data model for the Antique Bookstore.
It defines the core business entities, their purpose, and the relationships between them. 
The conceptual model is technology-agnostic and serves as a foundation for subsequent logical and physical data models, domain design, and application architecture.

## 2. Conceptual Overview

The system manages the lifecycle of rare antique books inventory, employees, customers, authors, and orders.
The conceptual model focuses on key informational objects used by all business processes.

The primary domains:

- **Catalog and Inventory**
- **Authors and Metadata**
- **Customers and Delivery**
- **Employees, Positions, Roles**
- **Orders and Sales**
- **Access and User Accounts**

## 3. Core Entities

### 3.1 Book

Physical book copy.

- Unique identifier per physical item.
- Main data: title, publisher, publication year, prices, condition, status.
- Remains in the system after sale (status switches to “Sold”).

### 3.2 Author

Person who wrote one or more books.

- Optional bio and birth/death years.
- Many-to-many with Book (via linking entity BookAuthor at implementation level).

### 3.3 Book Condition

Predefined quality classification for a book (e.g. Excellent, Good, Fair, Poor).

### 3.4 Book Status

Availability of a book copy.

- Examples: Available, Reserved, Sold, Archived.

### 3.5 Customer

Person who buys or orders books.

- Minimal required: first name, last name.
- Optional contact info, multiple delivery addresses.
- Can have zero or many orders.

### 3.6 Delivery Address

Shipping destination for a customer.

- One customer – many addresses.
- Used in orders that require shipment; optional for pickup.

### 3.7 Employee

Bookstore staff member.

- Has exactly one Position at any given time.
- Creates and manages orders.
- Sensitive data visible only to privileged roles.

### 3.8 Position

Job role for employees.

- Examples: Store Manager, Sales Associate.
- Includes work schedule (full-time/part-time etc.).
- Linked to a Role that represents role level.

### 3.9 Role

Abstract role level used for access control and grouping positions. One Role – many positions

- Examples: Manager, Sales.

### 3.10 Position History

History of employee–position assignments.

- Tracks start/end dates and active flag.
- Many records per Employee; each record points to one Position.

### 3.11 Order

Customer’s purchase processed by an employee.

- Has one Customer, one Employee, one Payment Method, one Order Status.
- May have a Delivery Address (for shipment).
- Contains one or more Sales (order lines).

### 3.12 Sale

Single order line (sale of a specific book copy).

- Links one Order and one Book.
- Stores sale price (price at time of sale).
- Optionally linked to a Sale Event.

### 3.13 Payment Method

Way to pay for an order.

- Examples: Credit Card, Cash, Bank Transfer.

### 3.14 Order Status

Stage of the order lifecycle.

- Examples aligned with implementation: New, Processing, Shipped, Delivered, Cancelled, Payment Pending, Paid.

### 3.15 Application User

Authenticated system account.

- Used for login and authorization.
- Optionally linked 1-to-1 with an Employee.

### 3.16 Sale Event

Promotional or discount event.

- Has name, discount value, start/end dates.
- One event – many Sales.

### 3.17 Sales Audit Log

Audit trail of data changes in sales-related entities.

- Stores table name, record id, operation type, values before/after, timestamp, user login.
- Used for traceability; not directly involved in business workflows.



## 4. Key Relationships (Conceptual)

- **Book – Author**: many-to-many  
  One book has many authors; one author can write many books.

- **Book – BookCondition**: many-to-one  
  Each book has one condition.

- **Book – BookStatus**: many-to-one  
  Each book has one status at a time.

- **Customer – DeliveryAddress**: one-to-many  
  One customer has multiple delivery addresses.

- **Customer – Order**: one-to-many  
  One customer places many orders.

- **Employee – Order**: one-to-many  
  One employee manages many orders.

- **Order – Sale**: one-to-many  
  One order consists of one or more sales (lines).

- **Sale – Book**: many-to-one  
  Each sale refers to exactly one book copy.

- **Employee – PositionHistory**: one-to-many  
  One employee has multiple historical position records.

- **PositionHistory – Position**: many-to-one  
  Each history record points to one position.

- **Position – Role**: many-to-one  
  Each position belongs to one role level; one role groups many positions.

- **Employee – Position** (current): many-to-one (conceptual)  
  An employee currently holds one position.

- **ApplicationUser – Employee**: one-to-one (optional)  
  A login account may be linked to one employee profile.

- **Order – PaymentMethod**: many-to-one  
  Each order uses one payment method.

- **Order – OrderStatus**: many-to-one  
  Each order has one current status.

- **Sale – SaleEvent**: many-to-one (optional)  
  A sale can belong to one sale event or none.

- **SalesAuditLog – (various entities)**:  
  Logs changes to multiple entities; relationships are logical rather than FK-based.


## 5. Conceptual Diagram

Conceptual diagram ASCI or ERD diagram.
This representation expresses only **business meaning**, not database keys, cardinalities in detail, or implementation specifics.

## 6. Future Extensions

Possible extensions of the conceptual model:

- Book categories/genres and tagging.
- Supplier/vendor and procurement data.
- Customer loyalty programs and discounts rules.
