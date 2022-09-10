INSERT INTO [dbo].[PublishingHouse]
           ([Id]
           ,[Name])
     VALUES
           ('e97bf625-d236-4157-89d5-6b7024cdd058'
           ,'Minsk publisher'),
		   ('1e1b696d-ccd1-47fe-8d9e-6a481e8c5278'
           ,'New York Publishing House')
GO

INSERT INTO [dbo].[Book]
           ([Id]
           ,[Name]
           ,[Description]
           ,[PublicationDate]
           ,[Rating]
           ,[ImageLink]
           ,[PublishingHouseId])
     VALUES
           ('4127d9fd-8e88-45b3-b125-bdc48125d3de'
           ,'Windows Runtime via C#'
           ,'Delve inside the Windows Runtime - and learn best ways to design and build Windows Store apps. Guided by Jeffrey Richter, a recognized expert in Windows and .NET programming, along with principal Windows consultant Maarten van de Bospoort, you will master essential concepts. And you will gain practical insights and tips for how to architect, design, optimize, and debug your apps.'
           ,'2015-01-1'
           ,5
           ,'/images/img1.jpg'
           ,'e97bf625-d236-4157-89d5-6b7024cdd058'),
		    ('34e522d2-2dd7-4cb3-9e56-af7727f3093b'
           ,'Python Cookbook'
           ,'If you need help writing programs in Python 3, or want to update older Python 2 code, this book is just the ticket. Packed with practical recipes written and tested with Python 3.3, this unique cookbook is for experienced Python programmers who want to focus on modern tools and idioms.'
           ,'2019-03-10'
           ,4
           ,'/images/img2.jpg'
           ,'e97bf625-d236-4157-89d5-6b7024cdd058'),
		    ('422f66fe-9e32-4ca3-ab44-c44c37de0177'
           ,'Programming Python'
           ,'If you have mastered Pythons fundamentals, you are ready to start using it to get real work done. Programming Python will show you how, with in-depth tutorials on the languages primary application domains: system administration, GUIs, and the Web. You will also explore how Python is used in databases, networking, front-end scripting layers, text processing, and more. This book focuses on commonly used tools and libraries to give you a comprehensive understanding of Python’s many roles in practical, real-world programming.'
           ,'2016-01-1'
           ,3
           ,'/images/img3.jpg'
           ,'e97bf625-d236-4157-89d5-6b7024cdd058'),
		    ('712780b9-30b2-49bb-8e16-43213e2e2ba7'
           ,'JavaScript for impatient programmers'
           ,'This book makes JavaScript less challenging to learn for newcomers, by offering a modern view that is as consistent as possible.'
           ,'2015-01-1'
           ,5
           ,'/images/img4.jpg'
           ,NULL),
		    ('d645ad9f-c737-4318-b552-fde6088fd9c3'
           ,'Learning JavaScript'
           ,'This is an exciting time to learn JavaScript. Now that the latest JavaScript specification—ECMAScript 6.0 (ES6)—has been finalized, learning how to develop high-quality applications with this language is easier and more satisfying than ever. This practical book takes programmers (amateurs and pros alike) on a no-nonsense tour of ES6, along with some related tools and techniques.'
           ,'2015-01-1'
           ,5
           ,'/images/img5.jpg'
           ,'1e1b696d-ccd1-47fe-8d9e-6a481e8c5278'),
		   ('91b3a4ca-e4d6-456d-8a48-87f65a872b80'
           ,'Windows Runtime via C#. Edition 2'
           ,'Delve inside the Windows Runtime - and learn best ways to design and build Windows Store apps. Guided by Jeffrey Richter, a recognized expert in Windows and .NET programming, along with principal Windows consultant Maarten van de Bospoort, you will master essential concepts. And you will gain practical insights and tips for how to architect, design, optimize, and debug your apps.'
           ,'2015-01-1'
           ,5
           ,'/images/img1.jpg'
           ,'1e1b696d-ccd1-47fe-8d9e-6a481e8c5278'),
		    ('b14237cb-c76a-42b6-987a-39cda9cca19c'
           ,'JavaScript for impatient programmers. Edition 2'
           ,'This book makes JavaScript less challenging to learn for newcomers, by offering a modern view that is as consistent as possible.'
           ,'2015-01-1'
           ,5
           ,'/images/img4.jpg'
           ,'1e1b696d-ccd1-47fe-8d9e-6a481e8c5278')
GO

INSERT INTO [dbo].[Author]
           ([Id]
           ,[Name]
           ,[Surname])
     VALUES
           ('dec1f0c1-01a1-4b53-ab58-08c49cd55e76'
           ,'Axel'
           ,'Rauschmayer'),
		    ('fbeac595-e0b8-414a-b650-840910dc7129'
           ,'Brian'
           ,'Jones'),
		    ('f9e9805e-ed7f-4bf9-baa6-667c0a58ec43'
           ,'David'
           ,'Beazley'),
		    ('4edb4bbf-5e61-432e-9cfc-52000d53c94f'
           ,'Mark'
           ,'Luiz'),
		    ('cc89e987-778e-4639-b825-f63f4a589d72'
           ,'Jeffrey Richter'
           ,'Richter'),
		    ('bfbc5732-8c60-44f8-8d23-f23a794a634c'
           ,'Maarten'
           ,'Bospoort'),
		    ('d2515ada-0dc0-44b2-abde-2038a51f7c74'
           ,'Ethan'
           ,'Brown')
GO

INSERT INTO [dbo].[BookAuthor]
           ([BookId]
           ,[AuthorId])
     VALUES
           ('4127d9fd-8e88-45b3-b125-bdc48125d3de'
           ,'bfbc5732-8c60-44f8-8d23-f23a794a634c'),
		   ('4127d9fd-8e88-45b3-b125-bdc48125d3de'
           ,'cc89e987-778e-4639-b825-f63f4a589d72'),
		   ('91b3a4ca-e4d6-456d-8a48-87f65a872b80'
           ,'bfbc5732-8c60-44f8-8d23-f23a794a634c'),
		   ('91b3a4ca-e4d6-456d-8a48-87f65a872b80'
           ,'cc89e987-778e-4639-b825-f63f4a589d72'),
		   ('34e522d2-2dd7-4cb3-9e56-af7727f3093b'
           ,'f9e9805e-ed7f-4bf9-baa6-667c0a58ec43'),
		   ('34e522d2-2dd7-4cb3-9e56-af7727f3093b'
           ,'fbeac595-e0b8-414a-b650-840910dc7129'),
		   ('422f66fe-9e32-4ca3-ab44-c44c37de0177'
           ,'4edb4bbf-5e61-432e-9cfc-52000d53c94f'),
		   ('712780b9-30b2-49bb-8e16-43213e2e2ba7'
           ,'dec1f0c1-01a1-4b53-ab58-08c49cd55e76'),
		   ('b14237cb-c76a-42b6-987a-39cda9cca19c'
           ,'dec1f0c1-01a1-4b53-ab58-08c49cd55e76'),
		   ('d645ad9f-c737-4318-b552-fde6088fd9c3'
           ,'d2515ada-0dc0-44b2-abde-2038a51f7c74')
GO