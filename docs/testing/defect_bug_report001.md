# Bug Report – Antique Bookstore

## Bug ID

BUG-001 

## Title

Orders/Edit blocks order status updates with “book not available” error for some orders (seeded + stateful reproduce)

## Related Test Case(s)

TC-054: Change Order Status (New → Processing → Shipped → Delivered) 

Verify that an existing order can progress through status changes using Orders/Edit and that the update persists.

## Type

Functional defect (server-side validation / state management) 

## Status

Open 

## Severity

High 

## Priority

P1 

## Environment

| Field | Value |
| --- | --- |
| Build/Commit | Not recorded (local build) |
| Runtime | Local dev |
| DB | Seed data applied; additional orders created via UI |
| Browser | Not recorded |
| User role | Manager/Sales with Orders/Edit access |

## Preconditions

- Seed data loaded (Orders 1 and 7 exist).
- User can open Orders/Edit pages.
- At least one order contains a book that is not `Available` at save time (Book IDs 1 and 9 in this reproduce).

## Steps to Reproduce

### Repro A — Order 1 

1. Navigate to `/Orders/Edit/1`
2. Change Order Status from `New` → `Payment Pending`
3. Click **Save**

**Actual:** fails with Book ID **1**:
`One or more selected books (IDs: 1) are no longer available ...`

**Expected:** status-only change should save.

### Repro B — Order 7 

1. Navigate to `/Orders/Edit/7`
2. Change Order Status from `New` → `Payment Pending`
3. Click **Save**

**Actual:** fails with Book ID **9**:
`One or more selected books (IDs: 9) are no longer available ...`

**Expected:** status-only change should save.

### Repro C — Order 5

1. Create another new order (resulted in Order ID **5**)
2. Navigate to `/Orders/Edit/5`
3. Change status and Save

**Observed:** first attempt **PASS**.

4. Later, return to `/Orders/Edit/5`
5. Change status and Save again

**Observed:** **FAIL** with Book ID **9**:
`One or more selected books (IDs: 9) are no longer available ...`

**Key point:** The failing Book ID **9** matches the seeded Order 7 failure, suggesting Book 9’s status changes over time and later blocks order edits.

### Repro D — Order 3 

1. Create a new order via UI (resulted in Order ID **3** during test)
2. Navigate to `/Orders/Edit/3`
3. Change status and click **Save`

**Observed:** success message:
`Order ID 3 updated successfully.`

## Expected Result

Changing **Order Status** in `/Orders/Edit/<built-in function id>` allows saving order status change for valid transitions.

The system should not block status-only changes because an order’s own books are “unavailable” to everyone else.

## Actual Result

Changing **Order Status** in `/Orders/Edit/<built-in function id>` fails for some orders with:

`One or more selected books (IDs: X) are no longer available (Status is not 'Available' or book does not exist). Please review the items.`

Some orders fail with an error claiming books are not `Available`. Other orders succeed (including newly created orders), indicating a data/state dependency rather than a global form failure.

## Evidence

- Screenshot(s)

## Notes

- Appears to be triggered by book state transitions.

## Reporter

Name / Date

## Fix Verification

A fix is verified when status save succeeds (no “book not available” message) without changing items.

