# CI/CD Pipeline – Antique Bookstore

## Overview

This document describes a simple a **reference CI/CD pipeline** for the **AntiqueBookstore**  project can be implemented.

Goals:

- Ensure the solution builds on every change.
- Run unit/integration tests automatically.
- Produce a publishable artifact for deployment.
- Provide a minimal manual “release” process aligned with the project documentation.

## Assumptions and constraints

- Application is an ASP.NET Core MVC app.
- Database is SQL Server.

## Triggers

### Continuous Integration (CI)

- Trigger: every push to feature branches and main branch
- Trigger: pull request opened / updated

### Continuous Delivery (CD)

- Trigger: manual 
- Optional trigger: tag-based release

## Pipeline stages

### Stage A - Restore & Build

**Inputs**
- Repository code

**Steps**
- Restore dependencies
- Build solution in `Release`

**Outputs**
- Compiled binaries (intermediate)

**Pass criteria**
- Build succeeds with no compilation errors

### Stage B - Test

**Steps**
- Run all test projects

**Outputs**
- Test results + optional coverage output

**Pass criteria**
- All tests pass

### Stage C - Static checks (optional)

This project does not currently define static analysis rules. 

- Code formatting / linters.
- Security analyzers.
- Dependency vulnerability checks.

### Stage D - Publish

**Steps**
- `dotnet publish` the web project

**Artifact contents**
- Published folder including `wwwroot`
- Version metadata 

**Pass criteria**
- Publish step succeeds and output is archived

### Stage E - Deploy (manual)

For this project, deployment is recommended as a manual step documented in `deployment_guide.md`.

## Versioning and artifacts

Recommended semantic version format for releases `MAJOR.MINOR.PATCH`.

Example:

- `antique-bookstore_<version>_<commit-sha>.zip`

Release notes should be updated in `release_notes.md`

Changelog should be updated in `changelog.md`

## Environment 

This project remains local-only.

- Dev: local developer machine
- Test: pipeline-run environment executing tests
- Prod: optional future target

## Secrets and configuration

This project contains local connection string settings in `appsettings.json`.  

For a CI/CD pipeline, secrets should be provided via pipeline secret storage and injected as environment variables.

## Pipeline mapping (provider-agnostic)

| Stage | Purpose | Typical command |
|------|---------|-----------------|
| Build | compile | `dotnet build -c Release` |
| Test | validate | `dotnet test -c Release` |
| Publish | artifact | `dotnet publish -c Release -o <out>` |
| Deploy | deliver | provider-specific |

Choose CI provider and implement pipeline YAML (GitHub Actions / GitLab CI / Azure DevOps).

