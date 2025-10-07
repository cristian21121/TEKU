USE [API]
GO
SET IDENTITY_INSERT [dbo].[COUNTRY] ON 
GO
INSERT [dbo].[COUNTRY] ([Id], [Code], [Name]) VALUES (1, N'COL', N'Colombia')
GO
INSERT [dbo].[COUNTRY] ([Id], [Code], [Name]) VALUES (2, N'USA', N'United States of America')
GO
INSERT [dbo].[COUNTRY] ([Id], [Code], [Name]) VALUES (3, N'ALB', N'Albania')
GO
INSERT [dbo].[COUNTRY] ([Id], [Code], [Name]) VALUES (4, N'AND', N'Andorra')
GO
INSERT [dbo].[COUNTRY] ([Id], [Code], [Name]) VALUES (5, N'ARG', N'Argentina')
GO
INSERT [dbo].[COUNTRY] ([Id], [Code], [Name]) VALUES (6, N'AZE', N'Azerbaijan')
GO
INSERT [dbo].[COUNTRY] ([Id], [Code], [Name]) VALUES (7, N'BRA', N'Brazil')
GO
INSERT [dbo].[COUNTRY] ([Id], [Code], [Name]) VALUES (8, N'KWT', N'Kuwait')
GO
INSERT [dbo].[COUNTRY] ([Id], [Code], [Name]) VALUES (9, N'PRT', N'Portugal')
GO
INSERT [dbo].[COUNTRY] ([Id], [Code], [Name]) VALUES (10, N'GRC', N'Greece')
GO
INSERT [dbo].[COUNTRY] ([Id], [Code], [Name]) VALUES (11, N'TTO', N'Trinidad and Tobago')
GO
INSERT [dbo].[COUNTRY] ([Id], [Code], [Name]) VALUES (12, N'QAT', N'Qatar')
GO
INSERT [dbo].[COUNTRY] ([Id], [Code], [Name]) VALUES (13, N'ROU', N'Romania')
GO
SET IDENTITY_INSERT [dbo].[COUNTRY] OFF
GO
SET IDENTITY_INSERT [dbo].[SUPPLIER] ON 
GO
INSERT [dbo].[SUPPLIER] ([Id], [Nit], [Name], [Email]) VALUES (1, 111111111, N'John', N'john@email.com')
GO
INSERT [dbo].[SUPPLIER] ([Id], [Nit], [Name], [Email]) VALUES (2, 222222222, N'Doe', N'doe@email.com')
GO
INSERT [dbo].[SUPPLIER] ([Id], [Nit], [Name], [Email]) VALUES (3, 333333333, N'janell ', N'janell@email.com')
GO
INSERT [dbo].[SUPPLIER] ([Id], [Nit], [Name], [Email]) VALUES (4, 444444444, N'warner', N'warner@email.com')
GO
INSERT [dbo].[SUPPLIER] ([Id], [Nit], [Name], [Email]) VALUES (5, 555555555, N'sherri', N'sherri@email.com')
GO
INSERT [dbo].[SUPPLIER] ([Id], [Nit], [Name], [Email]) VALUES (6, 666666666, N'freddie', N'freddie@email.com')
GO
INSERT [dbo].[SUPPLIER] ([Id], [Nit], [Name], [Email]) VALUES (7, 777777777, N'deanne', N'deanne@email.com')
GO
INSERT [dbo].[SUPPLIER] ([Id], [Nit], [Name], [Email]) VALUES (8, 888888888, N'earnest', N'earnest@email.com')
GO
INSERT [dbo].[SUPPLIER] ([Id], [Nit], [Name], [Email]) VALUES (9, 999999999, N'ferguson', N'ferguson@email.com')
GO
INSERT [dbo].[SUPPLIER] ([Id], [Nit], [Name], [Email]) VALUES (10, 123111222, N'luann', N'luann@email.com')
GO
SET IDENTITY_INSERT [dbo].[SUPPLIER] OFF
GO
SET IDENTITY_INSERT [dbo].[SERVICE] ON 
GO
INSERT [dbo].[SERVICE] ([Id], [SupplierId], [Name], [HourValue]) VALUES (1, 1, N'Servicio ejemplo 1', CAST(1001.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[SERVICE] ([Id], [SupplierId], [Name], [HourValue]) VALUES (2, 2, N'Servicio 1', CAST(10.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[SERVICE] ([Id], [SupplierId], [Name], [HourValue]) VALUES (3, 3, N'Janell servicio', CAST(100.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[SERVICE] ([Id], [SupplierId], [Name], [HourValue]) VALUES (4, 4, N'warner service', CAST(1010.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[SERVICE] ([Id], [SupplierId], [Name], [HourValue]) VALUES (5, 5, N'Servicio 1', CAST(111.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[SERVICE] ([Id], [SupplierId], [Name], [HourValue]) VALUES (6, 6, N'freddie service', CAST(20.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[SERVICE] ([Id], [SupplierId], [Name], [HourValue]) VALUES (7, 7, N'deanne servicio 11', CAST(170.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[SERVICE] ([Id], [SupplierId], [Name], [HourValue]) VALUES (8, 8, N'earnest servicio', CAST(555.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[SERVICE] ([Id], [SupplierId], [Name], [HourValue]) VALUES (9, 9, N'ferguson servicio 9', CAST(984.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[SERVICE] ([Id], [SupplierId], [Name], [HourValue]) VALUES (10, 10, N'luann servicio 01', CAST(1001.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[SERVICE] OFF
GO
INSERT [dbo].[ServiceCountries] ([ServiceId], [CountryId]) VALUES (1, 1)
GO
INSERT [dbo].[ServiceCountries] ([ServiceId], [CountryId]) VALUES (2, 2)
GO
INSERT [dbo].[ServiceCountries] ([ServiceId], [CountryId]) VALUES (2, 3)
GO
INSERT [dbo].[ServiceCountries] ([ServiceId], [CountryId]) VALUES (3, 4)
GO
INSERT [dbo].[ServiceCountries] ([ServiceId], [CountryId]) VALUES (4, 4)
GO
INSERT [dbo].[ServiceCountries] ([ServiceId], [CountryId]) VALUES (4, 5)
GO
INSERT [dbo].[ServiceCountries] ([ServiceId], [CountryId]) VALUES (4, 6)
GO
INSERT [dbo].[ServiceCountries] ([ServiceId], [CountryId]) VALUES (5, 7)
GO
INSERT [dbo].[ServiceCountries] ([ServiceId], [CountryId]) VALUES (7, 8)
GO
INSERT [dbo].[ServiceCountries] ([ServiceId], [CountryId]) VALUES (8, 9)
GO
INSERT [dbo].[ServiceCountries] ([ServiceId], [CountryId]) VALUES (8, 10)
GO
INSERT [dbo].[ServiceCountries] ([ServiceId], [CountryId]) VALUES (8, 11)
GO
INSERT [dbo].[ServiceCountries] ([ServiceId], [CountryId]) VALUES (9, 12)
GO
INSERT [dbo].[ServiceCountries] ([ServiceId], [CountryId]) VALUES (10, 13)
GO
SET IDENTITY_INSERT [dbo].[CUSTOM_FIELD] ON 
GO
INSERT [dbo].[CUSTOM_FIELD] ([Id], [SupplierId], [Name], [Value]) VALUES (1, 1, N'Campo personalizado 1', N'Valor 1')
GO
INSERT [dbo].[CUSTOM_FIELD] ([Id], [SupplierId], [Name], [Value]) VALUES (2, 2, N'Campo personalizado', N'Valor 1')
GO
INSERT [dbo].[CUSTOM_FIELD] ([Id], [SupplierId], [Name], [Value]) VALUES (3, 4, N'Campo 1', N'Valor 01')
GO
INSERT [dbo].[CUSTOM_FIELD] ([Id], [SupplierId], [Name], [Value]) VALUES (4, 4, N'Campo 02', N'Valor 2')
GO
INSERT [dbo].[CUSTOM_FIELD] ([Id], [SupplierId], [Name], [Value]) VALUES (5, 5, N'Campo personalizado 01', N'Valor del campo 01')
GO
INSERT [dbo].[CUSTOM_FIELD] ([Id], [SupplierId], [Name], [Value]) VALUES (6, 6, N'Campo1', N'Valor111')
GO
INSERT [dbo].[CUSTOM_FIELD] ([Id], [SupplierId], [Name], [Value]) VALUES (7, 7, N'Numero campo personalizado', N'+67 584 65874 564')
GO
INSERT [dbo].[CUSTOM_FIELD] ([Id], [SupplierId], [Name], [Value]) VALUES (8, 8, N'Campo', N'Valor campo')
GO
INSERT [dbo].[CUSTOM_FIELD] ([Id], [SupplierId], [Name], [Value]) VALUES (9, 9, N'Campo ferguson', N'Valor ferguson')
GO
INSERT [dbo].[CUSTOM_FIELD] ([Id], [SupplierId], [Name], [Value]) VALUES (10, 10, N'luann campo personalizado', N'548541674 test')
GO
SET IDENTITY_INSERT [dbo].[CUSTOM_FIELD] OFF
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20251006170009_Init', N'9.0.9')
GO
