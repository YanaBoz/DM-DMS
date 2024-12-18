SELECT [Reservation].Reservation_ID, is_completed
  FROM [MD&SMDB].[dbo].[Reservation] INNER JOIN [MD&SMDB].[dbo].[Payment] ON ([Reservation].Reservation_ID = [Payment].Reservation_ID) 
  WHERE is_completed = 1 AND [Reservation].Reservation_ID = 1

SELECT Promo_ID, Code, Discount_Value, [Discount].Discount_ID, Dicount_Type
  FROM [MD&SMDB].[dbo].[PromoCode] INNER JOIN [MD&SMDB].[dbo].[Discount] ON ([PromoCode].Discount_ID = [Discount].Discount_ID)

SELECT Position_Name, CONCAT(First_Name, ' ', Last_Name, ' ', Patronymic) AS '‘»Œ'
  FROM [MD&SMDB].[dbo].[EmployeePosition] LEFT JOIN [MD&SMDB].[dbo].[Client] ON ([EmployeePosition].Employee_ID = [Client].Client_ID) 
                                          LEFT JOIN [MD&SMDB].[dbo].[Position] ON ([EmployeePosition].Position_ID = [Position].Position_ID) 

SELECT Email, COUNT(DISTINCT Position_Name) AS 'count'
  FROM (SELECT Position_Name, Email
  FROM [MD&SMDB].[dbo].[Position] FULL JOIN [MD&SMDB].[dbo].[EmployeePosition] ON ([EmployeePosition].Position_ID = [Position].Position_ID) 
                                  RIGHT JOIN [MD&SMDB].[dbo].[Client] ON ([EmployeePosition].Employee_ID = [Client].Client_ID)
								  RIGHT JOIN [MD&SMDB].[dbo].[User] ON ([Client].[User_ID] = [User].[User_ID]) WHERE Email is not NULL) AS [File] GROUP BY Email

SELECT *
  FROM [MD&SMDB].[dbo].[Payment]
SELECT *
  FROM [MD&SMDB].[dbo].[Reservation]

SELECT *
  FROM [MD&SMDB].[dbo].[EmployeePosition]

SELECT *
  FROM [MD&SMDB].[dbo].[Position]

SELECT *
  FROM [MD&SMDB].[dbo].[Contact]

SELECT *
  FROM [MD&SMDB].[dbo].[CRUD] 

SELECT *
  FROM [MD&SMDB].[dbo].[Client]

SELECT *
  FROM [MD&SMDB].[dbo].[Data]

SELECT *
  FROM [MD&SMDB].[dbo].[Action]

SELECT *
  FROM [MD&SMDB].[dbo].[User]

SELECT *
  FROM [MD&SMDB].[dbo].[About]

SELECT *
  FROM [MD&SMDB].[dbo].[Vacancy]

SELECT *
  FROM [MD&SMDB].[dbo].[News]

SELECT *
  FROM [MD&SMDB].[dbo].[Room]

SELECT *
  FROM [MD&SMDB].[dbo].[RoomCategory]

SELECT *
  FROM [MD&SMDB].[dbo].[PromoCode]

SELECT *
  FROM [MD&SMDB].[dbo].[Discount]