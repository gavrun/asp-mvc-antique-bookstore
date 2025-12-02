# Wireframe – Antique Bookstore

## Introduction

This document provides low-fidelity ASCII wireframes representing the key user interfaces of the Antique Bookstore system.

The goal of this document is to illustrate the structure, layout, and primary interaction elements of each page without focusing on visual design, colors, typography, or final styling. 

These wireframes serve as an early UX communication tool and a reference for UI implementation

## Page

```
+--------------------------------------------------------+
|                                                        |
+--------------------------------------------------------+
|                                                        |
|                                                        |
|                                                        |
+--------------------------------------------------------+
|                                                        |
+--------------------------------------------------------+
```

## Home Page

```
+--------------------------------------------------------+
| Antique Bookstore                                      |
| Home | Inventory | Orders | Customers | Staff | Logout |
+--------------------------------------------------------+
|          Welcome to the Antique Bookstore              |
|     Management system where we sell rare books.        |
|                 [Login] or [Register]                  |
+--------------------------------------------------------+
|                                                        |
+--------------------------------------------------------+
```

## Login/Register Page

```
+------------------------+    +--------------------------+
|  Log in (local)        |    | External login           |
|  Email    [_________]  |    | No providers configured  |
|  Password [_________]  |    |                          |
|  [ ] Remember me       |    |                          |
|  [Log in]              |    |                          |
+------------------------+    +--------------------------+
```

## Dashboard Page

```
+--------------------------------------------------------+
| Antique Bookstore                                      |
| Home | Inventory | Orders | Customers | Staff | Logout |
+--------------------------------------------------------+
|                  Manager Dashboard                     |
|                                                        |
+--------------------------------------------------------+
| Quick Actions      |  Sales Notifications              |
| * Link             |                                   |
| * Link             |                                   |
+--------------------------------------------------------+
|                                                        |
+--------------------------------------------------------+
```

## Book Catalog Page

```
+--------------------------------------------------------+
| Antique Bookstore                                      |
| Home | Inventory | Orders | Customers | Staff | Logout |
+--------------------------------------------------------+
|                     Book Catalog                       |
|                                                        |
| [Add New Book]                                         |
|                                                        |
|   [Book Card]  [Book Card]  [Book Card]  [Book Card]   |
|                                                        |
|   [Edit] [Details] [Delete]                            |
|                                                        |
+--------------------------------------------------------+
|                                                        |
+--------------------------------------------------------+
```

## Add New Book Page + Add New Author (modal)

```
+--------------------------------------------------------+
| Antique Bookstore                                      |
| Home | Inventory | Orders | Customers | Staff | Logout |
+--------------------------------------------------------+
|                     Book Details                       |
|                                                        |  +--------------------------+
| Title     [_________]               | [Considerations] |  |       Add New Author     |
| Publisher [_________]               |                  |  |                          |
| Price     [_________]               |                  |  |  First Name [_________]  |
|                                                        |  |  Last Name  [_________]  |
| Author(s):                                             |  |  Bio        [_________]  |
| +---------------+                                      |  |                          |
| |               |                                      |  |                          |
| |  Author Name  |  [Add New Author]                    |  |      [Cancel][Save]      |
| +---------------+                                      |  |                          |
|                                                        |  +--------------------------+
| Cover Image: [Choose File]                             |
+--------------------------------------------------------+
|                                                        |
+--------------------------------------------------------+
```

## Orders Page

```
+--------------------------------------------------------+
| Antique Bookstore                                      |
| Home | Inventory | Orders | Customers | Staff | Logout |
+--------------------------------------------------------+
|                        Orders                          |
|                                                        |
| [Create New Order]                                     |
|                                                        |
|  ID | Date | Customer | Sales Rep | Status | Total     |
|  1  | ...  | Name     | Name      | New    | $1000     |
|  2  | ...  | Name     | Name      | Proc   | $3000     |
|                                                        |
+--------------------------------------------------------+
|                                                        |
+--------------------------------------------------------+
```

## Order Details Page

```
+--------------------------------------------------------+
| Antique Bookstore                                      |
| Home | Inventory | Orders | Customers | Staff | Logout |
+--------------------------------------------------------+
|                    Order Details                       |
|                                                        |
| Order Info         |     Customer & Delivery           |
| ID, Date           |     Customer, Sales Rep, Address  |
| Status, Amount     |     Delivery Date                 |
+--------------------------------------------------------+
| Items in this Order                                    |
| Book | Price | Discount | [View Book]                  |
|                                                        |
+--------------------------------------------------------+
|                                                        |
+--------------------------------------------------------+
```

## User Management Page

```
+--------------------------------------------------------+
| Antique Bookstore                                      |
| Home | Inventory | Orders | Customers | Staff | Logout |
+--------------------------------------------------------+
|                   User Management                      |
|                                                        |
| Username | Email | Role  | Linked To | Actions         |
| manager@ | ...   | Mngr  | Name      | [Sync][Remove]  |
| sales@   | ...   | Sales | Name      | [Sync][Remove]  |
| unlinked | ...   | NoRole| —         | [Assign]        |
|                                                        |
+--------------------------------------------------------+
|                                                        |
+--------------------------------------------------------+
```

## Employee Management Page

```
+--------------------------------------------------------+
| Antique Bookstore                                      |
| Home | Inventory | Orders | Customers | Staff | Logout |
+--------------------------------------------------------+
|                  Employee Management                   |
|                                                        |
| [Create New Employee]          [ Role | Description ]  |
|                                                        |
|  First | Last | Position | Level | Active | Actions    |
|  Nm    | Lnm  | Manager  | Mngr  | Yes    | Edit/Deac  |
|  Nm    | Lnm  | SaleAss  | Sales | Yes    | Edit/Deac  |
|                                                        |
+--------------------------------------------------------+
|                                                        |
+--------------------------------------------------------+
```
