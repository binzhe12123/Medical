USE [Medical_Platform]
GO

/****** Object:  Table [dbo].[BuyRecords]    Script Date: 02/19/2022 12:06:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BuyRecords](
	[BuyRecordId] [int] NOT NULL,
	[TenantId] [int] NOT NULL,
	[BuyUser] [nvarchar](20) NOT NULL,
	[BuyStaff] [nvarchar](20) not Null,
	[Price] [money] NOT NULL,
	[Way] [nvarchar](30) NOT NULL,
	[Code] [nvarchar](128) NOT NULL,
	[BuyTime] [nvarchar](20) not null
PRIMARY KEY CLUSTERED 
(
	[BuyRecordId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BuyRecords', @level2type=N'COLUMN',@level2name=N'BuyRecordId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'租户Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BuyRecords', @level2type=N'COLUMN',@level2name=N'TenantId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'购买人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BuyRecords', @level2type=N'COLUMN',@level2name=N'BuyUser'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'充值金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BuyRecords', @level2type=N'COLUMN',@level2name=N'Price'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'充值方式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BuyRecords', @level2type=N'COLUMN',@level2name=N'Way'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'付款编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BuyRecords', @level2type=N'COLUMN',@level2name=N'Code'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'充值时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BuyRecords', @level2type=N'COLUMN',@level2name=N'BuyTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'充值员工' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BuyRecords', @level2type=N'COLUMN',@level2name=N'BuyStaff'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'租户充值表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BuyRecords'
GO

ALTER TABLE [dbo].[BuyRecords] ADD  DEFAULT ((0)) FOR [TenantId]
GO

ALTER TABLE [dbo].[BuyRecords] ADD  DEFAULT ('') FOR [BuyUser]
GO

ALTER TABLE [dbo].[BuyRecords] ADD  DEFAULT ((0)) FOR [Price]
GO

ALTER TABLE [dbo].[BuyRecords] ADD  DEFAULT ('') FOR [Way]
GO

ALTER TABLE [dbo].[BuyRecords] ADD  DEFAULT ('') FOR [Code]
GO

ALTER TABLE [dbo].[BuyRecords] ADD  DEFAULT ('') FOR [BuyTime]
GO

ALTER TABLE [dbo].[BuyRecords] ADD  DEFAULT ('') FOR [BuyStaff]
GO
