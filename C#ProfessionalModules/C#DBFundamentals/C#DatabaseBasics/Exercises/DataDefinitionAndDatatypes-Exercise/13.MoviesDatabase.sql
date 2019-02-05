CREATE TABLE Directors
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX) 
)

INSERT INTO Directors VALUES
('Director1', NULL),
('Director2', 'Hello there'),
('Director3', NULL),
('Director4', NULL),
('Director5', NULL)

CREATE TABLE Genres
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX) 
)

INSERT INTO Genres VALUES
('Genre1', NULL),
('Genre2', 'Hello there'),
('Genre3', NULL),
('Genre4', NULL),
('Genre5', NULL)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX) 
)

INSERT INTO Categories VALUES
('Categorie1', NULL),
('Categorie2', 'Hello there'),
('Categorie3', NULL),
('Categorie4', NULL),
('Categorie5', NULL)

CREATE TABLE Movies
(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(50) NOT NULL,
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL,
	CopyrightYear INT NOT NULL,
	[Length] DECIMAL(15, 2) NOT NULL,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL,
	CategorieId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	Rating DECIMAL(15, 2),
	Notes NVARCHAR(MAX)  
)

INSERT INTO Movies Values
('Title1', 1, 2000, 121.1, 1, 1, 77.5, 'No Notes'),
('Title2', 2, 2001, 131.1, 2, 2, 87.5, 'No Notes'),
('Title3', 3, 2002, 141.1, 3, 3, 67.5, 'No Notes'),
('Title4', 4, 2003, 151.1, 4, 4, 97.5, 'No Notes'),
('Title5', 5, 2004, 111.1, 5, 5, 57.5, 'No Notes')