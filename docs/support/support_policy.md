# Support Policy – Antique Bookstore


## 1. Overview

This document defines the support policy for the **AntiqueBookstore** project. 
The project is designed to simulate realistic SDLC processes.

## 2. Support scope

### Included

- Basic guidance on how to run the application locally (setup and startup)
- Clarification of expected system behavior (based on project documentation)
- Investigation of reproducible bugs discovered during testing
- Minor fixes and improvements when they are small and well-defined

### Not included

- 24/7 production support
- Guaranteed response times for all requests
- Data recovery services beyond restoring from existing backups
- Support for custom environments not covered by project documentation
- Feature requests outside the project’s defined scope

## 3. Supported environments

Primary supported environment:
- Local development environment (localhost)

## 4. Support channels

- Repository issue tracker (primary)
- Direct communication with the maintainer (secondary)

## 5. Severity levels

### Severity 1 - Critical

Definition:
- Application cannot start, or core workflow is blocked completely.

Examples:
- Startup crash
- Database connection prevents any page from loading

### Severity 2 - Major

Definition:
- Major feature works incorrectly but the system can still be used partially.

Examples:
- Order creation fails for some valid input
- Authentication works but role-based access is incorrect

### Severity 3 - Minor

Definition:
- Cosmetic issues or small functional annoyances.

Examples:
- UI layout misalignment
- Non-critical validation message issues

### Severity 4 - Enhancement

Definition:
- Small improvements and non-bug tasks.

Examples:
- Refactoring, minor usability improvements, doc polish

## 6. Response and resolution targets 

A study project targets are best-effort guidelines:

- Severity 1: acknowledge within 1–2 days, aim to fix within 1 week
- Severity 2: acknowledge within 1 week, fix when scheduled
- Severity 3: fix when convenient / bundled into maintenance
- Severity 4: evaluate and schedule

## 7. Support request format

A support request should include:

- Summary of the problem
- Steps to reproduce
- Expected vs actual behavior
- Environment:
  - OS
  - .NET version (if known)
  - Database type (LocalDB vs SQL Server)
- Screenshots/logs output if available

## 8. Bug tracking and documentation

- Bugs should be recorded in documentation.
- Fixes should include:
  - test updates
  - documentation updates
  - release note entry
 
## 9. Data handling & Privacy

- This study project does not collect, store, or process any personal data of users.
- Support activities should avoid collecting any personal data.
- Recommended to use the test dataset or synthetic data.

## 10. End of support

Support ends when:
- the project is archived
- maintenance is explicitly stopped

At end of support, a final snapshot (database + uploads + docs) should be preserved for reference.

