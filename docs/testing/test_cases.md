# Test Cases – Antique Bookstore

## Introduction

This document provides **test cases** to **validate functional requirements** of the Antique Bookstore system. 
Each test case references the relevant requirement IDs defined in the **SRS** and Functional Requirements.

The goal is to satisfy **SDLC acceptance criteria**.
The test suite is an attempt to cover all functional requirements, domain rules and use cases defined in the SRS.

## Test Case (Detailed Example)

This is the example test case with the **realistic detailed steps and expected results**.

## TC-001: Create New Book With Single Author

Related Requirements: FR-B1, FR-B2, FR-B3, FR-B6

### Preconditions

- Manager user is logged in.
- At least one Author exists (seed data).
- Lookup tables BookCondition and BookStatus are seeded.
- Application is running with seeded Books data.
- Browser has access to the Books Create page.

### Steps

1. Navigate to Books → Create.
2. In the form:
   - Enter Title e.g. "Test Book".
   - Enter Publisher e.g. "Test Publisher".
   - Enter Publication Year between 1600 and 2099 e.g. 2000 (must satisfy domain validation).
   - Enter valid PurchasePrice e.g. 100.00.
   - Enter valid RecommendedPrice e.g. 300.00.
3. In Author dropdown, select an existing author e.g. "Arthur Conan Doyle"
4. In Condition, choose one of the seeded values e.g. "Good"
5. In Status, choose “Available”.
6. Optionally attach a cover image file (default images stored in `wwwroot/images`).
7. Press Create.

### Expected Results

- A new Book record is created in the SQL Server database via EF Core.
- A unique integer Book Id is assigned.
- A corresponding row appears in BookAuthors linking Book Id → Author Id.
- Correct FK bindings saved with BookCondition and BookStatus
- Book appears in Books → Index list or search results (if implemented) with correct metadata.
- No validation errors displayed.
- Cover image saved to local storage if provided.
- No EF Core exceptions or constraint violations.


## Test Cases Suite

The **test suite** below covers **all major functional domains**:

* Books Catalog
* Authors
* Customers, Addresses
* Employees, Positions, RBAC
* Orders, Sales
* Lookup Tables
* Validations
* Authorization/Security
* Audit Logging

### 1. Books Catalog and Book Management

#### TC-001: Create New Book With Single Author

Related: FR-B1, FR-B2, FR-B3

Preconditions:
- Manager logged in; at least one Author exists.

Steps:
1. Go to Books → Create.
2. Enter valid book metadata.
3. Select Author, Condition, Status.
4. Submit.

Expected:
- Book created; unique BookID generated; appears in list.

#### TC-002: Create Book With Multiple Authors

Related: FR-B1, FR-B2

Preconditions:
- Manager logged in; at least two Authors exist.

Steps:
1. Create book with two authors.

Expected:
- Book created; two BookAuthor links saved.

#### TC-003: Create Book With New Author (Modal)

Related: FR-B2

Preconditions:
- Manager logged in.

Steps:
1. Open modal “Create New Author”.
2. Enter valid author data; save.
3. Modal closes; author appears in dropdown.

Expected:
- Author created and selectable without page reload.

#### TC-004: Validation – Invalid Publication Year

Related: FR-B6

Steps:
1. Enter year below 1600 or above 2099.

Expected:
- Validation error; book not saved.

#### TC-005: Validation – Missing Required Fields

Related: FR-B6

Steps:
1. Submit empty form.

Expected:
- Required field errors for Title, PublicationYear, ConditionId, StatusId.

#### TC-006: Edit Existing Book

Related: FR-B1

Preconditions:
- Book exists.

Steps:
1. Edit title, condition, price.

Expected:
- Updates persisted.

#### TC-007: Delete Book Without Sales

Related: FR-B4

Preconditions:
- Book not sold.

Steps:
1. Delete the book.

Expected:
- Book removed; BookAuthor link removed by cascade.

#### TC-008: Prevent Delete Book With Sales

Related: FR-B4

Preconditions:
- Book has Sale record.

Steps:
1. Attempt delete.

Expected:
- Deletion blocked; error displayed.


### 2. Author Management

#### TC-020: Create Author

Related: FR-A1

Steps:
1. Create author with valid data.

Expected:
- Author saved.

#### TC-021: Edit Author

Related: FR-A1

Preconditions:
- Author exists.

Steps:
1. Edit author bio.

Expected:
- Changes saved.

#### TC-022: Prevent Delete Author With Linked Books

Related: FR-A3

Steps:
1. Delete author used by at least one Book.

Expected:
- Deletion blocked.


### 3. Customer and Delivery Address Management

#### TC-030: Create Customer

Related: FR-C1

Steps:
1. Create customer with FirstName, LastName, Email.

Expected:
- Customer saved; Email unique.

#### TC-031: Edit Customer

Related: FR-C2

Steps:
1. Edit customer email/phone.

Expected:
- Updates saved; uniqueness preserved.

#### TC-032: Create Delivery Address For Customer

Related: FR-C3

Steps:
1. Add address using Country, City, AddressLine1.

Expected:
- DeliveryAddress linked to Customer.

#### TC-033: Delete Customer With Addresses

Related: FR-C3

Steps:
1. Delete a customer with addresses.

Expected:
- Customer and addresses removed (cascade).

#### TC-034: View Customer Purchase History

Related: FR-C4

Steps:
1. Customer → Details.

Expected:
- Orders displayed; each with items, status, amounts.


### 4. Employee, Position, and RBAC Management

#### TC-040: Create Employee

Related: FR-E1

Steps:
1. Manager → Employees → Create.

Expected:
- Employee saved with IsActive default true.

#### TC-041: Edit Employee

Related: FR-E1

Steps:
1. Change name/comment.

Expected:
- Saved.

#### TC-042: Deactivate Employee

Related: FR-E2

Steps:
1. Set IsActive = false.

Expected:
- Employee inactive; cannot be assigned to new Orders.

#### TC-043: Assign Position to Employee

Related: FR-E3

Steps:
1. Assign “Store Manager” or “Sales Associate”.

Expected:
- PositionHistory entry created; previous closed if any.

#### TC-044: Auto-Enforce Identity ↔ Employee Link

Related: FR-E4

Preconditions:
- Identity user exists.

Steps:
1. Link Employee to IdentityUser in UserManagement.

Expected:
- One-to-one constraint enforced; previous link removed.


### 5. Order and Sales Workflow

#### TC-050: Create New Order (Pickup)

Related: FR-O1

Steps:
1. Select Customer, Employee.
2. Add one available Book.
3. Set PaymentMethod = Cash.
4. Save.

Expected:
- Order saved; Sales created; Book → “Sold”.

#### TC-051: Create Order With Multiple Books

Related: FR-O1, FR-O2

Steps:
1. Add two books.

Expected:
- Two Sale records; total computed correctly.

#### TC-052: Prevent Order With Unavailable Book

Related: FR-O2

Steps:
1. Add Book with Status not Available.

Expected:
- Operation blocked.

#### TC-053: Register Payment

Related: FR-O3

Steps:
1. Set PaymentMethod and submit.

Expected:
- PaymentDate set; OrderStatus transitions consistent.

#### TC-054: Change Order Status (New → Processing → Shipped → Delivered)

Related: FR-O4

Steps:
1. Move through allowed transitions.

Expected:
- Each transition allowed; UI enforces valid steps.

#### TC-055: Prevent Delivery Before Payment

Related: FR-O4

Steps:
1. Set status to Delivered with PaymentDate null.

Expected:
- Error; update blocked.

#### TC-056: Cancel Order

Related: FR-O5

Preconditions:
- Order exists; user is Manager or owner Salesperson.

Steps:
1. Click Cancel; confirm.

Expected:
- OrderStatus becomes “Cancelled”; books revert to “Available”; audit recorded.

#### TC-057: Prevent Cancel By Unauthorized User

Related: FR-AC2

Steps:
1. Sales attempts to cancel another employee’s order.

Expected:
- Access denied.

#### TC-058: Prevent Delete Order With Sales

Related: FR-O6

Steps:
1. Attempt delete order that has child Sales.

Expected:
- Delete blocked unless cascade conditions satisfied per config.


### 6. Lookup Tables, Conditions, Statuses

#### TC-070: Validate Book Conditions Seeded

Related: FR-B3

Steps:
1. Navigate to dropdowns.

Expected:
- “Excellent”, “Very Good”, “Good”, “Fair”, “Poor” available.

#### TC-071: Validate Book Statuses Seeded

Related: FR-B3

Expected:
- Available / Reserved / Sold / Archived.

#### TC-072: Validate Payment Methods

Related: FR-O3

Expected:
- “Cash”, “Credit Card” active; others inactive.


### 7. Data Validation Rules

#### TC-080: Required Fields Enforcement

Related: FR-B6, FR-C2

Steps:
1. Submit empty forms for Book/Customer.

Expected:
- Required field errors.

#### TC-081: Email Uniqueness

Related: FR-C2

Steps:
1. Create customer with duplicate email.

Expected:
- Unique email violation.

#### TC-082: Phone and Email Format Validation

Related: FR-C2

Steps:
1. Enter invalid formats.

Expected:
- Validation error.

#### TC-083: Price Format and Precision

Related: FR-B6

Steps:
1. Enter price with >2 decimals.

Expected:
- Validation error.


### 8. Authorization and Security

#### TC-090: Anonymous User Cannot Access Any Protected Page

Related: Security-Req-AC1

Steps:
1. Visit /Books, /Orders, /Employees.

Expected:
- Redirect to Login.

#### TC-091: Sales Cannot Access Employees

Related: FR-AC2

Steps:
1. Sales user opens /Employees.

Expected:
- 403 or AccessDenied.

#### TC-092: Sales Cannot Edit Books

Related: FR-AC3

Steps:
1. Sales user opens /Books/Edit/1.

Expected:
- Denied.

#### TC-093: Manager Has Full Access

Related: FR-AC3

Steps:
1. Manager navigates to all modules.

Expected:
- Access granted.

#### TC-094: Unlinked Identity User Can Log In but Lacks Permissions

Steps:
1. Login as unlinked@example.com.

Expected:
- Only limited navigation; protected pages denied.


### 9. Audit Logging

#### TC-100: Audit – Sale Creation Logged

Related: NonFunctional-Audit

Steps:
1. Create an order with sales.

Expected:
- SalesAuditLog entry created with correct fields.

#### TC-101: Audit – Sale Update Logged

Steps:
1. Modify sale or order affecting Sale entries.

Expected:
- Before/after values logged.

#### TC-102: Audit – Capture User Identity

Steps:
1. Perform sale as Manager/Sales.

Expected:
- Audit record includes UserID, timestamp, operation.

