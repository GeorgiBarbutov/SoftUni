CREATE TABLE Manufacturers
(
	ManufacturerID INT NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	EstablishedOn NVARCHAR(50) NOT NULL,

	CONSTRAINT PK_ManufacturerID
	PRIMARY KEY (ManufacturerID)
)

CREATE TABLE Models
(
	ModelID INT NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	ManufacturerID INT NOT NULL,

	CONSTRAINT PK_ModelID
	PRIMARY KEY(ModelID),
	CONSTRAINT FK_Models_Manufacturers
	FOREIGN KEY (ManufacturerID)
	REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Manufacturers VALUES
(1, 'BMW', '07/07/1996'),
(2, 'Tesla', '01/01/2003'),
(3, 'Lada', '01/051966')

INSERT INTO Models VALUES
(101, 'X1', 1),
(102, 'i6', 1),
(103, 'Model S', 2),
(104, 'Model X', 2),
(105, 'Model 3', 2),
(106, 'Nova', 3)