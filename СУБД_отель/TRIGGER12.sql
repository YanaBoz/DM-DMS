CREATE TRIGGER Reservation_Date
ON [MDSMDB].[dbo].[Reservation]
AFTER INSERT
AS
BEGIN
  IF ((SELECT TOP(1) Arrival_Date FROM [MDSMDB].[dbo].[Reservation] ORDER BY [Reservation_ID] DESC) >= (SELECT TOP(1) Departure_Date FROM [MDSMDB].[dbo].[Reservation] ORDER BY [Reservation_ID] DESC))
  BEGIN
        RAISERROR('Arrival date can not be after departure date', 16, 1);
        ROLLBACK TRANSACTION;
    END
END