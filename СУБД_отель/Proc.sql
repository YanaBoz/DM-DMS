USE [MDSMDB];
GO
CREATE PROCEDURE Reservation_Out AS
BEGIN
    SELECT [Reservation].Reservation_ID, CONCAT(First_Name, ' ', Last_Name, ' ', Patronymic) AS [Name]
	       , [Client].Notes, Discount_Value, Dicount_Type, Room_Number, Arrival_Date, Departure_Date,
           CASE 
		   WHEN [PromoCode].Discount_ID = 1 THEN Final_Price - Final_Price * Discount_Value/100
           WHEN [PromoCode].Discount_ID = 2 THEN Final_Price - Discount_Value
           ELSE Final_Price
           END AS Price
           , Created_At, [Reservation].Notes,
           CASE
           WHEN is_completed = 1 THEN 'paid'
           ELSE 'not paid'
           END AS [Status],
           CASE 
           WHEN GETDATE() > Departure_Date THEN 'available'
		   WHEN is_completed = 0 THEN 'available'
           ELSE 'not available'
           END AS [Available]
  FROM [MDSMDB].[dbo].[Reservation] INNER JOIN [MDSMDB].[dbo].[Payment] ON ([Reservation].Reservation_ID = [Payment].Reservation_ID)
                                     INNER JOIN [MDSMDB].[dbo].[PromoCode] ON ([Reservation].Promo_ID = [PromoCode].Promo_ID)
									 INNER JOIN [MDSMDB].[dbo].[Room] ON ([Room].Room_ID = [Reservation].Room_ID)
									 INNER JOIN [MDSMDB].[dbo].[Discount] ON ([PromoCode].Discount_ID = [Discount].Discount_ID)
									 INNER JOIN [MDSMDB].[dbo].[Client] ON ([Client].Client_ID = [Reservation].Client_ID)
END;