# asp-mvc-antique-bookstore

## Overview

**"Antique Bookstore"** is a study project that demonstrates full cycle for development of a web application.

The project is originally designed for a fictitious company that sells antique books based on a note which a store owner made on a piece of paper.
A simple web application that allows a store staff to maintain a catalog of antique books, as well as placing and managing orders, to replace oldfashioned index cards and lists for orders history, etc.

The goal here is to learn how software development works.

## SDLC roadmap (product documentation)


## Project tructure (solution folder)


## Steps to evaluate application

1. Clone repository.

```
git clone https://github.com/gavrun/asp-mvc-antique-bookstore.git
```

2. Launch Visual Studio.

3. Verify database connection (appsettings.json) configuration "ConnectionStrings".

```
/AntiqueBookstore/appsettings.json
{
  "ConnectionStrings": {
    "DefaultConnection": 
    }
}
```

4. Restore dependencies and rebuild solution.

```
dotnet restore
```

5. Run application.

6. It intended to runs migration automatically and create db schema. Optionally, apply database migrations (press 'Apply Migrations' button), or run migration manually.

``` 
dotnet tool install --global dotnet-ef
dotnet ef database update
```

7. Application intended to seed database with test data and test user accounts:

```
bookstore manager
UserName "manager@example.com", Password "manager"

sales rep
UserName "sales@example.com", Password "sales"

a new user
UserName "unlinked@example.com", Password "unlinked"
```

8. Login with Manager account.

```
https://localhost:<port>/Identity/Account/Login
```

The `manager` and `sales` already assigned roles by data seeding, but in UI in [User Management] you may still see them as unassigned, just click Assign Role through. 

9. Login with Sales and unlinked accounts.

