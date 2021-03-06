USE [Calculator.Infrastructure.SqlDatabase]
GO

--создаем таблицу OperationDescription
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OperationDescriptions](
	[OperationDescriptionId] [int] IDENTITY(1,1) NOT NULL,
	[Argument1] [int] NOT NULL,
	[Argument2] [int] NOT NULL,
	[OperationType] [nvarchar](15) NOT NULL,
	[OperationResult] [decimal](18, 2) NOT NULL,
	[OperationTime] [datetime2](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OperationDescriptionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

--создаем хранимую процедуру sp_GetLast5OperationDescription
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetLast5OperationDescriptions] 
AS
SELECT TOP 5 * FROM OperationDescriptions 
ORDER BY OperationTime DESC
GO

--заполняем данными таблицу OperationDescription
SET IDENTITY_INSERT [dbo].[OperationDescriptions] ON
INSERT [dbo].[OperationDescriptions] ([OperationDescriptionId], [Argument1], [Argument2], [OperationType], [OperationResult], [OperationTime]) VALUES (1, 654, 6543, N'Addition', CAST(7197 AS Decimal(18, 0)), CAST(0x07EBB6E98EC780370B AS DateTime2))
INSERT [dbo].[OperationDescriptions] ([OperationDescriptionId], [Argument1], [Argument2], [OperationType], [OperationResult], [OperationTime]) VALUES (2, 43, 543, N'Addition', CAST(586 AS Decimal(18, 0)), CAST(0x0784F34F900081370B AS DateTime2))
INSERT [dbo].[OperationDescriptions] ([OperationDescriptionId], [Argument1], [Argument2], [OperationType], [OperationResult], [OperationTime]) VALUES (3, 2425, 345354, N'Multiplication', CAST(837483450 AS Decimal(18, 0)), CAST(0x07AB303C451281370B AS DateTime2))
INSERT [dbo].[OperationDescriptions] ([OperationDescriptionId], [Argument1], [Argument2], [OperationType], [OperationResult], [OperationTime]) VALUES (4, 123, 545, N'Subtraction', CAST(-422 AS Decimal(18, 0)), CAST(0x070BC22B841381370B AS DateTime2))
SET IDENTITY_INSERT [dbo].[OperationDescriptions] OFF
GO