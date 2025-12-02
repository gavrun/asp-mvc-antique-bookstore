# Threat Model — Antique Bookstore

## 1. Introduction

This document provides a threat model for the Antique Bookstore system and identifies primary security threats, attack vectors, and mitigation measures based on the system’s business logic, data sensitivity, and internal operational context.

## 2. System Scope

The following system components are in scope:

- Web application and UI controllers
- Authentication and authorization subsystem
- SQL database and EF Core data layer
- Local file storage (book images)
- Internal network environment and application configuration

Key assets:

- Book inventory and unique copy identifiers
- Author, customer, and employee personal data
- Order, payment, and sales records
- User accounts, roles, and access levels
- Audit logs and operational metadata

## 3. Actors and Threat Sources

### 3.1 Internal Sources

**Manager / Assistant Manager** — privileged roles; risk of misuse or accidental changes

**Salesperson** — limited role; possible unauthorized access attempts

**IT administrator** — infrastructure-level access

### 3.2 External Sources

Unauthorized individuals with physical access to internal machines

Compromised staff workstations

Network intruders in case of insufficient isolation

## 4. Attack Surfaces

Web UI endpoints (CRUD operations for catalog, customers, employees, orders)

Authentication forms and session cookies

Role-based access checks in controllers and services

Database operations and migrations

Local file uploads (images)

Application configuration and deployment environment

## 5. Threat Analysis (STRIDE)

**Spoofing**

- Use of another employee’s account
- Session theft on shared machines.

Mitigations: authentication, secure session cookies, account deactivation.

**Tampering**

- Unauthorized updates to books, orders, or employee data.

Mitigations: RBAC, business rule validation, DB constraints, audit logs.

**Repudiation**

- Denial of changes performed by a user.

Mitigations: audit logging with timestamps and user identity.

**Information Disclosure**

- Access to customer or employee PII by unauthorized roles.
- Sensitive data exposure via errors or logs.

Mitigations: role-based filters, sanitized logs, controlled error output.

**Denial of Service**

- Excessive requests or large file uploads.

Mitigations: input validation, file size limits, pagination.

**Elevation of Privilege**

- Attempt to access manager-only functionality via URL manipulation.

Mitigations: explicit authorization attributes, role validation.

## 6. Data-Specific Threats

**Inventory and Books**

- Manipulating book status or price.
- Assigning invalid publication years or identifiers.

Mitigations: enforced workflow rules, data validation.

**Orders and Payments**

- Marking unpaid orders as completed.
- Adding unavailable book copies to orders.

Mitigations: status transition rules, domain invariants.

**Customers and Employees**

- Unauthorized viewing of personal data.
- Modifying employee records by non-privileged roles.

Mitigations: restricted access, RBAC enforcement.

## 7. Threat Severity Assessment

| Threat Category        | Likelihood | Impact | Notes                        |
| ---------------------- | ---------- | ------ | ---------------------------- |
| Unauthorized Access    | Medium     | High   | Affects PII and inventory    |
| Data Tampering         | Medium     | High   | Breaks order/inventory logic |
| Information Disclosure | High       | High   | Customer/employee PII        |
| Repudiation            | Medium     | Medium | Requires auditing            |
| DoS (Internal)         | Low–Medium | Medium | Mostly accidental            |
| Elevation of Privilege | Medium     | High   | Must be strictly prevented   |


## 8. Mitigation Summary

Technical controls:

- ASP.NET Identity authentication
- Strong role-based access control
- Authorization checks in controllers and services
- HTTPS for production environments
- Integrity constraints via EF Core and SQL
- Audit logging for critical modifications

Operational controls:

- Restricted access to production database
- Regular backups
- Deactivation of unused accounts
- Controlled deployment environment

## 9. Residual Risks

- Intentional misuse of privileges by authorized employees
- Physical access to unattended workstations
- Password sharing or poor security practices among staff

These risks require operational policies rather than technical controls.

## 10. Future Considerations

Multi-factor authentication for privileged roles

