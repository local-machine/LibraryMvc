# Project

### By Jessica Munoz, Joseph Tubridy, Saswati Patra

#### _A web application to connect to LibraryApi and record authors and. - August 29th, 2019_

---

## Description

Library MVC with many-to-many relationship between author and book. This website connects to the LibraryApi to allow for CRUD functionality. 

## Technologies Used

- C#
- .NET
- EntityFrameworkCore

## Installation

- Install .NET locally if it isn't already installed
- Open the terminal, clone down this repository.
- Via the terminal, navigate to the project folder LibraryMvc
  - Enter the command: dotnet restore
  - Enter the command: dotnet run
- Browse to http://localhost:5003/

- NOTE: This application will only have the functionality described if the LibraryApi is also running. Please see the LibraryApi for further instruction.

## Specs

| Behaviors                              |                                                   Input                                                    |                Output                 |
| -------------------------------------- | :--------------------------------------------------------------------------------------------------------: | :-----------------------------------: |
| Users can read all the authors. | User clicks, "See Authors". | All previously created authors by that user are listed. |
| Users can see the details of a specific author. | User clicks, "See Authors", clicks a previously created author. | Author details appear. |
| Users can read all the books. | User clicks, "See Books". | All previously created books by that user are listed. |
| Users can see the details of a specific book. | User clicks, "See Books", clicks a previously created book. | Book details appear. |
| Users can create new authors. | User clicks, "See Authors", "New Author", fill out the form and clicks "Add New Author". | New author is created. |
<!-- | Users can create new authors associated with a previously created book. | User clicks, "See Authors", "New Author", fill out the form (including associated book) and clicks "Add New Author". | New author associated with a book is created. | -->
| Users can create new books. | User clicks, "See Books", clicks "New Book", fill out a form and clicks "Add New Book". | New book for that author is created. |
<!-- | Users can create new books associated with a previously created author. | User clicks, "See Books", "New Book", fill out the form (including associated author) and clicks "Add New Book". | New book associated with a book is created. | -->
| Users can update a particular book or author. | User clicks, "See Books/Authors", clicks a previously created line item, clicks "Edit Book/Author", fills out a form and clicks "Save".  | Author or book is updated. |
| Users can delete a particular book or author. | User clicks, "See Books", clicks a previously created line item, clicks "Delete author/book", clicks "Delete".  | Author or book is deleted. |
---



## Known Bugs

- No known bugs at this time.

## Support and contact details

_Please contact Jessica, Joseph or Saswati with questions and comments._

### License

_GNU GPLv3_

Copyright (c) 2019 **_Jessica Munoz_**