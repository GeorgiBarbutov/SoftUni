CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Employees VALUES
('Arere', 'Babada', 'NoTitle', NULL),
('Drere', 'Babada', 'NoTitle', NULL),
('Srere', 'Babada', 'NoTitle', NULL)

CREATE TABLE Customers
(
	AccountNumber INT PRIMARY KEY NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	PhoneNumber BIGINT NOT NULL,
	EmergencyName NVARCHAR(50) NOT NULL,
	EmergencyNumber BIGINT NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Customers VALUES
(1, 'ZAZAZA', 'RARARA', 8888888888, 'SSAASS', 9999999999, NULL),
(2, 'PAZAZA', 'RARARA', 8888888888, 'SSAASS', 9999999999, NULL),
(3, 'KAZAZA', 'RARARA', 8888888888, 'SSAASS', 9999999999, NULL)

CREATE TABLE RoomStatus
(
	RoomStatus INT PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO RoomStatus VALUES
(1, 'Notes'),
(2, 'Notes'),
(3, 'Notes')

CREATE TABLE RoomTypes
(
	RoomType INT PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO RoomTypes VALUES
(1, 'Notes'),
(2, 'Notes'),
(3, 'Notes')

CREATE TABLE BedTypes
(
	BedType INT PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO BedTypes VALUES
(1, 'Notes'),
(2, 'Notes'),
(3, 'Notes')

CREATE TABLE Rooms
(
	RoomNumber BIGINT PRIMARY KEY NOT NULL,
	RoomType INT FOREIGN KEY REFERENCES RoomTypes(RoomType) NOT NULL,
	BedType INT FOREIGN KEY REFERENCES BedTypes(BedType) NOT NULL,
	Rate DECIMAL(15, 2) NOT NULL,
	RoomStatus INT FOREIGN KEY REFERENCES RoomStatus(RoomStatus) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Rooms VALUES
(1, 1, 1, 33.5, 1, 'No'),
(2, 2, 2, 33.5, 1, 'No'),
(3, 3, 3, 33.5, 1, 'No')

CREATE TABLE Payments
(
	Id INT PRIMARY KEY NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	PaymentDate DATETIME2,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
	FirstDateOccupied DATETIME2,
    LastDateOccupied DATETIME2,
	TotalDays INT,
    AmountCharged DECIMAL(15, 2) NOT NULL,
	TaxRate DECIMAL(15, 2) NOT NULL,
    TaxAmount DECIMAL(15, 2) NOT NULL,
	PaymentTotal DECIMAL(15, 2) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Payments VALUES
(1, 1, NULL, 1, NULL, NULL, 1, 12.3, 22.2, 22.2, 22.2, NULL),
(2, 2, NULL, 2, NULL, NULL, 1, 12.3, 22.2, 22.2, 22.2, NULL),
(3, 1, NULL, 1, NULL, NULL, 1, 12.3, 22.2, 22.2, 22.2, NULL)

CREATE TABLE Occupancies
(
	Id INT PRIMARY KEY IDENTITY,
    EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL, 
	DateOccupied DATETIME2, 
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
	RoomNumber BIGINT FOREIGN KEY REFERENCES Rooms(RoomNumber) NOT NULL, 
	RateApplied DECIMAL(15, 2) NOT NULL,
	PhoneCharge DECIMAL(15, 2) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Occupancies VALUES
(1, NULL, 1, 1, 22.4, 33.2, NULL),
(2, NULL, 2, 2, 22.4, 33.2, NULL),
(3, NULL, 3, 3, 22.4, 33.2, NULL)