# Deployment Diagram - Antique Bookstore

## Introduction

This document provides the diagram which shows how system is deployed as a server-side web application.

## Diagram 

```
@startuml

node "User PC" as client {
  artifact "Web Browser" as browser
}

node "Application Server\nWindows/Linux\n(.NET 8 Runtime)" as appServer {
  node "Kestrel Web Host" as kestrel {
    artifact "Application\nASP.NET Core MVC" as app
    artifact "appsettings.json\nappsettings.{Environment}.json" as cfg
    folder "wwwroot/\n(images/covers, css, js)" as wwwroot
  }
}

database "SQL Server\nApplication Database" as sql

browser --> app : HTTP/HTTPS
app --> sql : TDS (SQL)
app --> wwwroot : local file I/O\n(store cover images)

@enduml
```
