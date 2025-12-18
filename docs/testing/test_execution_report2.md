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

| Metric | Count |
| --- | --- |
| Total | 49 |
| PASS | 34 |
| FAIL (bug) | 6 |
| FAIL (spec mismatch) | 8 |
| BLOCKED | 1 |
| NOT RUN | 0 |

## Execution Matrix

| Area | TC ID | Title | Status | Defect ID | Notes / Evidence |
| --- | --- | --- | --- | --- | --- |
| Books | TC-001 | Create New Book With Single Author | PASS |  |  |
| Books | TC-002 | Create Book With Multiple Authors | PASS |  | Details page shows multiple linked authors. |
| Books | TC-003 | Create Book With New Author (Modal) | PASS |  |  |
| Books | TC-004 | Validation – Invalid Publication Year | FAIL (spec mismatch) | SPEC-001 | Observed range behaves as 1000–2100 inclusive; 999 rejected; 2101 rejected. |
| Books | TC-005 | Validation – Missing Required Fields | PASS |  |  |
| Books | TC-006 | Edit Existing Book | PASS |  | Edited publication year values saved. |
| Books | TC-007 | Delete Book Without Sales | PASS |  | Success message appears when navigating to /Orders; redirect flow looks inconsistent. |
| Books | TC-008 | Prevent Delete Book With Sales | PASS |  | Block message appears when navigating to /Orders; redirect flow looks inconsistent. |
| Authors | TC-020 | Create Author | PASS |  |  |
| Authors | TC-021 | Edit Author | PASS |  |  |
| Authors | TC-022 | Prevent Delete Author With Linked Books | FAIL (spec mismatch) | SPEC-002 | Uncaught SQL FK constraint exception; also shows 'pending model changes' message. |
| Customers | TC-030 | Create Customer | PASS |  |  |
| Customers | TC-031 | Edit Customer | PASS |  |  |
| Customers | TC-032 | Create Delivery Address For Customer | FAIL (spec mismatch) | SPEC-003 | No delivery address fields/flow in UI (not implemented). |
| Customers | TC-033 | Delete Customer With Addresses | FAIL (spec mismatch) | SPEC-004 | Delete-with-addresses behavior not implemented/available in UI. |
| Customers | TC-034 | View Customer Purchase History | FAIL (spec mismatch) | SPEC-005 | Customer Details page lacks purchase history section. |
| Employees/RBAC | TC-040 | Create Employee | PASS |  |  |
| Employees/RBAC | TC-041 | Edit Employee | PASS |  | UI shows info about role sync requirement after position change. |
| Employees/RBAC | TC-042 | Deactivate Employee | PASS |  |  |
| Employees/RBAC | TC-043 | Assign Position to Employee | PASS |  | Alert shown; info message about role sync requirement. |
| Employees/RBAC | TC-044 | Auto-Enforce Identity to Employee Link | PASS |  | Linking user to employee assigns Sales role as expected. |
| Orders/Sales | TC-050 | Create New Order (Pickup) | PASS |  |  |
| Orders/Sales | TC-051 | Create Order With Multiple Books | PASS |  | Order updated with additional book. |
| Orders/Sales | TC-052 | Prevent Order With Unavailable Book | PASS |  | UI selection excludes unavailable books; note: some DB statuses may not reflect order inclusion. |
| Orders/Sales | TC-053 | Register Payment | FAIL (spec mismatch) | SPEC-006 | No explicit payment registration flow; changing payment method works but not 'payment' state. |
| Orders/Sales | TC-054 | Change Order Status (New → Processing → Shipped → Delivered) | FAIL (bug) | BUG-001 | Changing status triggers 'books no longer available' error for books already on the order. |
| Orders/Sales | TC-055 | Prevent Delivery Before Payment | FAIL (spec mismatch) | SPEC-007 | Payment gating rules not implemented/unclear in UI. |
| Orders/Sales | TC-056 | Cancel Order | PASS |  | Cancel confirmation shown; order removed from list after cancel. |
| Orders/Sales | TC-057 | Prevent Cancel By Unauthorized User | PASS |  | Unlinked user gets AccessDenied for /Orders. |
| Orders/Sales | TC-058 | Prevent Delete Order With Sales | PASS |  |  |
| Lookup Tables | TC-070 | Validate Book Conditions Seeded | PASS |  |  |
| Lookup Tables | TC-071 | Validate Book Statuses Seeded | PASS |  |  |
| Lookup Tables | TC-072 | Validate Payment Methods | PASS |  |  |
| Validation | TC-080 | Required Fields Enforcement | PASS |  | Books/Create and Customers/Create show validation messages. |
| Validation | TC-081 | Email Uniqueness | FAIL (spec mismatch) | SPEC-008 | Duplicate email causes raw SQL exception (no user-friendly validation). |
| Validation | TC-082 | Phone and Email Format Validation | FAIL (bug) | BUG-002 | Customers/Create accepts invalid email like 'hans.muller@'. |
| Validation | TC-083 | Price Format and Precision | PASS |  | Price 1.001 persisted/displayed as $1.00. |
| Security | TC-090 | Anonymous User Cannot Access Any Protected Page | PASS |  |  |
| Security | TC-091 | Sales Cannot Access Employees | PASS |  |  |
| Security | TC-092 | Sales Cannot Edit Books | FAIL (bug) | BUG-003 | Sales user can access /Books/Edit and successfully change fields. |
| Security | TC-093 | Manager Has Full Access | PASS |  |  |
| Security | TC-094 | Unlinked Identity User Can Log In but Lacks Permissions | PASS |  |  |
| Audit | TC-100 | Audit – Sale Creation Logged | PASS |  |  |
| Audit | TC-101 | Audit – Sale Update Logged | PASS |  |  |
| Audit | TC-102 | Audit – Capture User Identity | PASS |  |  |
| Orders/Sales | TC-EX-001 | Sales create order intermittently fails with generic save error | FAIL (bug) | BUG-004 | Message: 'Unable to save changes. Try again…' (not reproducible later). |
| Orders/Sales | TC-EX-002 | Sales edit order intermittently blocked as unauthorized | FAIL (bug) | BUG-005 | Message: 'You are not authorized to edit this order.' (not reproducible later). |
| Validation | TC-EX-003 | Book edit fails unless thousands separator removed from Recommended Price | FAIL (bug) | BUG-006 | Recommended Price '2,500.00' triggers 'must be non-negative'; '2500.00' saves. |
| Orders/Sales | TC-EX-004 | Orders delete endpoints not implemented | BLOCKED | BLK-001 | /Orders/Delete is TODO/stubbed. |

## Notes / Defects

| Defect ID | Severity | Summary | Linked TC(s) | Status |
| --- | --- | --- | --- | --- |
| BUG-001 | High | Order status change fails due to book availability validation running on status update | TC-054 | Open |
| BUG-002 | Medium | Customer email format validation allows invalid email like 'hans.muller@' | TC-082 | Open |
| BUG-003 | High | Sales role can edit books (missing/incorrect authorization) | TC-092 | Open |
| BUG-004 | Medium | Intermittent: sales order creation fails with generic 'Unable to save changes' | TC-EX-001 | Open |
| BUG-005 | Medium | Intermittent: sales cannot edit an order, shows unauthorized message | TC-EX-002 | Open |
| BUG-006 | Low | Recommended Price parsing/validation rejects '2,500.00' thousands separator | TC-EX-003 | Open |
| SPEC-001 | Low | Publication year validation range differs from expected (observed 1000–2100 inclusive) | TC-004 | Open |
| SPEC-002 | Medium | Deleting author with linked books throws SQL FK exception instead of friendly prevention | TC-022 | Open |
| SPEC-003 | Medium | Customer delivery address UI/flow missing | TC-032 | Open |
| SPEC-004 | Medium | Delete customer with addresses flow missing/undefined | TC-033 | Open |
| SPEC-005 | Medium | Customer purchase history not shown on details page | TC-034 | Open |
| SPEC-006 | Medium | Payment registration flow unclear/not implemented | TC-053 | Open |
| SPEC-007 | Low | Delivery-before-payment prevention not implemented/undefined | TC-055 | Open |
| SPEC-008 | Low | Duplicate customer email handled by DB exception rather than UI validation | TC-081 | Open |
| BLK-001 | Medium | Orders delete endpoints not implemented (stubbed/TODO) | TC-EX-004 | Open |

