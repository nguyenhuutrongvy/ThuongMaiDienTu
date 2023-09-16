CREATE DATABASE ThuongMaiDienTu
GO

USE ThuongMaiDienTu
GO

CREATE TABLE Category
(
	Id				INT IDENTITY(1, 1) PRIMARY KEY,
	Title			NVARCHAR(150) NOT NULL,
	Description		NVARCHAR(500),
	Position		INT,
	SEOTitle		NVARCHAR(250),
	SEODescription	NVARCHAR(250),
	SEOKeywords		NVARCHAR(250),
	CreatedDate		DATETIME,
	CreatedBy		NVARCHAR(150),
	ModifiedDate	DATETIME,
	ModifiedBy		NVARCHAR(150)
)
GO

CREATE TABLE Advertisement
(
	Id				INT IDENTITY(1, 1) PRIMARY KEY,
	Title			NVARCHAR(250) NOT NULL,
	Description		NVARCHAR(500),
	Image			NVARCHAR(500),
	Type			INT,
	Link			NVARCHAR(500),
	SEOTitle		NVARCHAR(250),
	SEODescription	NVARCHAR(250),
	SEOKeywords		NVARCHAR(250),
	CreatedDate		DATETIME,
	CreatedBy		NVARCHAR(150),
	ModifiedDate	DATETIME,
	ModifiedBy		NVARCHAR(150)
)
GO

CREATE TABLE Contact
(
	Id				INT IDENTITY(1, 1) PRIMARY KEY,
	Name			NVARCHAR(150),
	Email			NVARCHAR(150),
	Website			NVARCHAR(150),
	Message			NVARCHAR(4000),
	IsRead			BIT DEFAULT 0,
	CreatedDate		DATETIME,
	CreatedBy		NVARCHAR(150),
	ModifiedDate	DATETIME,
	ModifiedBy		NVARCHAR(150)
)
GO

CREATE TABLE ProductCategory
(
	Id				INT IDENTITY(1, 1) PRIMARY KEY,
	Title			NVARCHAR(150) NOT NULL,
	Description		NVARCHAR(500),
	Icon			NVARCHAR(500),
	CreatedDate		DATETIME,
	CreatedBy		NVARCHAR(150),
	ModifiedDate	DATETIME,
	ModifiedBy		NVARCHAR(150)
)
GO

CREATE TABLE Product
(
	Id					INT IDENTITY(1, 1) PRIMARY KEY,
	ProductCategoryId	INT FOREIGN KEY REFERENCES dbo.ProductCategory(Id),
	Title				NVARCHAR(250) NOT NULL,
	Description			NVARCHAR(4000),
	Detail				NVARCHAR(MAX),
	Image				NVARCHAR(500),
	--Price				MONEY,
	CostPrice			DECIMAL(18, 2),
	Price				DECIMAL(18, 2),
	PromotionalPrice	DECIMAL(18, 2),
	Quantity			INT,
	SEOTitle			NVARCHAR(250),
	SEODescription		NVARCHAR(250),
	SEOKeywords			NVARCHAR(250),
	CreatedDate			DATETIME,
	CreatedBy			NVARCHAR(150),
	ModifiedDate		DATETIME,
	ModifiedBy			NVARCHAR(150)
)
GO

CREATE TABLE News
(
	Id					INT IDENTITY(1, 1) PRIMARY KEY,
	CategoryId			INT FOREIGN KEY REFERENCES dbo.Category(Id),
	Title				NVARCHAR(250) NOT NULL,
	Description			NVARCHAR(4000),
	Detail				NVARCHAR(MAX),
	Image				NVARCHAR(500),
	SEOTitle			NVARCHAR(250),
	SEODescription		NVARCHAR(250),
	SEOKeywords			NVARCHAR(250),
	CreatedDate			DATETIME,
	CreatedBy			NVARCHAR(150),
	ModifiedDate		DATETIME,
	ModifiedBy			NVARCHAR(150)
)
GO

CREATE TABLE Post
(
	Id					INT IDENTITY(1, 1) PRIMARY KEY,
	CategoryId			INT FOREIGN KEY REFERENCES dbo.Category(Id),
	Title				NVARCHAR(250) NOT NULL,
	Description			NVARCHAR(4000),
	Detail				NVARCHAR(MAX),
	Image				NVARCHAR(500),
	SEOTitle			NVARCHAR(250),
	SEODescription		NVARCHAR(250),
	SEOKeywords			NVARCHAR(250),
	CreatedDate			DATETIME,
	CreatedBy			NVARCHAR(150),
	ModifiedDate		DATETIME,
	ModifiedBy			NVARCHAR(150)
)
GO

CREATE TABLE Customer
(
	Id		INT IDENTITY(1, 1) PRIMARY KEY,
	Name	NVARCHAR(150) NOT NULL,
	Phone	NVARCHAR(15),
	Address	NVARCHAR(500)
)
GO

CREATE TABLE Orders
(
	Id				INT IDENTITY(1, 1) PRIMARY KEY,
	Code			NVARCHAR(50) NOT NULL,
	CustomerId		INT FOREIGN KEY REFERENCES dbo.Customer(Id),
	DeliveryAddress	NVARCHAR(500),
	Quantity		INT,
	TotalPrice		DECIMAL(18, 2),
	CreatedDate		DATETIME,
	CreatedBy		NVARCHAR(150),
	ModifiedDate	DATETIME,
	ModifiedBy		NVARCHAR(150)
)
GO

CREATE TABLE OrderDetail
(
	Id			INT IDENTITY(1, 1) PRIMARY KEY,
	OrderId		INT FOREIGN KEY REFERENCES dbo.Orders(Id),
	ProductId	INT FOREIGN KEY REFERENCES dbo.Product(Id),
	Quantity	INT
)
GO

CREATE TABLE Subscriber
(
	Id			INT IDENTITY(1, 1) PRIMARY KEY,
	Email		NVARCHAR(150),
	CreatedDate	DATETIME,
)
GO

CREATE TABLE SystemSetting
(
	SettingKey			NVARCHAR(50) PRIMARY KEY,
	SettingValue		NVARCHAR(MAX),
	SettingDescription	NVARCHAR(250)
)
GO

--CREATE TABLE A
--(
--	Id	INT IDENTITY(1, 1) PRIMARY KEY
--)
--GO

--# Custom Numeric format strings #

--DECLARE @d DATE = GETDATE();
--SELECT	FORMAT(@d, 'dd/MM/yyyy', 'en-US' ) AS 'Date',
--		FORMAT(123456789,'###-##-####') AS 'Custom Number';

--DECLARE @p DECIMAL = 69000;
--SELECT	FORMAT(@p, 'C', 'vi-VN' ) AS 'Currency'

--# Drop DB #

--USE master
--GO

--DROP DATABASE ThuongMaiDienTu