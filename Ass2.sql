create database PRN_Ass2
--drop database PRN_Ass2
use PRN_Ass2
create table Member(
	MemberId int IDENTITY(1,1) primary key,
	Email varchar(100),
	CompanyName varchar(40),
	City varchar(15),
	Country varchar(15),
	[Password] varchar(30),
)

create table [Order](
	OrderId int IDENTITY(1,1) primary key,
	MemberId int,
	foreign key(MemberId) references Member(MemberId),
	OrderDate datetime,
	RequiredDate datetime,
	ShippedDate datetime,
	Freight money,
)
create table Product(
	ProductId int IDENTITY(1,1) primary key,
	CategoryId int,
	ProductName varchar(40),
	[Weight] varchar(20),
	UnitPrice money,
	UnitslnStock int,
)
create table OrderDetail(
	OrderId int,
	foreign key(OrderId) references [Order](OrderId),
	ProductId int,
	foreign key(ProductId) references Product(ProductId),
	UnitPrice money,
	Quantity int,
	Discount float,
)
DELETE od FROM OrderDetail od INNER JOIN [Order] o ON od.OrderId = o.OrderId WHERE o.MemberId = 1
go
CREATE TRIGGER tr_DeleteOrder
ON [Order]
AFTER DELETE
AS
BEGIN
    DELETE FROM OrderDetail
    WHERE OrderId IN (SELECT OrderId FROM deleted)
END
go
ENABLE TRIGGER tr_DeleteOrder ON [dbo].[Order];
go
drop TRIGGER tr_DeleteOrder



INSERT INTO Member (Email, CompanyName, City, Country, [Password])
VALUES
('john@example.com', 'ABC Corp', 'New York', 'USA', 'password123'),
('jane@example.com', 'XYZ Inc', 'London', 'UK', 'mypassword'),
('jim@example.com', '123 Co', 'Sydney', 'Australia', 'mysecret'),
('bob@example.com', 'Acme Ltd', 'Paris', 'France', '123456'),
('sara@example.com', 'Beta Corp', 'Toronto', 'Canada', 'password');

INSERT INTO [Order] (MemberId, OrderDate, RequiredDate, ShippedDate, Freight) 
VALUES ( 1, '2022-01-01', '2022-01-07', '2022-01-05', 20.5);

INSERT INTO [Order] ( MemberId, OrderDate, RequiredDate, ShippedDate, Freight) 
VALUES ( 2, '2022-02-03', '2022-02-08', '2022-02-06', 15.0);

INSERT INTO [Order] ( MemberId, OrderDate, RequiredDate, ShippedDate, Freight) 
VALUES ( 1, '2022-03-12', '2022-03-18', NULL, 10.2);

INSERT INTO [Order] ( MemberId, OrderDate, RequiredDate, ShippedDate, Freight) 
VALUES ( 3, '2022-04-23', '2022-04-30', '2022-04-25', 30.1);

INSERT INTO [Order] ( MemberId, OrderDate, RequiredDate, ShippedDate, Freight) 
VALUES ( 5, '2022-05-15', '2022-05-21', NULL, 25.0);

INSERT INTO Product ( CategoryId, ProductName, Weight, UnitPrice, UnitslnStock) VALUES ( 13, 'Product A', '10 kg', 25.00, 100)
INSERT INTO Product ( CategoryId, ProductName, Weight, UnitPrice, UnitslnStock) VALUES ( 13, 'Product B', '5 kg', 18.50, 50)
INSERT INTO Product ( CategoryId, ProductName, Weight, UnitPrice, UnitslnStock) VALUES ( 14, 'Product C', '2.5 kg', 12.99, 75)
INSERT INTO Product ( CategoryId, ProductName, Weight, UnitPrice, UnitslnStock) VALUES ( 14, 'Product D', '1 kg', 8.75, 150)
INSERT INTO Product ( CategoryId, ProductName, Weight, UnitPrice, UnitslnStock) VALUES ( 15, 'Product E', '500 g', 4.99, 200)

INSERT INTO OrderDetail (OrderId, ProductId, UnitPrice, Quantity, Discount)
VALUES (6, 1, 10.99, 2, 0.05);

INSERT INTO OrderDetail (OrderId, ProductId, UnitPrice, Quantity, Discount)
VALUES (7, 2, 5.99, 3, 0.10);

INSERT INTO OrderDetail (OrderId, ProductId, UnitPrice, Quantity, Discount)
VALUES (8, 3, 8.50, 1, 0.00);

INSERT INTO OrderDetail (OrderId, ProductId, UnitPrice, Quantity, Discount)
VALUES (9, 4, 12.75, 2, 0.20);

INSERT INTO OrderDetail (OrderId, ProductId, UnitPrice, Quantity, Discount)
VALUES (10, 4, 6.25, 5, 0.15);




