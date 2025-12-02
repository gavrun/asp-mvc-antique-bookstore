# Usability and Interaction Rules – Antique Bookstore

## General Rules

- All forms must validate required fields before submission.
- All destructive actions (Delete, Deactivate) must require confirmation.
- Users see only actions permitted by their role:

## Navigation Rules

- The top navigation bar is always visible after login.
- Logged-in users see their email and a Logout link.
- Staff menu is visible only to Manager role.

## Page Layout Rules

- Each page starts with a clear title (e.g. “Employees”, “Book Catalog”).
- Tables show essential columns only; secondary data appears on details pages.
- Action buttons are visually separated:
  - Primary: bright color  
  - Secondary: gray-ish color
  - Destructive: acidic color

## Forms and Data Entry Rules

- Use dropdowns.
- Use date pickers.
- Use consistent field order: Identification → Main Data → Optional Data

## Visual Feedback Rules

- Success actions display a lightweight confirmation message.
- Errors must remain user-friendly.
- Unauthorized pages return access-denied message.

## Device Considerations

- Primary use case: desktop browser in a store office.
- Mobile optimization is not required (optional).
