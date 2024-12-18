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



SELECT *
  FROM [MD&SMDB].[dbo].[CRUD] WHERE (Action_ID = 1)

SELECT Position_Name
  FROM [MD&SMDB].[dbo].[Position]

DELETE FROM [MD&SMDB].[dbo].[CRUD] WHERE (Action_ID = 1)

UPDATE [MD&SMDB].[dbo].[CRUD] SET Action_ID = 1 WHERE (Action_ID = 2);

SELECT *
  FROM [MD&SMDB].[dbo].[Room] ORDER BY [Description] DESC

SELECT *
  FROM [MD&SMDB].[dbo].[Room] ORDER BY [Description] ASC

SELECT Category_ID, SUM(Capacity) AS "Total Capacity"
  FROM [MD&SMDB].[dbo].[Room] GROUP BY Category_ID





















