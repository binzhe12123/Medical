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

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˵�Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'MenuId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˵�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'MenuName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˵�·��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'MenuRoute'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��·��,һ���˵�Ϊ0' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'MenuParent'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ϵͳ�˵���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus'
GO


Insert into Menus(MenuId,MenuName,MenuRoute,MenuParent,MenuSysName,Icon,CreateTime,IsEnable,IsDelete)
Values(1,'ϵͳ����','/system',0,'system','jitongguanli',GETDATE(),1,1),
(2,'ҽ������','/doctor',0,'doctor','yishengguanli',GETDATE(),1,1),
(3,'���߹���','/patient',0,'patient','huanzheguanli',GETDATE(),1,1),
(4,'�շѹ���','/charge',0,'charge','shoufeiguanli',GETDATE(),1,1),
(5,'�������','/outpatient',0,'outpatient','menzhenguanli',GETDATE(),1,1),
(6,'���Ϲ���','/material',0,'material','wuliao',GETDATE(),1,1),

(7,'��̨��������','/system/back',1,'back','',GETDATE(),1,1),
(8,'��ӡģ������','/system/setting',1,'setting','',GETDATE(),1,1),
(9,'���ҹ���','/system/department',1,'department','',GETDATE(),1,1),

(10,'ҽ���б�','/doctor/doctorList',2,'doctorList','',GETDATE(),1,1),

(11,'�����б�','/patient/patientList',3,'patientList','',GETDATE(),1,1),

(12,'���շ��б�','/charge/wait/chargeWait',4,'chargeWait','',GETDATE(),1,1),
(13,'���շ�����','/charge/wait/chargeDetail',4,'chargeDetail','',GETDATE(),1,1),
(14,'���շ��б�','/charge/already/chargeAlready',4,'chargeAlready','',GETDATE(),1,1),


(15,'����Һ�','/outpatient/registered',5,'registered','',GETDATE(),1,1),
(16,'�Һ��б�','/outpatient/registerList',5,'registerList','',GETDATE(),1,1),
(17,'���ﴦ��','/outpatient/prescription',5,'prescription','',GETDATE(),1,1),

(18,'ҩƷ�б�','/outpatient/registered',6,'registered','',GETDATE(),1,1),
(19,'ҩƷ�ɹ�','/material/procurement/procurementList',6,'procurementList','',GETDATE(),1,1),
(20,'ҩƷ�̵�','/material/drugTake/drugTakeList',6,'drugTakeList','',GETDATE(),1,1),
(21,'ҩƷ����¼��ѯ','/material/inventory',6,'inventory','',GETDATE(),1,1),
(22,'��Ŀ�б�','/material/project',6,'project','',GETDATE(),1,1),
(23,'�����б�','/material/stuff/stuffList',6,'stuffList','',GETDATE(),1,1),
(24,'���ϲɹ�','/outpatient/registered',6,'registered','',GETDATE(),1,1),
(25,'�����̵�','/material/take/takeList',6,'takeList','',GETDATE(),1,1),
(26,'���Ͽ���¼��ѯ','/material/record',6,'record','',GETDATE(),1,1)
