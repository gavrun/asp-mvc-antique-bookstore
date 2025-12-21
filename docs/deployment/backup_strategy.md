# Backup Strategy – Antique Bookstore

## Overview

This document defines a simple backup strategy for the **AntiqueBookstore** application data.  

Scope:
- SQL Server database used by the application
- Uploaded images stored on disk

Goals:
- Prevent accidental data loss (human error, corrupted database, deletion).
- Support quick restore to a known good state.
- Preserve sales/audit history integrity.
- Preserve uploaded assets when applicable.

## Backup Objectives

### Recovery Point Objective (RPO)

- **Target RPO:** 24 hours  
  Rationale: daily backups are scheduled for both database and uploaded files.

### Recovery Time Objective (RTO)

- **Target RTO:** 1–2 hours (manual restore)  
  Rationale: restore requires a database restore + copying uploads + basic checks.

### Data Retention Policy

- Daily backups: keep **7** copies
- Weekly backups: keep **4** copies (≈ 1 month)

## Backup Schedule

### Database

- **Daily** full backup
- **Weekly** retained “snapshot” backup (a daily backup that is retained longer)

### Uploaded files

- **Daily** copy/backup of the upload folder (`wwwroot/<subfolder>`)

## Storage & Media

### Primary Backup Location

Local backup folder on the same machine:
  - `D:\Backups\AntiqueBookstore\`

### Offsite Backup Location

External drive or cloud storage copy:
  - External HDD/SSD
  - Cloud drive folder synced from `D:\Backups\AntiqueBookstore\`

### Media Type

- Primary: local storage device
- Offsite: external storage device or cloud storage service

### Encryption

- Optional for local-only setup.
- Encrypt backup archives in cloud/offsite (zip with password or storage-level encryption).

### Naming convention

- `AntiqueBookstore_db_YYYY-MM-DD.bak`
- `AntiqueBookstore_uploads_YYYY-MM-DD.zip`

Append a suffix `_full` / `_weekly` for backup type.

## Backup Tools & Software

Manual backup method (provider-agnostic)

**Database backup options:**
- SQL Server Management Studio
- SQL script executed manually:
  - `BACKUP DATABASE ... TO DISK = ...`
- A scheduled job (SQL Server Agent / Windows Task Scheduler calling a script)

**Uploaded files backup options:**
- Zip/copy the uploads `wwwroot/<subfolder>` folder
- Any file-sync tool that copies daily to the target backup location

## Backup Monitoring & Verification

### Monitoring Method

Minimum recommended monitoring (manual):
- After each backup run, confirm backup files exist in the backup folder and have non-zero size.
- Keep a simple backup log file (text) updated with:
  - date/time
  - database backup filename
  - uploads backup filename
  - success/failure

### Verification Frequency

- **Weekly:** verify that new backup files are being produced and retained correctly.
- **Monthly:** perform a restore test.

Recommended restore test validation checklist:
- app starts
- can login
- database data is fetched (e.g., list pages load)
- images display correctly (covers available)

## Recovery Procedure

### Estimated Recovery Time

- **1–2 hours** for a manual restore (database + uploads + smoke checks)

### Database restore

- Restore the database from the selected `.bak`.
- Confirm the application points to the restored DB via `ConnectionStrings:DefaultConnection`.

### Uploaded files restore

- Restore the uploads folder to the same location under `wwwroot/<subfolder>`.
- Confirm the application process has read/write access.

### Post-restore checks

- Start the application.
- Open a list page that reads from the database.
- Open an order-related page (to validate sales/order history).
- Open a book with a cover image (to validate uploads restore).

## Access & Authorization

- Backup files should be writable only by the user/service account that performs backups.
- Restore operations should be limited to an administrator/developer with access to SQL Server restore tools.
- If backups are stored offsite, restrict access to the smallest group needed.

## Audit & Review

### Audit Schedule

- **Monthly:** confirm a restore test was performed and documented (date + result).

### Review Frequency

- **Quarterly** (or after major changes):
  - review retention settings
  - review whether RPO/RTO are still reasonable
  - review whether uploads folder structure has changed

