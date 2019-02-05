CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(50) NOT NULL,
	DailyRate INT NOT NULL,
	WeeklyRate INT NOT NULL,
	MonthlyRate INT NOT NULL,
	WeekendRate INT NOT NULL
)

INSERT INTO Categories VALUES
('Category1', 2, 14, 60, 4),
('Category2', 2, 15, 60, 4),
('Category2', 2, 14, 65, 4)

CREATE TABLE Cars
(
	Id INT PRIMARY KEY IDENTITY,
	PlateNumber INT NOT NULL,
	Manufacturer NVARCHAR(50) NOT NULL,
	Model NVARCHAR(50) NOT NULL,
	CarYear INT NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	Doors INT NOT NULL,
	Picture VARBINARY(MAX),
	Condition NVARCHAR(MAX),
	Available BIT
)

INSERT INTO Cars VALUES
(1111, 'Lamborghini', 'Aventador', 2017, 1, 2, NULL, 'Perfect Condition', 1),
(1112, 'Lamborghini', 'Aventador', 2017, 1, 2, NULL, 'Perfect Condition', 1),
(1113, 'Lamborghini', 'Aventador', 2017, 1, 2, NULL, 'Perfect Condition', 0)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Employees VALUES
('Georgi', 'Georgiev', 'Janitor', 'No Notes'),
('Ivan', 'Georgiev', 'Janitor', 'No Notes'),
('Stavri', 'Georgiev', 'Janitor', 'No Notes')

CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY,
	DriverLicenceNumber INT NOT NULL,
	FullName NVARCHAR(50) NOT NULL,
	[Address] NVARCHAR(MAX) NOT NULL,
	City NVARCHAR(50) NOT NULL,
	ZipCode INT NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Customers VALUES
(1111, 'Georgi Georgiev', 'Neznaen', 'Sofia', 1700, 'No Notes'),
(1121, 'Sevo Georgiev', 'Neznaen', 'Sofia', 1700, 'No Notes'),
(4111, 'Vasil Georgiev', 'Neznaen', 'Sofia', 1700, 'No Notes')

CREATE TABLE RentalOrders
(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL,
	CarId INT FOREIGN KEY REFERENCES Cars(Id) NOT NULL,
	TankLevel INT NOT NULL,
	KilometrageStart INT NOT NULL,
	KilometrageEnd INT NOT NULL,
	TotalKilometrage INT NOT NULL,
	StartDate DATETIME2,
	EndDate DATETIME2,
	TotalDays INT,
	RateApplied DECIMAL(15, 2),
	TaxRate DECIMAL(15, 2),
	OrderStatus BIT NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO RentalOrders VALUES
(1, 1, 1, 1, 0, 1000, 1000, NULL, NULL, NULL, 3.4, 3.4, 1, 'No Notes'),
(1, 2, 1, 1, 0, 1000, 1000, NULL, NULL, NULL, 3.4, 3.4, 1, 'No Notes'),
(1, 3, 1, 1, 0, 1000, 1000, NULL, NULL, NULL, 3.4, 3.4, 1, 'No Notes')