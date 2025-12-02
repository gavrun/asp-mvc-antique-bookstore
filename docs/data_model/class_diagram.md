# Class Diagram - Antique Bookstore

## Introduction

This document provides detailed conceptual class diagrams for the Antique Bookstore domain.
Diagrams are grouped by domain and expressed using PlantUML class diagram notation.

The goal of this document is to clarify entities, main attributes, and relationships before moving to logical/physical data design and implementation.

## Books, Catalog, and Authors

```
@startuml 

class Book {
  +int Id
  +string Title
  +string Publisher
  +int PublicationDate
  +decimal PurchasePrice
  +decimal RecommendedPrice
  +string CoverImagePath
}

class BookCondition {
  +int Id
  +string Name
  +string Description
  +bool IsActive
}

class BookStatus {
  +int Id
  +string Name
  +bool IsActive
}

class Author {
  +int Id
  +string FirstName
  +string LastName
  +int BirthYear
  +int DeathYear
  +string Bio
}

class BookAuthor {
  +int BookId
  +int AuthorId
}

Book "1" --> "1" BookCondition : Condition
Book "1" --> "1" BookStatus    : Status

Book "1" -- "0..*" BookAuthor
Author "1" -- "0..*" BookAuthor

@enduml
```

## Customers and Addresses

```
@startuml 

class Customer {
  +int Id
  +string FirstName
  +string LastName
  +string Email
  +string Phone
  +bool IsActive
  +string Comment
}

class DeliveryAddress {
  +int Id
  +string AddressAlias
  +string Country
  +string City
  +string AddressLine1
  +string AddressLine2
  +string PostalCode
  +string Details
  +int CustomerId
}

class Order {
  +int Id
  +DateTime OrderDate
  +DateTime DeliveryDate
  +DateTime PaymentDate
  +int CustomerId
  +int EmployeeId
  +int DeliveryAddressId
  +int OrderStatusId
  +int PaymentMethodId
  +decimal TotalAmount
}

Customer "1" -- "0..*" Order : Orders
Customer "1" -- "0..*" DeliveryAddress : Addresses

Order "0..1" --> "1" DeliveryAddress : DeliveryAddress

@enduml
```

## Orders and Sales

```
@startuml 

class Order {
  +int Id
  +DateTime OrderDate
  +DateTime DeliveryDate
  +DateTime PaymentDate
  +int CustomerId
  +int EmployeeId
  +int DeliveryAddressId
  +int OrderStatusId
  +int PaymentMethodId
  +decimal TotalAmount
}

class Sale {
  +int Id
  +decimal SalePrice
  +int OrderId
  +int BookId
  +int EventId
}

class SaleEvent {
  +int Id
  +string Name
  +decimal Discount
  +DateTime StartDate
  +DateTime EndDate
}

class OrderStatus {
  +int Id
  +string Name
  +bool IsActive
}

class PaymentMethod {
  +int Id
  +string Name
  +bool IsActive
}

class Book {
  +int Id
  +string Title
}

class Customer {
  +int Id
  +string FirstName
  +string LastName
}

class Employee {
  +int Id
  +string FirstName
  +string LastName
}

class DeliveryAddress {
  +int Id
  +string AddressAlias
}

Order "1" -- "1" Customer        : Customer
Order "1" -- "1" Employee        : Salesperson
Order "0..1" -- "1" DeliveryAddress : DeliveryAddress

Order "1" --> "1" OrderStatus    : Status
Order "1" --> "1" PaymentMethod  : Payment

Order "1" -- "0..*" Sale         : Lines
Sale "1" --> "1" Book            : Book
Sale "0..*" --> "0..1" SaleEvent : Event

SaleEvent "1" -- "0..*" Sale     : Sales

@enduml
```

## Employees, Positions, and Roles

```
@startuml 

class Employee {
  +int Id
  +string FirstName
  +string LastName
  +DateTime HireDate
  +bool IsActive
  +string Comment
  +string ApplicationUserId
}

class PositionHistory {
  +int PromotionId
  +DateTime StartDate
  +DateTime EndDate
  +bool IsActive
  +int EmployeeId
  +int PositionId
}

class Position {
  +int Id
  +string Title
  +WorkSchedule WorkSchedule
  +int LevelId
}

enum WorkSchedule {
  FullTime
  PartTime
}

class Level {
  +int Id
  +string Name
  +string Description
  +bool IsActive
}

class Order {
  +int Id
}

Employee "1" -- "0..*" PositionHistory : PositionHistory
Position "1" -- "0..*" PositionHistory : History
Level "1" -- "0..*" Position           : Positions

Employee "1" -- "0..*" Order           : Orders

@enduml
```

## Application Access and Audit

```
@startuml 

class ApplicationUser {
  +string Id
  +string UserName
  +string Email
  +int EmployeeId
}

class Employee {
  +int Id
  +string FirstName
  +string LastName
}

ApplicationUser "0..1" -- "0..1" Employee : LinkedProfile

class SalesAuditLog {
  +long EventId
  +DateTime Timestamp
  +string TableName
  +string RecordId
  +string Operation
  +string ColumnName
  +string OldValue
  +string NewValue
  +string Login
}

note bottom of SalesAuditLog
  Logical audit of changes across entities.
  References records by TableName and RecordId.
end note

@enduml
```
