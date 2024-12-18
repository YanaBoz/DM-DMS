CREATE TRIGGER Age_Invalid
ON [MDSMDB].[dbo].[User]
AFTER INSERT
AS 
BEGIN 
   IF ((SELECT TOP(1) Age FROM [MDSMDB].[dbo].[User] ORDER BY User_ID DESC) < 18)
    BEGIN
        RAISERROR('You must be 18 or older to register.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END