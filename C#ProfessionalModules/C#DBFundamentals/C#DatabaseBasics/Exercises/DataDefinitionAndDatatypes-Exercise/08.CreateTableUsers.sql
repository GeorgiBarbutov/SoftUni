CREATE TABLE Users
(
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX), 
	LastLoginTime DATETIME2,
	IsDeleted BIT
)


INSERT INTO Users VALUES
('AAA', 'Adsds', NULL, CONVERT(datetime,'Sep 19 12:18:52 2014'), 1),
('BB', 'bbb', NULL, CONVERT(datetime,'Sep 09 11:18:52 2014'), 1),
('AAC', 'ARewe', NULL, CONVERT(datetime,'Sep 09 12:17:52 2014'), 1),
('AVCD', 'Zaks', NULL, CONVERT(datetime,'Sep 09 12:18:51 2014'), 0),
('dsd', 'Kakshkavalka', NULL, CONVERT(datetime,'Sep 09 12:18:52 2013'), 0)