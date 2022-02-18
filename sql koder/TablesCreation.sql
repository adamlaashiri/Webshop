USE webshop
GO

--Creation of all the necessary tables for webshop


-- Password will always be of 32 characters length, because we will use an md5 (not secure) to represent the password to match against when a user logs in!
-- Primary keys can never have null value and "NOT NULL" constraint is redundant
CREATE TABLE Users 
(	
	UserId INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) NOT NULL,
	Username NVARCHAR(50) NOT NULL,
	Password NVARCHAR(32) NOT NULL,
	salt NVARCHAR(8) NOT NULL
)

-- Description for Category is not mandatory, thus a value of null is permissible
-- Category and Suppliers table are parent tables, and have a one to many relationship to products!
CREATE TABLE Categories
(
	CategoryId INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) NOT NULL,
	Description NVARCHAR(256)
)

CREATE TABLE Suppliers
(
	SupplierId INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) NOT NULL
)

-- The assortment we have chosen will be of the type low ticket products, thus the use of "SMALLMONEY". Same goes for ShippingMethods!
CREATE TABLE Products
(
	ProductId INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) NOT NULL,
	SupplierId INT NOT NULL,
	CategoryId INT NOT NULL,
	Description NVARCHAR(256) NOT NULL,
	Price SMALLMONEY NOT NULL,
	Featured BIT NOT NULL,
	CONSTRAINT SupplierIdFK FOREIGN KEY(SupplierId) REFERENCES Suppliers(SupplierId),
	CONSTRAINT CategoryIdFK FOREIGN KEY(CategoryId) REFERENCES Categories(CategoryId)
)

-- StockBalance has a one to one relationship with Product
CREATE TABLE StockBalance
(
	StockBalance INT PRIMARY KEY IDENTITY,
	ProductId INT NOT NULL,
	Quantity INT NOT NULL,
	CONSTRAINT ProductIdFK FOREIGN KEY(ProductId) REFERENCES Products(ProductId)
)

CREATE TABLE Customers
(
	CustomerId INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) NOT NULL,
	Address NVARCHAR(255) NOT NULL,
	Telephone VARCHAR(10) NOT NULL,
	Mail VARCHAR(255) NOT NULL,
	Sex BIT NOT NULL
)

-- PaymentMethods is a parent table and has a one to many relationship with PaymentDetails
CREATE TABLE PaymentMethods
(
	PaymentMethodId INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) NOT NULL
)

CREATE TABLE PaymentDetails
(
	PaymentDetailId INT PRIMARY KEY IDENTITY,
	PaymentMethodId INT NOT NULL,
	value VARCHAR(50) NOT NULL,
	CONSTRAINT PaymentMethodIdFK FOREIGN KEY(PaymentMethodId) REFERENCES PaymentMethods(PaymentMethodId)
)

CREATE TABLE ShippingMethods
(
	ShippingMethodId INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL,
	Price SMALLMONEY NOT NULL
)

CREATE TABLE Orders
(
	OrderId INT PRIMARY KEY IDENTITY,
	OrderDate DATETIME NOT NULL,
	ShippingMethodId INT NOT NULL,
	PaymentDetailId INT NOT NULL,
	CustomerId INT NOT NULL,
	Complete BIT NOT NULL,
	CONSTRAINT ShippingMethodIdFK FOREIGN KEY(ShippingMethodId) REFERENCES ShippingMethods(ShippingMethodId),
	CONSTRAINT PaymentDetailIdFK FOREIGN KEY(PaymentDetailId) REFERENCES PaymentDetails(PaymentDetailId),
	CONSTRAINT CustomerIdFK FOREIGN KEY(CustomerId) REFERENCES Customers(CustomerId)
)

-- This table is to keep track of all the different products ordederd in an Order
CREATE TABLE OrderDetails
(
	OrderDetailId INT PRIMARY KEY IDENTITY,
	OrderId INT NOT NULL,
	ProductId INT NOT NULL,
	Quantity INT NOT NULL,
	CONSTRAINT OrderIdFK FOREIGN KEY(OrderId) REFERENCES Orders(OrderId),
	CONSTRAINT OrderDetailProductIdFK FOREIGN KEY(ProductId) REFERENCES Products(ProductId)
)