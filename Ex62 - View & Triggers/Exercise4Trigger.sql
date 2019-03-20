CREATE TRIGGER AfterDeleteCustomer
ON dbo.EX62_Customer
AFTER DELETE
AS
    DECLARE @customerId INT;
    DECLARE @fname NVARCHAR(40);
    DECLARE @lname NVARCHAR(40);
    DECLARE @zip NVARCHAR(40);

    SELECT @customerId = d.Customer_Id FROM DELETED d;
    SELECT @fname = d.FName FROM DELETED d;
    SELECT @lname = d.LName FROM DELETED d;
    SELECT @zip = d.Zip FROM DELETED d;

    INSERT INTO EX62_DeletedCustomer
    VALUES (@customerId, @fname, @lname, @zip);