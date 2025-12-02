# Use Case Diagram - Antique Bookstore

## Introduction

This document provides detailed use case diagrams for the Antique Bookstore system. 
Diagrams expressed using PlantUML activity diagram notation.

The goal of this document is to describe the users' most important goals and interactions between primary roles and with the system before designing the architecture.

## Actors

- **Manager** – full operational and administrative control (book catalog, orders, employees, audit).  
- **Salesperson** – handles daily sales and order processing; limited access to administrative functions.  
- **ApplicationUser** – authenticated login account in the system, mapped to an Employee (Manager or Salesperson).

## Diagram

```
```

## Create New Book with New Author (modal)

This diagram focuses on catalog management, including creating a new book and adding an author on the fly via a modal dialog.

```
@startuml

actor "Manager" as Manager

rectangle "Antique Bookstore" {
  usecase "View Book Catalog" as UC_ViewCatalog
  usecase "Create New Book" as UC_CreateBook
  usecase "Add New Author\n(modal)" as UC_AddAuthor
  usecase "Upload Book Cover" as UC_UploadCover
}

Manager --> UC_ViewCatalog
Manager --> UC_CreateBook
Manager --> UC_AddAuthor
Manager --> UC_UploadCover

UC_CreateBook .> UC_AddAuthor : «includes»
UC_CreateBook .> UC_UploadCover : «includes»

@enduml
```

## Process Customer Order

This diagram covers the core sales workflow: creating and processing customer orders.

```
@startuml

actor "Salesperson" as Sales
actor "Manager" as Manager

rectangle "Antique Bookstore" {
  usecase "Create New Order" as UC_CreateOrder
  usecase "Add Items to Order" as UC_AddItems
  usecase "Register Payment" as UC_RegisterPayment
  usecase "Update Order Status" as UC_UpdateStatus
  usecase "View Order Details" as UC_ViewOrderDetails
}

Sales --> UC_CreateOrder
Sales --> UC_AddItems
Sales --> UC_RegisterPayment
Sales --> UC_ViewOrderDetails
Sales --> UC_UpdateStatus

Manager --> UC_ViewOrderDetails
Manager --> UC_UpdateStatus

UC_CreateOrder .> UC_AddItems : «includes»
UC_RegisterPayment .> UC_UpdateStatus : «triggers»
UC_CreateOrder .> UC_ViewOrderDetails : «extends»

@enduml
```

## Manage Employees and Assign Role to User

This diagram focuses on administrative control of employees, positions/roles, and mapping login accounts to employees.

```
@startuml

actor "Manager" as Manager
actor "ApplicationUser\n(login account)" as AppUser

rectangle "Antique Bookstore" {
  usecase "View Employees" as UC_ViewEmployees
  usecase "Manage Employee Data" as UC_ManageEmployee
  usecase "Manage Positions\nand Roles" as UC_ManagePositions
  usecase "Assign Role to User" as UC_AssignRole
  usecase "Link User to Employee" as UC_LinkUserEmployee
  usecase "Deactivate Employee or Access" as UC_Deactivate
}

Manager --> UC_ViewEmployees
Manager --> UC_ManageEmployee
Manager --> UC_ManagePositions
Manager --> UC_AssignRole
Manager --> UC_LinkUserEmployee
Manager --> UC_Deactivate

AppUser <-- UC_AssignRole
AppUser <-- UC_LinkUserEmployee
AppUser <-- UC_Deactivate

UC_ManageEmployee .> UC_LinkUserEmployee : «extends»
UC_ManagePositions .> UC_AssignRole : «includes»
UC_AssignRole .> UC_Deactivate : «extends»

@enduml
```
