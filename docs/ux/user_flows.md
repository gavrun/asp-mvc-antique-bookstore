# User Flows – Antique Bookstore

## Introduction

This document describes the main users flows in the Antique Bookstore system. 
The flows reflect actual system behavior, based on UI screens and implemented business logic.

## Authentication Flow

### Login

1. User navigates to Login page.
2. User enters email and password.
3. System validates credentials.
4. On success:
   - Salesperson to Salesperson Dashboard  
   - Manager to Manager Dashboard
5. On failure: show validation message.

## Dashboard Flow

### Manager Dashboard

1. Manager logs in and redirected to Dashboard.
2. Page displays:
   - Quick Links
   - New Sales Notifications
3. Manager uses this as a starting point for workflow navigation.

### Sales Dashboard


## Books Inventory Flow

### View Book Catalog

1. User opens *Inventory to Catalog*.
2. System displays books as card list: Title, Author, Year, Price.
3. User may select:
   - **Details** Book details page
   - **Edit** 
   - **Delete** 
   - **Add New Book** 

### Add or Edit Book

1. User opens *Add New Book* or *Edit*.
2. User fills: Title, Authors, Publication Year, Prices, Condition, Status, Cover.
3. System validates required fields.
4. Changes saved to database.

## Orders Flow

### Create New Order

1. User selects *Orders to Create New Order*.
2. User selects:
   - Customer
   - Sales Rep (auto-filled by logged-in user unless Manager)
   - Delivery Address (optional)
   - Books (multiple)
3. System calculates total.
4. User selects Payment Method.
5. System sets Order Status to *New*.

### View and Edit Orders 

1. User navigates to *Orders* list.
2. System shows: Order ID, Customer, Sales Rep, Status, Total.
3. User may open *Details*:
   - Customer and Delivery block
   - Order Information block
   - List of Sold Items
4. Manager may:
   - Change Status
   - Edit Payment Date
   - Add/remove items
5. Sales Rep may:
   - Update order status only if permitted

## Customer Management Flow

### View Customers

1. User opens *Customers*.
2. System shows list: Name, Phone, Active state.

### Customer Details

1. User opens customer record.
2. System displays:
   - Personal information
   - Delivery addresses (optional)

### Add or Edit Customer

1. User clicks *Create New Customer* or *Edit*.
2. System saves updated info.

## Employee and App User Access Flow

### View Employees

1. Manager opens *Staff to Employees*.
2. System shows: First/Last Name, Current Position, Level, Active.

### Manage Positions

1. Manager sees table of Roles and Descriptions.
2. Manager may edit or deactivate an employee.

### Link App User to Employee  

1. Manager opens *User Management*.
2. Manager selects *Sync Role* or *Assign Role*.
3. System links ApplicationUser to Employee.
4. Position determines access level.

