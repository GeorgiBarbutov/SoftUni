CREATE TABLE Cities
(
	Id INT IDENTITY NOT NULL,
	Name NVARCHAR(20) NOT NULL,
	CountryCode CHAR(2) NOT NULL,

	CONSTRAINT PK_Cities PRIMARY KEY (Id)
)

CREATE TABLE Hotels
(
	Id INT IDENTITY NOT NULL,
	Name NVARCHAR(30) NOT NULL,
	CityId INT NOT NULL,
	EmployeeCount INT NOT NULL,
	BaseRate DECIMAL(15, 2)

	CONSTRAINT PK_Hotels PRIMARY KEY (Id),
	CONSTRAINT FK_Hotels_Cities FOREIGN KEY (CityId) REFERENCES Cities
)

CREATE TABLE Rooms
(
	Id INT IDENTITY NOT NULL,
	Price DECIMAL(15, 2) NOT NULL,
	Type NVARCHAR(20) NOT NULL,
	Beds INT NOT NULL,
	HotelId INT NOT NULL,

	CONSTRAINT PK_Rooms PRIMARY KEY (Id),
	CONSTRAINT FK_Rooms_Hotels FOREIGN KEY (HotelId) REFERENCES Hotels
)

CREATE TABLE Trips
(
	Id INT IDENTITY NOT NULL,
	RoomId INT NOT NULL,
	BookDate DATE NOT NULL,
	ArrivalDate DATE NOT NULL,
	ReturnDate DATE NOT NULL,
	CancelDate DATE

	CONSTRAINT PK_Trips PRIMARY KEY (Id),
	CONSTRAINT FK_Trips_Rooms FOREIGN KEY (RoomId) REFERENCES Rooms,
	CONSTRAINT CK_Trips_BookDate CHECK(DATEDIFF(DAY, BookDate, ArrivalDate) >= 0),
	CONSTRAINT CK_Trips_ArrivalDate CHECK(DATEDIFF(DAY, ArrivalDate, ReturnDate) >= 0)
)

CREATE TABLE Accounts
(
	Id INT IDENTITY NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(20),
	LastName NVARCHAR(50) NOT NULL,
	CityId INT NOT NULL,
	BirthDate DATE NOT NULL,
	Email VARCHAR(100) UNIQUE NOT NULL,

	CONSTRAINT PK_Accounts PRIMARY KEY (Id),
	CONSTRAINT FK_Accounts_Cities FOREIGN KEY (CityId) REFERENCES Cities
)

CREATE TABLE AccountsTrips
(
	AccountId INT NOT NULL,
	TripId INT NOT NULL,
	Luggage INT NOT NULL,

	CONSTRAINT FK_AccountsTrips_Accounts FOREIGN KEY (AccountId) REFERENCES Accounts,
	CONSTRAINT FK_AccountsTrips_Trips FOREIGN KEY (TripId) REFERENCES Trips,
	CONSTRAINT CK_AccountsTrips_Luggage CHECK(Luggage >= 0)
)