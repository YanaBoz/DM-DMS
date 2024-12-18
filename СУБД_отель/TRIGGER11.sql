CREATE TRIGGER Summary 
ON [MDSMDB].[dbo].[Reservation]
AFTER INSERT
AS
BEGIN 
   UPDATE [MDSMDB].[dbo].[Reservation]
   SET Final_Price = DATEDIFF (day, Arrival_Date, Departure_Date) * (
   SELECT Price 
     From [MDSMDB].[dbo].[RoomCategory] INNER JOIN [MDSMDB].[dbo].[Room] ON ([RoomCategory].Category_ID = [Room].Category_ID)
	                                     INNER JOIN [MDSMDB].[dbo].[Reservation] ON ([Reservation].Room_ID = [Room].Room_ID) WHERE [Room].Room_ID = (SELECT Room_ID FROM inserted) AND Reservation_ID = (SELECT Reservation_ID FROM inserted)) WHERE Reservation_ID = (SELECT Reservation_ID FROM inserted)
END