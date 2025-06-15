# Library Management System Documentation

## Project Overview
The Library Management System is a desktop application developed during the 4th semester to automate library operations for educational institutions. The system facilitates efficient management of books, users, and transactions through a user-friendly interface and a robust relational database. It was designed to enhance administrative tasks, reduce manual errors, and provide a seamless experience for both library staff and users.

- **Semester:** 4th Semester
- **Team Size:** 2 Members
- **Duration:** One semester
- **Objective:** To develop a scalable desktop application integrating front-end and back-end components for library management.

## Features
The system supports the following key functionalities:
- **Admin Account Creation:** Allows library administrators to create and manage their accounts with secure authentication.
- **Student/Faculty Registration:** Enables registration of students and faculty members as library users, storing their details in the database.
- **Book Lending System:** Manages borrowing and returning of books, tracking due dates and user history.
- **Penalty System:** Automatically calculates and applies penalties for overdue books, with options for admins to manage fines.
- **Book Inventory Management:** Maintains a catalog of books with details like title, author, ISBN, and availability status.
- **User Management:** Admins can view, update, or delete user profiles and borrowing records.
- **Search Functionality:** Allows users to search for books by title, author, or category.
- **Reporting:** Generates reports on borrowing trends, overdue books, and penalty statuses for administrative insights.

## Tech Stack
The application was built using the following technologies:
- **Programming Language:** C#
- **Framework:** .NET Framework
- **Database:** SQL Server
- **Front-End:** Windows Forms
- **Design Tools:** UML (Unified Modeling Language) for system modeling
- **Development Environment:** Visual Studio

## System Design
The system was designed with a focus on modularity and scalability, using UML diagrams to model its architecture and workflows.

### UML Diagrams
- **Use Case Diagram:**
  - Actors: Admin, Student/Faculty (Library User)
  - Use Cases: Create Admin Account, Register User, Borrow Book, Return Book, Apply Penalty, Search Book, Generate Report
  - Description: Illustrated interactions between actors and system functionalities, defining user roles and system boundaries.

- **Class Diagram (Static):**
  - Classes: Admin, User, Book, Transaction, Penalty
  - Relationships: Associations between User and Transaction, Book and Transaction, and Admin and Penalty
  - Attributes: User (ID, Name, Email, Role), Book (ISBN, Title, Author, Status), Transaction (BorrowDate, DueDate, ReturnDate)
  - Methods: Admin (CreateAccount, ManageUser), User (BorrowBook, ReturnBook), Penalty (CalculateFine)

- **Sequence Diagram (Dynamic):**
  - Modeled interactions for key processes like borrowing a book, applying a penalty, and generating reports.
  - Example: Borrowing a book involved User requesting a book, System checking availability, updating Transaction, and notifying User.

- **Entity-Relationship Diagram (EERD):**
  - Entities: User, Book, Transaction, Penalty
  - Relationships: User borrows Book via Transaction, Penalty linked to Transaction
  - Attributes: User (UserID, Name), Book (BookID, ISBN), Transaction (TransactionID, BorrowDate), Penalty (PenaltyID, Amount)
  - Designed to ensure data integrity and efficient querying in SQL Server.

### Database Schema
The SQL Server database was structured to support efficient data management:
- **Tables:**
  - `Users` (UserID, Name, Email, Role, Contact)
  - `Books` (BookID, ISBN, Title, Author, Category, Status)
  - `Transactions` (TransactionID, UserID, BookID, BorrowDate, DueDate, ReturnDate)
  - `Penalties` (PenaltyID, TransactionID, Amount, Status)
- **Keys:**
  - Primary Keys: UserID, BookID, TransactionID, PenaltyID
  - Foreign Keys: UserID and BookID in Transactions, TransactionID in Penalties
- **Indexes:** Created on frequently queried fields like ISBN and UserID for performance optimization.

## Implementation Details
### Front-End (Windows Forms)
- Designed using Windows Forms in Visual Studio for a clean and intuitive interface.
- Components:
  - Admin Dashboard: For managing users, books, and penalties.
  - User Interface: For searching books, viewing borrowing history, and checking penalties.
  - Forms: Login, Registration, Book Search, Borrow/Return, Penalty Payment.
- Features like data grids for displaying book/user lists and input validation for forms enhanced usability.

### Back-End (C# and .NET Framework)
- Implemented business logic using C# within the .NET Framework.
- Key functionalities:
  - Authentication: Secure login for admins and users using hashed passwords.
  - CRUD Operations: Create, Read, Update, Delete operations for users, books, and transactions.
  - Penalty Calculation: Automated fine computation based on overdue days (e.g., fixed rate per day).
- Used ADO.NET for database connectivity, executing SQL queries, and managing transactions.

### Database (SQL Server)
- Configured SQL Server to store and manage relational data.
- Implemented stored procedures for complex operations like borrowing and penalty calculation to improve performance.
- Ensured data integrity with constraints (e.g., foreign keys, check constraints for book status).
- Example Query: `SELECT * FROM Books WHERE Title LIKE @SearchTerm OR Author LIKE @SearchTerm` for book search.

## Documentation Produced
The project included comprehensive documentation to support development and maintenance:
- **Software Requirements Specification (SRS):** Detailed functional and non-functional requirements, including system scope, user roles, and performance expectations.
- **Use Case Document:** Described interactions between actors and the system, with preconditions, postconditions, and alternate flows.
- **Test Cases Document:** Defined test scenarios for functionalities like book borrowing, penalty application, and user registration, with expected outcomes.
- **UML Diagrams:** Use Case, Class, Sequence, and EERD diagrams for system design and architecture.

## Challenges and Solutions
- **Challenge:** Ensuring real-time updates for book availability during borrowing.
  - **Solution:** Implemented database triggers to update book status automatically upon transaction creation.
- **Challenge:** Designing an intuitive UI for non-technical admins.
  - **Solution:** Used Windows Forms with clear labels, tooltips, and data grids, validated through user feedback.
- **Challenge:** Optimizing database queries for large datasets.
  - **Solution:** Added indexes on frequently searched columns and used stored procedures for complex operations.

## Future Enhancements
- Add a web-based interface using ASP.NET to enable remote access.
- Integrate email notifications for due dates and penalties.
- Implement a barcode scanning feature for faster book borrowing/returning.
- Enhance reporting with data visualization (e.g., charts for borrowing trends).

## Conclusion
<<<<<<< HEAD
The Library Management System demonstrates proficiency in C#, .NET Framework, SQL Server, and Windows Forms, showcasing the ability to design and implement a robust, database-driven desktop application. The use of UML diagrams and comprehensive documentation reflects a structured approach to software development, making the system scalable and maintainable.
=======
The Library Management System demonstrates proficiency in C#, .NET Framework, SQL Server, and Windows Forms, showcasing the ability to design and implement a robust, database-driven desktop application. The use of UML diagrams and comprehensive documentation reflects a structured approach to software development, making the system scalable and maintainable.
>>>>>>> a21af91 (Project now going to github)
