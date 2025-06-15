create database LibraryManagmentSystem
use LibraryManagmentSystem

create table Staff(
	USER_NAME varchar(255) primary key,
	password varchar(255),
	name varchar(255),
	phone varchar(255),
	email varchar(255),
)
create table [Student Faculty](
	USER_NAME varchar(255) primary key,
	password varchar(255),
	name varchar(255),
	DOB date,
	gender char(1),
	email varchar(255),
	address varchar(255),
	dept varchar(255),
	panelty int,
	isDebarred bit,
	isFaculity bit
)

create table Issues(
	ISSUE_ID int primary key identity,
	username varchar(255),
	copy_no int,
	date_of_issue date,
	extension_date  date default NULL,
	return_date  date,
	extension_count int default 0,
	ISBN_NO Varchar(50),
	foreign key(username) references [Student Faculty](USER_NAME)
)

create table Floors(
	FLOOR_NO int primary key,
	stud_assistant int,
	copiers_no int,
)

create table Subjects(
	SUB_NAME varchar(255) primary key,
	journels_no int,
	floor_no int,
	foreign key(floor_no) references Floors(FLOOR_NO)
)
create table Book(
	ISBN_NO varchar(255) primary key,
	title varchar(255),
	edition int,
	publisher varchar(255),
	onResever bit,
	Publication_place varchar(255),
	Copy_writeYear date,
	shelf_NO int,
	subject_name varchar(255),
	foreign key(subject_name) references Subjects(SUB_NAME)
)

create table Book_Copy(
	COPY_NO int,
	onHold bit,
	Damage bit,
	checked_out bit,
	ISBN_NO varchar(255),
	CONSTRAINT UC_Copy_ISBN UNIQUE (COPY_NO, ISBN_NO),
	foreign key(ISBN_NO) references Book(ISBN_NO)
)

ALTER TABLE BOOK_COPY 
ADD CONSTRAINT DF_Damage DEFAULT 0 FOR Damage;

ALTER TABLE BOOK_COPY 
ADD CONSTRAINT DF_HOLD DEFAULT 0 FOR OnHold;

ALTER TABLE BOOK_COPY 
ADD CONSTRAINT DF_CHKOUT DEFAULT 0 FOR checked_out;


create table Authors(
	author_name varchar(255),
	ISBN_NO varchar(255),
	foreign key(ISBN_NO) references Book(ISBN_NO)
)
ALTER TABLE Authors ADD CONSTRAINT DUPLIC UNIQUE(author_name,ISBN_NO)

create table Shelf(
	SHELF_NO int primary key,
	aisle_no int,
	floor_no int,
	foreign key(floor_no) references Floors(FLOOR_NO)
)


create table KeyWords(
	KEYWORD_ID int primary key identity,
	keyword_name varchar(255),
	sub_name varchar(255),
	foreign key(sub_name)references Subjects(SUB_NAME)
)

-- Staff table
INSERT INTO Staff (USER_NAME, password, name, phone, email)
VALUES 
    ('staff001', 'password1', 'John Doe', '1234567890', 'john@example.com'),
    ('staff002', 'password2', 'Jane Smith', '0987654321', 'jane@example.com'),
    ('staff003', 'password3', 'Alice Johnson', '1122334455', 'alice@example.com'),
    ('staff004', 'password4', 'Bob Brown', '5544332211', 'bob@example.com'),
    ('staff005', 'password5', 'Emily Davis', '9876543210', 'emily@example.com'),
    ('staff006', 'password6', 'Michael Wilson', '0123456789', 'michael@example.com'),
    ('staff007', 'password7', 'Sarah Martinez', '6789012345', 'sarah@example.com');

-- Student Faculty table
INSERT INTO [Student Faculty] (USER_NAME, password, name, DOB, gender, email, address, dept, panelty, isDebarred, isFaculity)
VALUES 
    ('student001', 'password1', 'David Johnson', '1995-08-15', 'M', 'david@example.com', '123 Main St, City', 'Computer Science', 0, 0, 0),
    ('student002', 'password2', 'Emma Williams', '1998-03-20', 'F', 'emma@example.com', '456 Oak Ave, Town', 'English Literature', 0, 0, 0),
    ('faculty001', 'password3', 'Mark Brown', '1980-05-10', 'M', 'mark@example.com', '789 Elm St, Village', 'Physics', 0, 0, 1),
    ('student003', 'password4', 'Sophia Jones', '2000-11-25', 'F', 'sophia@example.com', '321 Pine Rd, Suburb', 'Chemistry', 0, 0, 0),
    ('faculty002', 'password5', 'Lisa Garcia', '1975-07-12', 'F', 'lisa@example.com', '654 Cedar Blvd, County', 'Mathematics', 0, 0, 1),
    ('student004', 'password6', 'Daniel Martinez', '1999-01-30', 'M', 'daniel@example.com', '987 Maple Ct, State', 'History', 0, 0, 0),
    ('student006', 'password8', 'Alexander White', '1996-06-10', 'M', 'alex@example.com', '111 Pine St, City', 'Computer Science', 300, 0, 0),
    ('student007', 'password9', 'Sophie Brown', '1999-12-15', 'F', 'sophie@example.com', '222 Oak Ave, Town', 'English Literature', 280, 0, 0),
    ('faculty003', 'password10', 'Michael Johnson', '1978-09-20', 'M', 'michaelj@example.com', '333 Elm St, Village', 'Physics', 270, 0, 1),
    ('student008', 'password11', 'Ethan Harris', '1997-03-25', 'M', 'ethan@example.com', '444 Cedar Blvd, County', 'Mathematics', 260, 0, 0),
    ('student009', 'password12', 'Ava Martinez', '2001-07-30', 'F', 'ava@example.com', '555 Maple Ct, State', 'History', 290, 0, 0),
    ('student010', 'password13', 'Mia Rodriguez', '1998-11-05', 'F', 'mia@example.com', '666 Birch Ln, Province', 'Biology', 275, 0, 0),
    ('student005', 'password7', 'Olivia Taylor', '1997-09-05', 'F', 'olivia@example.com', '741 Birch Ln, Province', 'Biology', 0, 0, 0);

-- Issues table
INSERT INTO Issues (username, copy_no, date_of_issue, return_date, ISBN_NO)
VALUES 
    ('student001', 1, '2024-04-10', '2024-05-10', 'ISBN001'),
    ('student002', 3, '2024-04-15', '2024-05-15', 'ISBN002'),
    ('faculty001', 2, '2024-04-20', '2024-05-20', 'ISBN003'),
    ('student003', 5, '2024-04-25', '2024-05-25', 'ISBN004'),
    ('faculty002', 4, '2024-04-30', '2024-05-30', 'ISBN005'),
    ('student004', 7, '2024-05-01', '2024-06-01', 'ISBN006'),
    ('student005', 6, '2024-05-05', '2024-06-05', 'ISBN007');

-- Floors table
INSERT INTO Floors (FLOOR_NO, stud_assistant, copiers_no)
VALUES 
    (1, 2, 3),
    (2, 3, 2),
    (3, 1, 4);

-- Subjects table
INSERT INTO Subjects (SUB_NAME, journels_no, floor_no)
VALUES 
    ('Computer Science', 10, 1),
    ('English Literature', 8, 2),
    ('Physics', 12, 3),
    ('Chemistry', 7, 1),
    ('Mathematics', 9, 2),
    ('History', 6, 3),
    ('Biology', 11, 1);

-- Book table
INSERT INTO Book (ISBN_NO, title, edition, publisher, Publication_place, Copy_writeYear, shelf_NO, subject_name)
VALUES 
    ('ISBN001', 'Introduction to Computer Science', 1, 'ABC Publications', 'New York', '2022-01-01', 101, 'Computer Science'),
    ('ISBN002', 'Literary Analysis', 2, 'XYZ Publishers', 'London', '2020-01-01', 201, 'English Literature'),
    ('ISBN003', 'Fundamentals of Physics', 3, '123 Press', 'Tokyo', '2018-01-01', 301, 'Physics'),
    ('ISBN004', 'Chemical Reactions', 1, '456 Books',  'Paris', '2019-01-01', 102, 'Chemistry'),
    ('ISBN005', 'Advanced Calculus', 2, '789 Publishers', 'Berlin', '2021-01-01', 202, 'Mathematics'),
    ('ISBN006', 'World History', 1, 'ABC Publishers',  'Moscow', '2017-01-01', 302, 'History'),
    ('ISBN007', 'Biology Essentials', 3, 'XYZ Books', 'Rome', '2020-01-01', 103, 'Biology');

-- Book_Copy table
INSERT INTO Book_Copy (COPY_NO, onHold, Damage, ISBN_NO)
VALUES 
    (1, 0, 0, 'ISBN001'),
    (2, 0, 0, 'ISBN002'),
    (3, 0, 0, 'ISBN003'),
    (4, 0, 0, 'ISBN004'),
    (5, 0, 0, 'ISBN005'),
    (6, 0, 0, 'ISBN006'),
    (7, 0, 0,'ISBN007');

-- Authors table
INSERT INTO Authors (author_name, ISBN_NO)
VALUES 
    ('Alice Johnson', 'ISBN001'),
    ('Bob Brown', 'ISBN002'),
    ('Charlie Clark', 'ISBN003'),
    ('David Davis', 'ISBN004'),
    ('Emily Evans', 'ISBN005'),
    ('Frank Ford', 'ISBN006'),
    ('Grace Green', 'ISBN007');

-- Shelf table
INSERT INTO Shelf (SHELF_NO, aisle_no, floor_no)
VALUES 
    (101, 1, 1),
    (102, 1, 1),
    (103, 1, 1),
    (201, 2, 2),
    (202, 2, 2),
    (301, 3, 3),
    (302, 3, 3);

	select*from Shelf
-- KeyWords table
INSERT INTO KeyWords (keyword_name, sub_name)
VALUES 
    ('Programming', 'Computer Science'),
    ('Poetry', 'English Literature'),
    ('Mechanics', 'Physics'),
    ('Chemical Reactions', 'Chemistry'),
    ('Calculus', 'Mathematics'),
    ('World War II', 'History'),
    ('Cell Biology', 'Biology');

SELECT * FROM Shelf
SELECT * FROM SUBJECTs
SELECT * FROM Floors
SELECT * FROM Authors
SELECT * FROM Issues
SELECT * FROM Book
SELECT * FROM BOOK_COPY 
SELECT * FROM KeyWords
select * from staff
select* from [Student Faculty]
delete from Book where ISBN_NO = '132345'

update [Student Faculty] 
set isDebarred = 1
where panelty>=200

/*JOINS*/

select s.USER_NAME,s.name,s.dept,s.panelty,s.isDebarred,i.ISBN_NO
from [Student Faculty] as s
join Issues as i on i.username = s.USER_NAME 
where s.panelty>=200


/*TRIGGERS*/
CREATE or ALTER TRIGGER Faculty_Debarment
ON [Student Faculty]
AFTER  UPDATE
AS
BEGIN
    UPDATE [Student Faculty]
    SET isDebarred = 1
    WHERE panelty >= 200 AND isFaculity = 1;
END;

/*TRIGGERS*/
CREATE OR ALTER TRIGGER Student_Debarment
ON [Student Faculty]
AFTER  UPDATE
AS
BEGIN
    UPDATE [Student Faculty]
    SET isDebarred = 1
    WHERE panelty >= 200 AND isFaculity = 0;
END;


/*Views & JOIN*/

CREATE VIEW AvailableBooks AS
SELECT b.title AS Book_Title, b.ISBN_NO AS ISBN, b.subject_name AS Subject_Name
FROM Book b
LEFT JOIN Book_Copy bc ON b.ISBN_NO = bc.ISBN_NO
WHERE bc.onHold = 0 AND bc.Damage = 0;

select*from AvailableBooks

/* VIEWS */
CREATE VIEW BookDetails AS
SELECT title AS Book_Title, publisher, edition, Quantity AS Available_Quantity
FROM Book;

select*from BookDetails


/*Views & JOIN*/
CREATE VIEW HoldBooks AS
SELECT b.title AS Book_Title, b.edition AS Book_Edition
FROM Book_Copy bc
JOIN Book b ON bc.ISBN_NO = b.ISBN_NO
WHERE bc.onHold = 1;


SELECT * FROM HoldBooks


/*SUB-QUERIES*/

SELECT 
    ISBN_NO, title,
    (SELECT COUNT(*) 
     FROM Book_Copy 
     WHERE ISBN_NO = Book.ISBN_NO) AS TotalCopies
FROM 
    Book
WHERE 
    ISBN_NO = '234-32345-3';

/*SUB-QUERY & JOIN*/


SELECT SUB_NAME,
(SELECT COUNT(*) 
    FROM Issues 
    JOIN Book ON Issues.ISBN_NO = Book.ISBN_NO 
    WHERE Book.subject_name = Subjects.SUB_NAME) AS TotalBooksIssued
FROM 
    Subjects;


/*GROUP-BY & Order by*/

SELECT subject_name, COUNT(*) AS TotalBooksIssued
FROM Issues 
JOIN Book ON Issues.ISBN_NO = Book.ISBN_NO
GROUP BY subject_name 
ORDER BY TotalBooksIssued;


