CREATE TABLE [dbo].[Book]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(1024) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [PublicationDate] DATETIME2 NULL, 
    [Rating] FLOAT NULL CHECK([Rating] BETWEEN 1 AND 5), 
    [ImageLink] NVARCHAR(MAX) NULL,
    [PublishingHouseId] UNIQUEIDENTIFIER NULL,
    FOREIGN KEY ([PublishingHouseId]) REFERENCES PublishingHouse(Id) 
)
