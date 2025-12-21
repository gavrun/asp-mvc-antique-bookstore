# Maintenance Plan – Antique Bookstore

## 1. Overview

This document defines how the **AntiqueBookstore** application is maintained after initial delivery, including updates, fixes, and ongoing care of data and configuration.

## 2. Scope

In scope:
- Application codebase
- Database schema and data
- Identity users/roles
- Uploaded images (local file storage)
- Project documentation updates (release notes, user guide, policies)

Out of scope:
- End-user training and operational troubleshooting steps
- Active production monitoring/alerting implementation 

## 3. Maintenance objective

- Keep the application working as expected after changes.
- Reduce risk of data loss and regressions.
- Apply security updates and dependency fixes regularly.
- Maintain documentation consistency with the implemented system.

## 4. Roles and responsibilities

Maintainer / Developer:
  - Implements fixes and improvements
  - Reviews and merges changes
  - Executes releases (manual)
  - Runs tests before release

Reviewer (optional):
  - Reviews pull requests and verifies documentation updates

Operator (non-local deployments, optional):
  - Performs deployment steps
  - Ensures backups exist and are restorable

## 5. Maintenance types

### 5.1 Corrective maintenance (bug fixes)

- Fix defects found during testing or usage.
- Update documentation.
- Add/adjust automated tests.

### 5.2 Adaptive maintenance (environment/dependency changes)

- Update .NET / NuGet dependencies.
- Update database connection/configuration for new environments.

### 5.3 Perfective maintenance (minor improvements)

- Small UI/UX improvements, refactoring, performance cleanups.
- Documentation improvements for clarity and completeness.

### 5.4 Preventive maintenance (risk reduction)

- Dependency patching schedule
- Backup verification and restore checks
- Periodic review of security-related settings

## 6. Planned maintenance schedule

### Weekly

- Review open issues/defects and prioritize.
- Confirm backups are being created.

### Monthly

- Run a restore test (database + uploads) and record result (date + outcome).
- Review dependencies and apply patch-level updates if safe.
- Smoke-test main flows after updates.

### Quarterly

- Review documentation set for consistency.
- Review and update support policy and maintenance plan if scope changes.

## 7. Change management

### 7.1 Change request

Every maintenance change should have:
- Summary: what is changing and why
- Risk: low/medium/high
- Impact: which area (books/authors/customers/orders/audit/auth)
- Tests: what was run (unit/integration/manual smoke)
- Docs updated: list of docs changed 

### 7.2 Branching and merging 

- Work in a feature/maintenance branch.
- Merge only after:
  - build succeeds
  - tests pass
  - docs updated

## 8. Testing requirements 

Minimum tests after maintenance before a release:
- Run automated tests.
- Perform a short manual check:
  - application starts
  - login works
  - pages load (DB connectivity)
  - basic navigation works
  - uploaded images displayed

## 9. Database maintenance

- Schema changes should be made via EF Core migrations.
- Before applying migrations:
  - ensure a recent database backup exists
- After applying migrations:
  - validate the application starts and key pages load

## 10. Data maintenance

- Do not delete historical sales/audit records unless there is an explicit data retention requirement.
- Cleanup scripts must be documented and tested on a copy of the database first.

## 11. Security 

- Track dependency updates (NuGet) regularly.
- Apply security patches.
- Confirm authentication/authorization flows still behave as expected after updates.

## 12. Backup and restore

This maintenance plan assumes:
- Database is backed up at least daily
- Upload folder is backed up daily
- Restore tests are performed monthly

## 13. Documentation 

Update relevant documentation when system behavior altered in the same change cycle (or same release).

## 14. End-of-life (EOL)

If maintenance stops:
- Document final state and known limitations.
- Preserve a final backup (database + uploads).
- Tag the repository with a final version and store release artifacts.

