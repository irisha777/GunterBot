
create table Customers
(
	Id int primary key identity(1, 1),
	Name nvarchar(256),
	Phone nvarchar(15),
	NickName nvarchar(256)
);

create table Products
(
	Id int primary key identity(1, 1),
	Name nvarchar(256),
	ProductCategoryId int,
	Cost int,
	Descrition nvarchar(1000),
	IsActive bit,
	CONSTRAINT FK_Products_To_ProductCategory FOREIGN KEY(ProductCategoryId) REFERENCES ProductCategory(Id);
);
create table Addresses
(
	Id int primary key identity(1, 1),
	Name nvarchar(256),
	District nvarchar(256),
	City nvarchar(256),
	Street nvarchar(256),
	PostIndex nvarchar(64)
);
create table Orders
(
	Id int primary key identity(1, 1),
	CustomerId int,
	AddressId int,
	ProductId int,
	OrderDate datetime2,
	EndDate datetime2,
	IsDone bit,
	CONSTRAINT FK_Orders_To_Customers FOREIGN KEY (CustomerId)  REFERENCES Customers (Id),
	CONSTRAINT FK_Orders_To_Addresses FOREIGN KEY (AddressId)  REFERENCES Addresses (Id),
	CONSTRAINT FK_Orders_To_Products FOREIGN KEY (ProductId)  REFERENCES Products (Id)
);

create table ProductCategory
(
	Id int primary key identity(1, 1),
	Name nvarchar(128),
	IsActive bit
);

