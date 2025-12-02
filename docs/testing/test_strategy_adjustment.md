# Testing Strategy (after implementation stage)

## About

The `development_plan.md` document was to describe the technical development approach for the Antique Bookstore system.

Project reached finishing the implementation stage. 
The working prototype for the Antique Bookstore system is present and functional.

Reviewing the **Testing Strategy** which was made on planning step before implementing the system, and **adjusting Testing Strategy** to evaluate the project against the acceptance criteria.

## Testing Strategy Refined

Source is `development_plan.md` document.

### 4.1 Testing Layers

#### 1. TDD-Style Unit Tests (Domain Logic)

To be used to enforce correctness of pure business rules.

In the project, true DDD-style domain services do not exist, and some logic is inside controllers.
Still *small, deterministic behaviors* to be isolated and tested:

* Order status transition rules
* Price calculations (SalePrice, totals, etc.)
* Validation constraints that are not DB-dependent
* Invariants (e.g., preventing deletion if sales exist – can be simulated without DB)

These are *retrospective TDD tests* without refactoring, demonstrating focus on core logic rather than full coverage.

#### 2. Standard Unit Tests (Post-implementation Tests)

Best to be used for:

* Utility functions
* ViewModels mapping correctness
* "Rules embedded in controllers" extracted into private helper functions using reflection-access or simply testing via controller instance
* Testing that controller actions return correct ViewResult, route, or BadRequest with mocks

These provide meaningful tests coverage focusing on the most important rather than spreading on a full coverage.

#### 3. Integration Tests (Critical Flows)

These tests run with:

* EF Core InMemory provider or SQLite in-memory
* Minimal application host (WebApplicationFactory)

Critical flows for testing:

* Creating an order updates Sales + Book statuses
* Canceling an order reverses Book statuses
* Seeding: lookup tables, authors, book conditions
* Audit Interceptor correctly logs Sale operations (HttpContextAccessor)

Only limited amount of meaningful integration tests to meet SDLC.

#### 4. Manual UI Testing

Best to be used for:

* Razor pages
* Modals (Create Author)
* Form validation
* Navigation flows

UI testing is explicitly excluded from automated coverage in SDLC of this project.

