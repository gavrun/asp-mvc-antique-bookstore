# Context Diagram - Antique Bookstore

## Introduction

This document provides the diagram which reflects the external participants of the system, the boundaries of the web application and the main interaction flows between the client, the server part and the data storage system.

## Diagram

```
@startuml

actor "User" as User
note right
 Employee (Manager/Sales)
end note

rectangle "Web Browser" as Browser 
note right
 UI rendered by server
 Razor Views
end note

rectangle "AntiqueBookstore\nASP.NET Core MVC\nWeb Application" as WebApp 
note right
 Business logic
 Authentication & Authorization
end note

database "SQL Server" as DB
note right
App Database
Identity
end note

User --> Browser
Browser --> WebApp : HTTPS
WebApp --> DB : SQL

@enduml
```
