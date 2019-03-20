DROP TABLE IF EXISTS EX62_DeletedCustomer

CREATE TABLE EX62_DeletedCustomer
(
	--Note no PK or even IDENTITY as data are inserted "as is" 
	Id INTEGER, 
	FName NVARCHAR(40),
	LName NVARCHAR(40),
	Zip NVARCHAR(4)
)

