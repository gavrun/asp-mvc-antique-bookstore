# asp-mvc-antique-bookstore

## Overview

**"Antique Bookstore"** is a study project that demonstrates full development cycle of a web application.

The project is originally designed for a fictitious company that sells antique books based on a note which a store owner made on a piece of paper.
A simple web application that allows the store staff to maintain a catalog of antique books, as well as placing and managing orders, to replace old-fashioned index cards and lists for orders history, etc.

The goal here is to learn how software development works.


## SDLC roadmap (product documentation)

### 1. Business Analysis / Discovery 

This stage describes the problem, actors, goals, early assumptions, and overall business context.

```
\docs
  ├── \analysis
  |  ├── \business_scenario.md
  |  ├── \functional_requirements.md
  |  ├── \requirements_srs.md
  |  ├── \use_case_diagram.md
  |  └── \user_stories.md
  └── \ux
      └── \personas.md
```

### 2. Requirements 

This stage formalizes and freezes requirements (functional, non-functional). Security requirements and API specifications belong here.

```
\docs
  ├── \analysis
  |  ├── \business_scenario.md
  |  ├── \functional_requirements.md
  |  └── \requirements_srs.md 
  ├── \legal
  |  ├── \privacy_policy.md
  |  ├── \terms_of_service.md
  |  └── \service_level_agreement.md
  ├── \api
  │  └── \api_requirements.md 
  └── \security
     ├── \security_requirements.md 
     ├── \data_protection_policy.md
     └── \threat_model.md 
```

### 3. Conceptual Design 

At this stage conceptual architecture, conceptual domain model, UX flows, and high-level interaction logic are described.

```
\docs
  ├── \architecture
  │  └── \architecture_overview.md
  ├── \data_model
  │  ├── \conceptual_model.md
  │  └── \conceptual_diagram.md
  └── \ux
     ├── \navigation_map.md
     ├── \user_flows.md
     ├── \usability_interaction_rules.md
     └── \activity_diagram.md
```

### 4. Logical and Physical Design 

This stage refines the conceptual model into detailed logical structures (class diagrams, sequence diagrams, service interactions) and physical structures (database schema, keys, relationships, DBML, ERD diagrams). 

```
\docs
  ├── \architecture
  |  ├── component_diagram.md
  |  ├── context_diagram.md
  │  └── sequence_diagram.md
  ├── \api
  │  └── \api_reference.md
  ├── \data_model
  │  └── \class_diagram.md
  └── \database_schema
     ├── \database_schema_overview.md
     └── \database_erd_dbml.md
```

### 5. UI/UX Design (Prototyping)

This stage defines the visual structure and interaction patterns of the product through wireframes, sketches, layout diagrams, and early prototypes.

```
\docs
  └── \ui
    ├── \ui_style_guide.md
    └── \wireframes
```

### 6. Implementation 

Highly iterative stage with planning represented by more detailed coding tasks, repository structure, module breakdown, build instructions, and architectural decisions records (ADR).

```
\docs
  └── \planning
    ├── \project_plan.md
    ├── \development_plan.md
    ├── \development_plan_tasks.md
    └── \project_folder_file_tree.txt
```

### 7. Testing and Validation

This stage covers testing strategy, test plans and cases, as well as describes a test data set.

```
\docs
  └── \testing
     ├── \defect_bug_report.md
     ├── \test_cases.md
     ├── \test_data.md
     ├── \test_execution_report.md
     ├── \test_plan.md
     └── \test_strategy.md
```

### 8. Deployment / Release / Delivery / Operations

Deployment and CI/CD documents, monitoring, release notes, and end-user documentation belong here.

```
\docs
  └── \deployment
  |  ├── \environment_setup.md
  |  ├── \deployment_guide.md
  |  ├── \deployment_diagram.md
  |  ├── \ci_cd_pipeline.md
  |  └── \backup_strategy.md
  └── \release
     ├── \release_notes.md
     ├── \changelog.md
     ├── \readme.md
     ├── \user_guide.md
     └── \faq.md
```

### 9. Maintenance / Support

Support policies, troubleshooting documentation, maintenance roadmap live here.

```
\docs
  └── \legal
  |  └── \license.md
  └── \support
     ├── \support_policy.md
     ├── \maintenance_plan.md
     └── \troubleshooting.md
```


## Project structure (solution folder)

```
\AntiqueBookstore
├── \Areas
│   └── \Identity
├── \Controllers
├── \Data
│   ├── \Configurations
│   ├── \Interceptors
│   ├── \Migrations
│   └── \Seed
├── \Domain
│   ├── \Entities
│   ├── \Enums
│   ├── \Exceptions
│   └── \Interfaces
├── \Models
├── \Resources
├── \Properties
├── \Services
├── \Views
│   ├── \Authors
│   ├── \Books
│   ├── \Customers
│   ├── \Home
│   ├── \Orders
│   ├── \Shared
│   └── \UserManagement
└── \wwwroot
    ├── \css
    ├── \images
    │   └── \covers
    ├── \js
    └── \lib
        ├── \bootstrap
        ├── \bootswatch
        ├── \jquery
        ├── \jquery-validation
        └── \jquery-validation-unobtrusive
```


## Steps to evaluate application

1. Clone repository.

```
git clone https://github.com/gavrun/asp-mvc-antique-bookstore.git
```

2. Launch Visual Studio.

3. Verify database connection (appsettings.json) configuration, "ConnectionStrings".

```
\AntiqueBookstore\appsettings.json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=...;Database=...;"
    }
}
```

4. Restore dependencies and rebuild solution.

```
dotnet restore
```

5. Run application in Visual Studio (Ctrl + F5).

6. Application is intended to run migrations automatically in Development mode and to create db schema. Optionally, apply database migrations (press 'Apply Migrations' button), or run migrations manually.

``` 
dotnet tool install --global dotnet-ef
dotnet ef database update
```

7. Application is intended to seed database with test data set and test user accounts:

```
# bookstore manager
UserName "manager@example.com", Password "manager"

# sales rep
UserName "sales@example.com", Password "sales"

# a new user
UserName "unlinked@example.com", Password "unlinked"
```

8. Login with Manager account at first.

```
https://localhost:<port>/Identity/Account/Login
```

The `Manager` and `Sales` already have assigned roles as part of data seeding, but in UI in [User Management] you will see them as unassigned for demonstration, click "Assign Role" for each one. 

9. Login with Sales and unlinked accounts.

10. Close the browser to finish evaluating.
