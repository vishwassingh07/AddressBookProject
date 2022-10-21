Create DataBase AddressBookDB

Use AddressBookDB

Create Table AddressBook(
Id int Identity(1,1) Primary Key,
FirstName varchar(100) Not Null,
LastName varchar(100) Not Null,
Address varchar(300),
City varchar(100),
State varchar(100),
Zip int,
Phone bigint,
Email varchar(200)
);

----------- Stored Procedure For User Registration ---------
Create Procedure spUserRegistration
(
@FirstName varchar(100),
@LastName varchar(100),
@Address varchar(300),
@City varchar(100),
@State varchar(100),
@Zip int,
@Phone bigint,
@Email varchar(200)
)
As
Begin
	Insert Into AddressBook
	Values(@FirstName, @LastName, @Address, @City, @State, @Zip, @Phone, @Email)
End;

------------ Stored Procedure For User Login -----------
Create Procedure spRetrieveAddress
As
Begin
	Select * From AddressBook
End