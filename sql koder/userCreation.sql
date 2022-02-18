USE webshop
GO

-- Generate a salt and md5 hash for the password!

-- Salt should be generated uniquely
DECLARE @salt as VARCHAR(8)= '12345678'
DECLARE @password as VARCHAR(32) = CONCAT(CONVERT(NVARCHAR(32), HashBytes('MD5', '12312345678'), 2), @salt)

-- Insert a new user
INSERT INTO Users VALUES ('Administratör', 'admin', @password, @salt)