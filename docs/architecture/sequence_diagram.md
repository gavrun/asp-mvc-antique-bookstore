# Sequence Diagram - Antique Bookstore

## Introduction

This document provides detailed sequence diagrams for the Antique Bookstore. 
Diagrams expressed using PlantUML sequence diagram notation.

The goal of this document is to describe system interactions between difference layers, depict methods calls, and requests lifecycle.

## Diagram

```
```

## Create New Book with New Author (modal)

```
@startuml

actor User
participant "AddBookPage\n(Razor View + JS)" as UI
participant "BooksController" as BooksCtrl
participant "AuthorsController" as AuthorsCtrl
participant "IFileStorageService" as FileStore
database "ApplicationDbContext\n(EF Core)" as Db

== Open Add Book Page ==

User -> UI : Navigate to /Books/Create
UI -> BooksCtrl : GET /Books/Create
BooksCtrl -> Db : SELECT Authors,\nBookConditions,\nBookStatuses
Db --> BooksCtrl : lists
BooksCtrl --> UI : View(BookCreateViewModel)\nwith SelectLists

== Add New Author (modal) ==

User -> UI : Click "Add New Author"\n(open modal)

UI -> AuthorsCtrl : GET /Authors/Create
AuthorsCtrl --> UI : Author create form\n(rendered in modal)

User -> UI : Submit author form
UI -> AuthorsCtrl : POST /Authors/Create\n(AuthorViewModel)
AuthorsCtrl -> Db : INSERT INTO Authors ...
Db --> AuthorsCtrl : new Author.Id
AuthorsCtrl --> UI : return success +\nnew author data (Id, Name)
UI -> UI : Update authors multiselect\n(select new author)

== Submit New Book ==

User -> UI : Fill book form\n(select new author)\nthen submit
UI -> BooksCtrl : POST /Books/Create\n(BookCreateViewModel)

alt Cover image uploaded
  BooksCtrl -> FileStore : SaveFileAsync(file,"images/covers")
  FileStore --> BooksCtrl : FileUploadResult\n(relativePath or error)
  BooksCtrl -> BooksCtrl : Update ModelState /\nset CoverImagePath
end

BooksCtrl -> Db : INSERT INTO Books ...
Db --> BooksCtrl : new Book.Id

BooksCtrl -> Db : INSERT INTO BookAuthors\n(for each SelectedAuthorId)
Db --> BooksCtrl : OK

BooksCtrl --> UI : Redirect to /Books/Index\n(or /Books/Details/{id})
UI --> User : Book created feedback

@enduml
```
