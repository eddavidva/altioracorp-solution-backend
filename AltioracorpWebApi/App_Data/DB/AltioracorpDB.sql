CREATE DATABASE AltioracorpDB;
GO

USE AltioracorpDB;

CREATE TABLE Clients (
	IdClient int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	FirstName varchar(255) NOT NULL,
	LastName varchar(255) NOT NULL,
	CreatedAt datetime DEFAULT CURRENT_TIMESTAMP,
	ModifiedAt datetime DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE Orders (
	IdOrder int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	IdClient int NOT NULL,
	CreatedAt datetime DEFAULT CURRENT_TIMESTAMP,
	ModifiedAt datetime DEFAULT CURRENT_TIMESTAMP,
	CONSTRAINT FK_Client_Order FOREIGN KEY (IdClient) REFERENCES Clients(IdClient)
);

CREATE TABLE Products(
	IdProduct int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Code varchar(25) NOT NULL,
	Name varchar(255) NOT NULL,
	Price float NOT NULL DEFAULT '0.00',
	CreatedAt datetime DEFAULT CURRENT_TIMESTAMP,
	ModifiedAt datetime DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE OrdersDetail(
	IdOrderDetail int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	IdOrder int NOT NULL,
	IdProduct int NOT NULL,
	Amount float NOT NULL DEFAULT '0.00',
	Total float NOT NULL DEFAULT '0.00',
	CONSTRAINT FK_Order_OrdersDetail FOREIGN KEY (IdOrder) REFERENCES Orders(IdOrder),
	CONSTRAINT FK_Product_OrdersDetail FOREIGN KEY (IdProduct) REFERENCES Products(IdProduct)
);

