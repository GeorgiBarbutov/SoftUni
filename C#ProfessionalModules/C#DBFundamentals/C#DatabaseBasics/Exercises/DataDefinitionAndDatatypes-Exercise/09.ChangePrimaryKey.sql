ALTER TABLE Users
	DROP CONSTRAINT PK__Users__3214EC07812E4207

ALTER TABLE Users
	ADD CONSTRAINT PK_Users PRIMARY KEY(Id, Username)