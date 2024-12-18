SELECT [Reservation].Reservation_ID, 
CASE WHEN Final_Price > 500 THEN 'много стоит'
WHEN Final_Price < 500 THEN 'мало стоит'
ELSE 'ничего не стоит'
END AS Price, Notes, Payment_Date
  FROM [MD&SMDB].[dbo].[Reservation] INNER JOIN [MD&SMDB].[dbo].[Payment] ON ([Reservation].Reservation_ID = [Payment].Reservation_ID) WHERE is_completed = 1 OR is_completed = 0

SELECT Reservation_ID, Email, [Contact].First_Name, [Client].Last_Name, [Contact].Patronymic, Code, [Room].[Description], Created_At
  FROM [MD&SMDB].[dbo].[Reservation] RIGHT  JOIN [MD&SMDB].[dbo].[Client] ON ([Reservation].Client_ID = [Client].Client_ID) 
                                     INNER JOIN [MD&SMDB].[dbo].[PromoCode] ON ([Reservation].Promo_ID = [PromoCode].Promo_ID) 
                                     FULL  JOIN [MD&SMDB].[dbo].[Room] ON ([Reservation].Room_ID = [Room].Room_ID)      
                                     FULL  JOIN [MD&SMDB].[dbo].[User] ON ([Client].[User_ID] = [User].[User_ID])
									 FULL  JOIN [MD&SMDB].[dbo].[Contact] ON ( [User].[User_ID] = [Contact].[User_ID])

SELECT Position_Name, CONCAT(First_Name, ' ', Last_Name, ' ', Patronymic) AS 'ФИО'
  FROM [MD&SMDB].[dbo].[EmployeePosition] LEFT JOIN [MD&SMDB].[dbo].[Client] ON ([EmployeePosition].Employee_ID = [Client].Client_ID) 
                                          LEFT JOIN [MD&SMDB].[dbo].[Position] ON ([EmployeePosition].Position_ID = [Position].Position_ID) 

SELECT Email, COUNT(DISTINCT Position_Name) AS 'count'
  FROM (SELECT Position_Name, Email
  FROM [MD&SMDB].[dbo].[Position] FULL JOIN [MD&SMDB].[dbo].[EmployeePosition] ON ([EmployeePosition].Position_ID = [Position].Position_ID) 
                                  RIGHT JOIN [MD&SMDB].[dbo].[Client] ON ([EmployeePosition].Employee_ID = [Client].Client_ID)
								  RIGHT JOIN [MD&SMDB].[dbo].[User] ON ([Client].[User_ID] = [User].[User_ID]) WHERE Email is not NULL) AS [File] GROUP BY Email

SELECT [User].[User_ID], Amount, is_completed, Created_At, CONCAT([Client].First_Name, ' ', [Client].Last_Name, ' ', [Client].Patronymic) AS 'ФИО', Code, [PromoCode].[Description], Room_Number, [Room].[Description], Email
  FROM [MD&SMDB].[dbo].[Payment] FULL JOIN [MD&SMDB].[dbo].[Reservation] ON ([Reservation].Reservation_ID = [Payment].Reservation_ID)
                                 FULL JOIN [MD&SMDB].[dbo].[Client] ON ([Reservation].Client_ID = [Client].Client_ID) 
								 FULL JOIN [MD&SMDB].[dbo].[PromoCode] ON ([Reservation].Promo_ID = [PromoCode].Promo_ID) 
								 FULL JOIN [MD&SMDB].[dbo].[Room] ON ([Reservation].Room_ID = [Room].Room_ID)      
                                 FULL JOIN [MD&SMDB].[dbo].[User] ON ([Client].[User_ID] = [User].[User_ID])
								 FULL JOIN [MD&SMDB].[dbo].[Contact] ON ( [User].[User_ID] = [Contact].[User_ID])
                                 FULL JOIN [MD&SMDB].[dbo].[EmployeePosition] ON ([EmployeePosition].Employee_ID = [Client].Client_ID) 
								 FULL JOIN [MD&SMDB].[dbo].[Position] ON ([EmployeePosition].Position_ID = [Position].Position_ID)
								 FULL JOIN [MD&SMDB].[dbo].[RoomCategory] ON ([RoomCategory].Category_ID = [Room].Category_ID)
								 FULL JOIN [MD&SMDB].[dbo].[Discount] ON ([Discount].Discount_ID = [PromoCode].Discount_ID)

SELECT A.Client AS '1_Client_ID', A.Action_ID AS '1_Action_ID', B.Client AS '2_Client_ID', B.Action_ID AS '2_Action_ID'
  FROM [MD&SMDB].[dbo].[CRUD] A JOIN [MD&SMDB].[dbo].[CRUD] B ON (A.Data_ID= B.Data_ID) WHERE A.Action_ID <> B.Action_ID;

SELECT *
  FROM [MD&SMDB].[dbo].[About] CROSS JOIN [MD&SMDB].[dbo].[Vacancy] 

SELECT *
  FROM [MD&SMDB].[dbo].[User] FULL OUTER JOIN  [MD&SMDB].[dbo].[Client] ON ([Client].[User_ID] = [User].[User_ID])

SELECT *
  FROM [MD&SMDB].[dbo].[News] WHERE Title LIKE '%en%' AND Image LIKE '%.jpg' ORDER BY Content DESC

SELECT Email, COUNT( Position_Name) OVER (PARTITION BY Email) AS 'count', 
row_number() over (partition by Email order by Email asc) AS 'ROW',
rank() over (partition by Email order by Email asc) AS 'RANK',
dense_rank() over (partition by Email order by Email asc) AS 'DENS'
  FROM (SELECT Position_Name, Email
  FROM [MD&SMDB].[dbo].[Position] FULL JOIN [MD&SMDB].[dbo].[EmployeePosition] ON ([EmployeePosition].Position_ID = [Position].Position_ID) 
                                  RIGHT JOIN [MD&SMDB].[dbo].[Client] ON ([EmployeePosition].Employee_ID = [Client].Client_ID)
								  RIGHT JOIN [MD&SMDB].[dbo].[User] ON ([Client].[User_ID] = [User].[User_ID]) WHERE Email is not NULL) AS [File]

SELECT Num, Email, [count], 
row_number() over (partition by Email order by Email asc) AS 'ROW',
rank() over (partition by Num order by [count] DESC) AS 'RANK',
dense_rank() over (partition by Num order by Email ASC) AS 'DENS'
FROM
(SELECT '1' AS 'Num', Email, COUNT( Position_Name) OVER (PARTITION BY Email) AS 'count'
  FROM
(SELECT Position_Name, Email
  FROM [MD&SMDB].[dbo].[Position] FULL JOIN [MD&SMDB].[dbo].[EmployeePosition] ON ([EmployeePosition].Position_ID = [Position].Position_ID) 
                                  RIGHT JOIN [MD&SMDB].[dbo].[Client] ON ([EmployeePosition].Employee_ID = [Client].Client_ID)
								  RIGHT JOIN [MD&SMDB].[dbo].[User] ON ([Client].[User_ID] = [User].[User_ID]) WHERE Email is not NULL) AS [File] ) AS [File2]

SELECT Category_ID, SUM(Room_Number) AS 'nu', SUM(Capacity) AS 'na'
  FROM [MD&SMDB].[dbo].[Room] WHERE Capacity > 2 GROUP BY Category_ID HAVING Category_ID > 2

SELECT [User_ID]
  FROM [MD&SMDB].[dbo].[User]

SELECT [User_ID]
  FROM [MD&SMDB].[dbo].[Client]

SELECT [User_ID]
  FROM [MD&SMDB].[dbo].[User]
UNION
SELECT [User_ID]
  FROM [MD&SMDB].[dbo].[Client]

SELECT [User_ID]
  FROM [MD&SMDB].[dbo].[User]
EXCEPT
SELECT [User_ID]
  FROM [MD&SMDB].[dbo].[Client]

SELECT [User_ID]
  FROM [MD&SMDB].[dbo].[User]
INTERSECT
SELECT [User_ID]
  FROM [MD&SMDB].[dbo].[Client]

SELECT *
  FROM [MD&SMDB].[dbo].[Client] WHERE EXISTS ( SELECT [User_ID]
  FROM [MD&SMDB].[dbo].[User])

INSERT INTO [MD&SMDB].[dbo].[Client] 
SELECT [MD&SMDB].[dbo].[User].[User_ID], 'David', 'Jonson', 'Olegovich', 'Notes for David', '+1(555)123-6767', 0
  FROM [MD&SMDB].[dbo].[User]  LEFT JOIN [MD&SMDB].[dbo].[Client] ON ([User].[User_ID] = [Client].[User_ID]) 
  WHERE [User].[User_ID] != ALL(SELECT [User_ID] FROM [MD&SMDB].[dbo].[Client]);

SELECT * 
  FROM [MD&SMDB].[dbo].[Client] 