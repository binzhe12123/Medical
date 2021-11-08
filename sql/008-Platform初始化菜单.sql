USE [Medical_Platform]
GO

/****** Object:  Table [dbo].[Menus]    Script Date: 11/08/2021 21:33:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Menus]') AND type in (N'U'))
DROP TABLE [dbo].[Menus]
GO

USE [Medical_Platform]
GO

/****** Object:  Table [dbo].[Menus]    Script Date: 11/08/2021 21:33:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Menus](
	[MenuId] [int] NOT NULL,
	[MenuName] [nvarchar](100) NULL,
	[MenuRoute] [nvarchar](100) NULL,
	[MenuParent] [int] NULL,
	MenuSysName nvarchar(64),
	Icon nvarchar(128),
	[CreateTime] [datetime] NULL,
	[IsEnable] [int] NULL,
	[IsDelete] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MenuId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'MenuId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'MenuName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单路由' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'MenuRoute'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父路由,一级菜单为0' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'MenuParent'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统菜单表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus'
GO


Insert into Menus(MenuId,MenuName,MenuRoute,MenuParent,MenuSysName,Icon,CreateTime,IsEnable,IsDelete)
Values(1,'系统设置','/system',0,'system','jitongguanli',GETDATE(),1,1),
(2,'医生管理','/doctor',0,'doctor','yishengguanli',GETDATE(),1,1),
(3,'患者管理','/patient',0,'patient','huanzheguanli',GETDATE(),1,1),
(4,'收费管理','/charge',0,'charge','shoufeiguanli',GETDATE(),1,1),
(5,'门诊管理','/outpatient',0,'outpatient','menzhenguanli',GETDATE(),1,1),
(6,'物料管理','/material',0,'material','wuliao',GETDATE(),1,1),

(7,'后台诊所管理','/system/back',1,'back','',GETDATE(),1,1),
(8,'打印模板设置','/system/setting',1,'setting','',GETDATE(),1,1),
(9,'科室管理','/system/department',1,'department','',GETDATE(),1,1),

(10,'医生列表','/doctor/doctorList',2,'doctorList','',GETDATE(),1,1),

(11,'患者列表','/patient/patientList',3,'patientList','',GETDATE(),1,1),

(12,'待收费列表','/charge/wait/chargeWait',4,'chargeWait','',GETDATE(),1,1),
(13,'待收费详情','/charge/wait/chargeDetail',4,'chargeDetail','',GETDATE(),1,1),
(14,'已收费列表','/charge/already/chargeAlready',4,'chargeAlready','',GETDATE(),1,1),


(15,'门诊挂号','/outpatient/registered',5,'registered','',GETDATE(),1,1),
(16,'挂号列表','/outpatient/registerList',5,'registerList','',GETDATE(),1,1),
(17,'门诊处方','/outpatient/prescription',5,'prescription','',GETDATE(),1,1),

(18,'药品列表','/outpatient/registered',6,'registered','',GETDATE(),1,1),
(19,'药品采购','/material/procurement/procurementList',6,'procurementList','',GETDATE(),1,1),
(20,'药品盘点','/material/drugTake/drugTakeList',6,'drugTakeList','',GETDATE(),1,1),
(21,'药品库存记录查询','/material/inventory',6,'inventory','',GETDATE(),1,1),
(22,'项目列表','/material/project',6,'project','',GETDATE(),1,1),
(23,'材料列表','/material/stuff/stuffList',6,'stuffList','',GETDATE(),1,1),
(24,'材料采购','/outpatient/registered',6,'registered','',GETDATE(),1,1),
(25,'材料盘点','/material/take/takeList',6,'takeList','',GETDATE(),1,1),
(26,'材料库存记录查询','/material/record',6,'record','',GETDATE(),1,1)
