# Test Strategy – Antique Bookstore

## 1. Introduction

This document defines the overarching testing strategy for the Antique Bookstore system. 
It describes the testing objectives, scope, levels of testing, quality criteria, and general approach to validating the requirements outlined in the SRS and Functional Requirements.

## 2. Objectives

- Ensure the system satisfies all functional and non-functional requirements.
- Validate correctness of order workflows, inventory rules, and access control.
- Prevent regressions during development.
- Provide measurable evidence of system readiness.

## 3. Scope

### In Scope

- Domain logic validation (books, authors, customers, employees, orders).
- Workflow validation (order creation → payment → delivery).
- Authentication and authorization.
- Database schema correctness and referential integrity.
- UI validation for primary user workflows.

### Out of Scope

- Performance benchmarking beyond basic responsiveness.
- Security penetration testing.
- Integration with external systems (not used in this version).

## 4. Test Levels

### 4.1 Unit Testing

Validates isolated components such as:

- domain rules
- service methods
- EF Core configuration

### 4.2 Integration Testing

Validates:

- controller → service → database flow
- order lifecycle transitions
- identity and role based operations

### 4.3 System Testing

Validates complete business workflows as defined in use cases:

- catalog management
- order processing
- employee administration

### 4.4 User Acceptance Testing (UAT)

Performed by manager-level users. Ensures the application supports realistic operational tasks.

## 5. Test Approach

- Requirements-based test design.
- Positive and negative scenario coverage.
- Use of seeded test data to ensure predictability.
- Automated tests where appropriate.
- Manual tests for UI and workflow validation.

## 6. Quality Criteria

- All critical workflows pass system testing.
- All high-priority defects resolved.
- No blocking issues in inventory/customer/order workflows.
- No unhandled exceptions in logs
- Access control restrictions behave as defined.
- Data integrity preserved under all operations.

## 7. Risks and Mitigation

| Risk Level | Description                                                         | Impact                                                | Mitigation                                                                |
|------------|---------------------------------------------------------------------|-------------------------------------------------------|---------------------------------------------------------------------------|
| High       | Incorrect order status transitions leading to invalid workflows     | Orders may be archived unpaid or blocked incorrectly  | Add state-transition tests; ensure transition rules validated in services |
| High       | Authorization misconfiguration allowing unauthorized data access    | Exposure/modification of sensitive employee data      | Dedicated RBAC test suite; negative-access test cases                     |
| Medium     | Incomplete coverage of multi-author or multi-copy inventory cases   | Incorrect catalog or sale linking                     | Add combinatorial test cases using synthetic data                         |
| Medium     | Seed data inconsistencies between environments                      | Test results unpredictable                            | Standardize test seed set; enforce deterministic DB state                 |
| Low        | UI validation inconsistencies across browsers                       | Minor usability issues                                | Manual UI smoke testing in major browsers                                 |
| Low        | Minor EF Core configuration regressions during refactoring          | Application may compile but behave incorrectly        | Unit tests for entity configuration; integration tests for key paths      |

## 8. Deliverables

- Test Plan  
- Test Cases  
- Test Data  
- Test Execution Reports  
- Defect/Bug Reports

