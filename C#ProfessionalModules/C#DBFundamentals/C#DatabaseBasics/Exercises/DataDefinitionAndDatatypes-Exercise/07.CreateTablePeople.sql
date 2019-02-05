CREATE TABLE People
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX),
	Height DECIMAL(15, 2),
	[Weight] DECIMAL (15, 2),
	Gender CHAR(2) NOT NULL,
	Birthdate DATETIME2 NOT NULL,
	Biography NVARCHAR(MAX) 
)

INSERT INTO People VALUES
('AAA', NULL, 12.3, 15.3, 'm', CONVERT(datetime,'Sep 09 12:18:52 2014'), 'No biography'),
('BBB', NULL, 12.4, 14.3, 'f', CONVERT(datetime,'Sep 09 12:18:52 2014'), 'No biography'),
('CCC', NULL, 12.5, 13.3, 'm', CONVERT(datetime,'Sep 09 12:18:52 2014'), 'No biography'),
('VVV', NULL, 12.6, 12.3, 'f', CONVERT(datetime,'Sep 09 12:18:52 2014'), 'No biography'),
('XXX', NULL, 12.7, 11.3, 'm', CONVERT(datetime,'Sep 09 12:18:52 2014'), 'No biography')