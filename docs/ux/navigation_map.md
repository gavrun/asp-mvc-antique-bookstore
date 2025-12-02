# Navigation Map – Antique Bookstore

## Introduction

This document describes the main navigation structure of the Antique Bookstore system.  
It is used as a UX reference for how users move between key pages.

## Navigation

Top Navigation bar (left side):

- **Home**
- **Inventory**
  - **Authors**
  - **Books Catalog**
  - Add New Book
- **Orders**
  - Order List
  - Create New Order
- **Customers**
  - Customer List
  - Add New Customer
- **Staff** 
  - **User Management**
  - **mployee Management**
  - **Audit**

Top Navigation bar (right side):

- When not authenticated:
  - **Register**
  - **Login**
- When authenticated:
  - **Manage Account**
  - **Logout**

Footer:

- **Privacy** 

## Pages Hierarchy

High-level hierarchy of pages and sub-pages:

```
Home
 ├── Login
 ├── Register
 ├── Pending Activation Page
 ├── Dashboard
 └── Privacy Policy

Inventory
 ├── Authors
 |    ├── Authors Details
 |    ├── Create Author
 |    └── Edit Authors
 └── Book Catalog
      ├── Book Details
      ├── Create Book
      └── Edit Book

Orders
 └── Orders List
      ├── Order Details
      ├── Create Order
      └── Edit Order

Customers
 └── Customer List
      ├── Customer Details
      ├── Create Customer
      ├── Edit Customer
      └── Manage Delivery Addresses
           ├── Create Address
           └── Edit Address

Staff
 ├── User Management
 │    └── Sync/Assign/Remove Identity Role to Employee
 ├── Employee Management
 |    ├── Employee Details
 |    ├── Create Employee
 |    ├── Edit Employee
 |    ├── Assign Position
 |    └── Activate/Deactivate Employee
 └── Audit Log
      ├── User Filter
      └── Export to CSV

Account (Identity)
 ├── Manage Account 
 |    ├── Profile
 |    ├── Email
 |    ├── Profile
 |    ├── Password
 |    ├── Two-factor authentication
 |    └── Personal data
 └── Logout
```
