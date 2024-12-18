INSERT INTO [dbo].[About]
     VALUES
           ('Welcome to Our Hotel'
           ,'hotel.mp4'
           ,'hotel.jpg'
           ,'Our hotel was founded in 1965 by John and Mary Smith.'
           ,'We offer a variety of amenities and services to our guests.'
		   ,'cert.jpg')
GO

INSERT INTO [dbo].[User]
     VALUES
            ('admin'
           ,'password'
           ,30
           ,'admin@hotel.com')
GO
INSERT INTO [dbo].[User]
     VALUES
		   ('john'
           ,'password'
           ,25
           ,'john@hotel.com')
GO
INSERT INTO [dbo].[User]
     VALUES
		   ('mary'
           ,'password'
           ,28
           ,'mary@hotel.com')
GO

INSERT INTO [dbo].[Client]
     VALUES
           (2
           ,'John'
           ,'Smith'
           ,'Petrovich'
           ,'Notes for John'
           ,'+1(555)123-4567'
           , 0),
		   (3
           ,'Mary'
           ,'Johnson'
           ,'Ivanovna'
           ,'Notes for Mary'
           ,'+1(555)234-5678'
           , 1)
GO

INSERT INTO [dbo].[Contact]
     VALUES
            (2
           ,'John'
           ,'Smith'
           ,'Petrovich'
           ,'Contact for John'
           ,'john.jpg'),
		   (3
           ,'Mary'
           ,'Johnson'
           ,'Ivanovna'
           ,'Contact for Mary'
           ,'mary.jpg')
GO

INSERT INTO [dbo].[News]
     VALUES
            ('Hotel Renovation'
			,'We are excited to announce that our hotel is undergoing a major renovation.'
			,'renovation.jpg'
			,'2023-03-08'),
			('New Restaurant Open'
			,'We are pleased to announce the opening of our new restaurant, The Dining Room.'
			,'diningroom.jpg'
			,'2023-04-15')
GO

INSERT INTO [dbo].[Vacancy]
     VALUES
            ('Front Desk Agent'
			,'We are looking for a friendly and outgoing front desk agent to join our team.'
			,'2'),
			('Supervisor'
			,'We are seeking a highly motivated and experienced housekeeping supervisor to oversee our housekeeping team.'
			,'1')
GO

INSERT INTO [dbo].[Discount]
     VALUES
            ('Percentage'),
			('Flat Amount')
GO

INSERT INTO [dbo].[RoomCategory]
     VALUES
            ('Standard'
			,100.25),
			('Deluxe'
			,150.25),
			('Suite'
			,170.25)
GO

INSERT INTO [dbo].[PromoCode]
     VALUES
            (1
			,'SUMMER10'
			,'10% off summer stays'
			,10),
			(2
			,'FALL15'
			,'15.25 off fall stays'
			,15.25)
GO

INSERT INTO [dbo].[Room]
     VALUES
            (1
			,101
			,2
			,'Standard room with a double bed'
			,'room1.jpg'),
			(1
			,102
			,2
			,'Standard room with two twin beds'
			,'room2.jpg'),
			(2
			,201
			,4
			,'Deluxe room with a king bed and a sofa bed'
			,'room3.jpg'),
			(3
			,202
			,6
			,'Suite with a king bed, a living room, and a kitchenette'
			,'room4.jpg')
GO

--INSERT INTO [dbo].[CRUD]
--     VALUES
--            (1
--			,1
--			,1
--			,'2023-03-08'),
--			(2
--			,2
--			,2
--			,'2023-03-09'),
--			(1
--			,3
--			,1
--			,'2023-03-10'),
--			(2
--			,4
--			,2
--			,'2023-03-11')
--GO

INSERT INTO [dbo].[Position]
     VALUES
            ('Manager'),
			('Receptionist'),
			('Housekeeper')
GO

INSERT INTO [dbo].[EmployeePosition]
     VALUES
            (1
			,1),
			(2
			,2),
			(2
			,3)
GO

INSERT INTO [dbo].[Reservation]
     VALUES
            (1
			,1
			,1
			,'2023-04-01'
			,'2023-04-05'
			, 400.5
			,'2023-03-08'
			,'Notes for reservation 1')
GO

INSERT INTO [dbo].[Reservation]
     VALUES
			(2
			,2
			,2
			,'2023-04-10'
			,'2023-04-14'
			, 600.5
			,'2023-03-09'
			,'Notes for reservation 2')
GO

INSERT INTO [dbo].[Payment]
     VALUES
            (1
			,400.5
			,1
			,'2023-03-08'),
			(2
			,600.5
			,0
			,'2023-03-09')
GO