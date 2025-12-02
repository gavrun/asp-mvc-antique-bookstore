# Test Execution Report – Antique Bookstore

## 1. Report Summary

| Field                | Value                                  |
|----------------------|------------------------------------------|
| Report ID            | TER-YYYYMMDD-NN                         |
| Execution Cycle      | (e.g., Sprint 3 System Test)            |
| Date Range           | [Start Date] – [End Date]               |
| Environment          | Development / Test / Staging            |
| Application Version  | [Git commit / Tag]                      |
| Prepared By          | [Name]                                  |
| Reviewed By          | [Name]                                  |

## 2. Scope of Testing

Describes the tested areas of the application:

- Catalog and Book Management  
- Author Management  
- Customer & Delivery Address Management  
- Employee & Position Management  
- Order and Sales Workflow  
- RBAC, Security, Authorization  
- Validation Rules  
- Audit Logging  
- Lookup Tables  

References the Test Plan ID and Test Cases versions.

## 3. Test Environment

| Component               | Details                                                  |
|-------------------------|----------------------------------------------------------|
| OS                      | Windows                                                  |
| .NET Runtime            | .NET 8 SDK                                               |
| Database                | SQL Server LocalDB / SQL Server Instance                 |
| Seed Data Applied       | Yes / No                                                 |
| Browser                 | Chrome / Edge                                            |
| File Storage            | wwwroot/images (local filesystem)                        |

Includes any deviations from planned environment.

## 4. Test Execution Overview

| Metric                          | Value |
|---------------------------------|-------|
| Total Test Cases                |       |
| Passed                          |       |
| Failed                          |       |
| Blocked                         |       |
| Not Executed                    |       |
| Execution Completion Percentage |       |

Short narrative:

- Summary of execution.
- Major findings.
- Anything impacting test completeness.

## 5. Detailed Test Results

### 5.1 Passed Test Cases

Lists all passed cases in compact form:

| TC ID   | Title                                  | Notes                |
|---------|----------------------------------------|----------------------|
| TC-001  | Create New Book With Single Author     | Passed as expected   |
| TC-050  | Create New Order (Pickup)              |                      |
| …       |                                        |                      |

### 5.2 Failed Test Cases

For each failed case, includes:

| Field            | Value                            |
|------------------|----------------------------------|
| Test Case ID     | TC-XXX                           |
| Title            |                                  |
| Expected Result  |                                  |
| Actual Result    |                                  |
| Severity         | Critical / High / Medium / Low   |
| Blocking?        | Yes / No                         |
| Screenshot/Log   | Path or reference                |
| Notes            |                                  |


### 5.3 Blocked Test Cases

| Test Case ID | Blocked Due To (dependency, environment issue, etc.) |
|--------------|------------------------------------------------------|
| TC-0XX       | e.g. DB connection failure                           |
| TC-0YY       | e.g. feature incomplete                              |

### 5.4 Not Executed

Lists cases intentionally deferred.

| Test Case ID | Reason                    |
|--------------|---------------------------|
| TC-0ZZ       | Feature under development |

## 6. Defect Summary

Summaries of defects discovered during execution.

| Defect ID | Severity | Description                        | Status  | Linked TC(s) |
|-----------|----------|------------------------------------|---------|--------------|
| BUG-001   | High     | Wrong status transition on Payment | Open    | TC-054       |
| BUG-002   | Medium   | Email uniqueness not enforced      | Fixed   | TC-081       |

References to the bug tracker system ID (if exists).

## 7. Risks and Issues Observed

Lists any risks that came up during execution:

- Unstable Cancel flow in Orders under concurrent operations.  
- Missing Assistant Manager role logic in RBAC.  
- Audit logging depends on HttpContextAccessor; DI issues possible.  
- Missing automated regression tests for Order lifecycle.
- etc.

## 8. Recommendations

- Fix critical failures prior to UAT. 
- Add automated tests for order status transitions. 
- Strengthen validation coverage for Customer and Book forms. 
- Implement missing RBAC mappings and enforce no-anonymous-access. 
- etc.

## 9. Final Assessment

Application Readiness: 
- Ready / Ready with Reservations / Not Ready

QA Approval:  
- Approved / Conditionally Approved / Rejected

Sign-off:  
- QA Engineer  
- Project Manager  
