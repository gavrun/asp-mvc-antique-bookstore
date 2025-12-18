# Test Execution Report – Antique Bookstore

## Run Metadata

| Field               | Value                         |
| ------------------- | ----------------------------- |
| Test Cycle / Run ID | TR-YYYYMMDD-01                |
| Application Version | (git commit / tag)            |
| Environment         | Local Dev / Test / Staging    |
| DB State            | Fresh migrate+seed / Existing |
| Executor            | (name)                        |
| Start Date          | YYYY-MM-DD                    |
| End Date            | YYYY-MM-DD                    |

## Status Legend

* **PASS** observed behavior fully matches the expected result defined in the test case/specification.
* **FAIL (bug)** the UI/action exists, and you can complete the flow, but the observed behavior contradicts the spec (or clearly intended behavior).
* **FAIL (spec mismatch)** the feature is implemented coherently, but your spec/test expects a different behavior or shape (naming, validation rules, fields, roles, response format, etc.).
* **BLOCKED** you cannot reach or perform the test because the required UI path/action is missing, disabled without explanation, or there is no reachable endpoint/route.
* **NOT RUN** test case has not been executed.

## Overall Progress

| Metric               | Count |
| -------------------- | ----- |
| Total                |       |
| PASS                 |       |
| FAIL (bug)           |       |
| FAIL (spec mismatch) |       |
| BLOCKED              |       |
| NOT RUN              |       |

## Execution Matrix

| Area           | TC ID  | Title                                                        | Status  | Defect ID | Notes / Evidence |
| -------------- | ------ | ------------------------------------------------------------ | ------- | --------- | ---------------- |
| Books          | TC-001 | Create New Book With Single Author                           | NOT RUN |           |                  |
| Books          | TC-002 | Create Book With Multiple Authors                            | NOT RUN |           |                  |
| Books          | TC-003 | Create Book With New Author (Modal)                          | NOT RUN |           |                  |
| Books          | TC-004 | Validation – Invalid Publication Year                        | NOT RUN |           |                  |
| Books          | TC-005 | Validation – Missing Required Fields                         | NOT RUN |           |                  |
| Books          | TC-006 | Edit Existing Book                                           | NOT RUN |           |                  |
| Books          | TC-007 | Delete Book Without Sales                                    | NOT RUN |           |                  |
| Books          | TC-008 | Prevent Delete Book With Sales                               | NOT RUN |           |                  |
| Authors        | TC-020 | Create Author                                                | NOT RUN |           |                  |
| Authors        | TC-021 | Edit Author                                                  | NOT RUN |           |                  |
| Authors        | TC-022 | Prevent Delete Author With Linked Books                      | NOT RUN |           |                  |
| Customers      | TC-030 | Create Customer                                              | NOT RUN |           |                  |
| Customers      | TC-031 | Edit Customer                                                | NOT RUN |           |                  |
| Customers      | TC-032 | Create Delivery Address For Customer                         | NOT RUN |           |                  |
| Customers      | TC-033 | Delete Customer With Addresses                               | NOT RUN |           |                  |
| Customers      | TC-034 | View Customer Purchase History                               | NOT RUN |           |                  |
| Employees/RBAC | TC-040 | Create Employee                                              | NOT RUN |           |                  |
| Employees/RBAC | TC-041 | Edit Employee                                                | NOT RUN |           |                  |
| Employees/RBAC | TC-042 | Deactivate Employee                                          | NOT RUN |           |                  |
| Employees/RBAC | TC-043 | Assign Position to Employee                                  | NOT RUN |           |                  |
| Employees/RBAC | TC-044 | Auto-Enforce Identity to Employee Link                       | NOT RUN |           |                  |
| Orders/Sales   | TC-050 | Create New Order (Pickup)                                    | NOT RUN |           |                  |
| Orders/Sales   | TC-051 | Create Order With Multiple Books                             | NOT RUN |           |                  |
| Orders/Sales   | TC-052 | Prevent Order With Unavailable Book                          | NOT RUN |           |                  |
| Orders/Sales   | TC-053 | Register Payment                                             | NOT RUN |           |                  |
| Orders/Sales   | TC-054 | Change Order Status (New, Processing, Shipped, Delivered)    | NOT RUN |           |                  |
| Orders/Sales   | TC-055 | Prevent Delivery Before Payment                              | NOT RUN |           |                  |
| Orders/Sales   | TC-056 | Cancel Order                                                 | NOT RUN |           |                  |
| Orders/Sales   | TC-057 | Prevent Cancel By Unauthorized User                          | NOT RUN |           |                  |
| Orders/Sales   | TC-058 | Prevent Delete Order With Sales                              | NOT RUN |           |                  |
| Lookup Tables  | TC-070 | Validate Book Conditions Seeded                              | NOT RUN |           |                  |
| Lookup Tables  | TC-071 | Validate Book Statuses Seeded                                | NOT RUN |           |                  |
| Lookup Tables  | TC-072 | Validate Payment Methods                                     | NOT RUN |           |                  |
| Validation     | TC-080 | Required Fields Enforcement                                  | NOT RUN |           |                  |
| Validation     | TC-081 | Email Uniqueness                                             | NOT RUN |           |                  |
| Validation     | TC-082 | Phone and Email Format Validation                            | NOT RUN |           |                  |
| Validation     | TC-083 | Price Format and Precision                                   | NOT RUN |           |                  |
| Security       | TC-090 | Anonymous User Cannot Access Any Protected Page              | NOT RUN |           |                  |
| Security       | TC-091 | Sales Cannot Access Employees                                | NOT RUN |           |                  |
| Security       | TC-092 | Sales Cannot Edit Books                                      | NOT RUN |           |                  |
| Security       | TC-093 | Manager Has Full Access                                      | NOT RUN |           |                  |
| Security       | TC-094 | Unlinked Identity User Can Log In but Lacks Permissions      | NOT RUN |           |                  |
| Audit          | TC-100 | Audit – Sale Creation Logged                                 | NOT RUN |           |                  |
| Audit          | TC-101 | Audit – Sale Update Logged                                   | NOT RUN |           |                  |
| Audit          | TC-102 | Audit – Capture User Identity                                | NOT RUN |           |                  |

## Notes / Defects

| Defect ID | Severity | Summary | Linked TC(s) | Status |
| --------- | -------- | ------- | ------------ | ------ |
| BUG-001   |          |         |              |        |

