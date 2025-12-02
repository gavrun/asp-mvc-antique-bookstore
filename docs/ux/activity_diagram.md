# Activity Diagram - Antique Bookstore

## Introduction

This document provides detailed activity diagrams for the Antique Bookstore.
Diagrams expressed using PlantUML activity diagram notation.

The goal of this document is to describe steps and branches within users UX flows in a visual form.

## Diagram

```
```

## Create New Book with New Author (modal)

```
@startuml CreateNewBookActivity

start

:Open "Inventory → Add New Book";

:Enter Book Title, Publisher, Publication Year;
:Enter Purchase Price and Recommended Price;
:Select Condition and Status;

if (Need new Author?) then (yes)
  :Click "Add New Author";
  :Fill author form (First/Last/BirthYear/etc.);
  :Save new Author;
  :Author added to list;
else (no)
endif

:Select one or more Authors from list;
:Optionally upload Cover Image;

if (Form valid?) then (yes)
  :Save Book;
  :Show confirmation / redirect to Catalog;
else (no)
  :Show validation errors;
  :User corrects data;
  -back to- Select one or more Authors from list;
endif

stop

@enduml
```
