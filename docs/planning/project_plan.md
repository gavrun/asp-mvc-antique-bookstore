# Project Plan - Antique Bookstore

## 1. Overview

The **Antique Bookstore** system is an internal web application designed to replace paper-based operational processes in a small retail bookstore specializing in rare and antiquarian books.
The system enables staff to manage inventory, authors, customers, employees, orders, and sales in a centralized, secure manner. It also provides auditing, role-based access control, and structured workflows for order fulfillment.

This plan defines the overall **software development lifecycle (SDLC)** for the project, the **methodology**, the **phases**, and how the implementation planned to be executed from inception through deployment and maintenance.

The document serves as an umbrella plan for the entire project.

## 2. Scope

### **Included**

* Internal web application for store staff
* Inventory and catalog management
* Author, customer, and employee management
* Order creation, processing, and delivery status tracking
* Sales tracking and discount events
* Role-based access control using Identity
* Audit logging for data-critical operations
* Documentation covering project analysis and developement

### **Excluded**

* Public customer-facing website
* Integration with external payment systems
* Advanced analytics or BI modules

## 3. SDLC Methodology

The project adopts a hybrid iterative **SDLC model**, combining but not enforcing:

### Iterative Development (Agile-inspired)

* Small, incremental releases which produces a stable, incremental feature set
* Clear iteration boundaries
* Continuous refinement of technical components

### Structured SDLC Phases

The project follows the traditional SDLC structure:

1. Business Analysis / Discovery
2. Requirements
3. Conceptual Design
4. Logical & Physical Design
5. UI/UX Prototyping
6. Implementation
7. Testing & Validation
8. Deployment & Operations
9. Maintenance & Support

### TDD (Test-Driven Development)

TDD can be applied selectively to **core business rules** to ensure future change-resilience in the most critical logic.

* Books persistence for completed orders
* Order status transitions 
* Sale pricing and discount rules
* etc.

### Unit Testing 

Standard Unit Tests written after implementation used for supporting functionality where needed.

## 4. Development Phases

### 4.1 Business Analysis / Discovery 

Purpose: understand the business problem and define domain boundaries.

Activities:

* Stakeholder identification
* Interviews with store management
* Mapping current paper-based workflows
* Identifying inefficiencies and pain points
* Establishing business goals and constraints
* Actor and role definition (Manager, Assistant, Salesperson)

Outputs:

* Business Scenario
* Personas
* User Goals
* High-level success criteria

### 4.2 Requirements 

Purpose: define system capabilities and constraints.

Activities:

* Draft functional and non-functional requirements
* Define business rules and validations
* Access control and security rules
* Define API needs 
* Organize requirements into MVP vs. extended features

Outputs:

* Software Requirements Specification (SRS)
* Functional Requirements
* Non-Functional Requirements
* Security Requirements
* Threat Model
* API Requirements

### 4.3 Conceptual Design 

Purpose: define the solution conceptually, independent of technology.

Activities:

* Identify key entities (Book, Author, Order, Sale)
* Define conceptual relationships and constraints
* Define user flows and activity diagrams
* Define top-level architecture (presentation → domain → data)
* Define use cases for major workflows

Outputs:

* Conceptual Model
* Conceptual Diagram
* Architecture Overview
* User Flows
* Navigation Map

### 4.4 Logical and Physical Design 

Purpose: refine conceptual structures into technical artifacts.

Activities:

* Create class diagrams for domain entities
* Define database schema and relationships
* Produce DBML/ERD diagrams
* Define sequence diagrams for workflows
* Define service and controller boundaries
* Specify data validation rules

Outputs:

* Class Diagram
* Sequence Diagrams
* ERD (logical & physical)
* DBML schema
* API reference

### 4.5 UI/UX Design (Prototyping)

Purpose: define layout, structure, and interaction patterns.

Activities:

* Build wireframes for all pages
* Define data entry flows and modal interactions
* Define navigation structure
* Establish styling guidelines and layout consistency
* Validate designs with stakeholders

Outputs:

* Wireframes
* UI Style Guide
* Interaction Rules
* Prototyped pages/screenshots

### 4.6 Implementation

Purpose: produce working, integrated code.

Activities:

* Project scaffolding and environment setup
* Implementation of Identity and access control
* Development of domain model and EF Core mapping
* Implementation of controllers and Razor pages
* Integration of file storage and audit logging
* Refactoring and optimization

Outputs:

* Functioning application codebase
* Automated tests
* Integrated modules for system testing

### 4.7 Testing and Validation

Purpose: verify system correctness and reliability.

Activities:

* Unit and integration tests (as needed)
* Manual UI and workflow validation
* Validation against SRS and acceptance criteria

Outputs:

* Test Plan
* Test Cases
* Test Reports
* Bug Fixes
* Test Data

### 4.8 Deployment / Release / Operations

Purpose: prepare the solution for real-world use.

Activities:

* Deployment environment preparation
* CI/CD pipeline setup
* Applying database migrations
* Release notes preparation
* Monitoring and logging strategy
* Backup and restoration plan

Outputs:

* Deployment Guide
* CI/CD Pipeline description
* Release Notes
* Monitoring Plan
* Backup & Recovery Strategy

### 4.9 Maintenance / Support

Purpose: support ongoing operation and improvement.

Activities:

* Bug fixes and minor enhancements
* System monitoring
* Periodic data cleanup
* Documentation updates
* Planning for future iterations

Outputs:

* Support Policy
* Maintenance Plan
* Troubleshooting Guide

## 5. Milestones and Timeline

1. Discovery and Requirements
2. Conceptual and Logical Design
3. Implementation Phases (Iterations)
4. Testing and Validation
5. Deployment 
6. Maintenance

A more detailed iteration plan is maintained in `development_plan_tasks.md`.

## 7. Deliverables

### Per Phase:

* Analysis Documents (Business Scenario, Personas, User Stories)
* Requirements Documents (SRS, Functional/Non-functional Requirements)
* Conceptual and Logical Designs (Diagrams, Models)
* UI/UX Deliverables (Wireframes, Style Guide)
* Implementation Artifacts (Code, Tests, Configurations)
* Test Deliverables (Test Plan, Cases, Reports)
* Deployment Documents (Guides, Pipeline, Release Notes)
* Maintenance Documents (Support Policy, Troubleshooting)

## 8. Risks and Mitigations

| Risk                       | Mitigation                                       |
| -------------------------- | ------------------------------------------------ |
| Requirements misalignment  | Frequent stakeholder feedback                    |
| Insufficient test coverage | Tests on core business first, add unit tests     |
| Security vulnerabilities   | RBAC, Identity integration, threat model         |
| Data inconsistencies       | Strong EF Core constraints and auditing          |
| Scope expansion            | Iterative re-prioritization and phase boundaries |

## 9. Acceptance Criteria

The solution is considered complete when:

* All required features in SRS are implemented
* All core tests pass
* CRUD flows for all entities function correctly
* Role-based access control is enforced correctly
* Audit logging captures critical data changes
* UI matches wireframes and usability guidelines
* Database schema matches designed ERD
* Application is deployable through documented process
* User acceptance testing (UAT) confirms workflows

## Appendix

* Glossary
