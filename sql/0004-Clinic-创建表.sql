Use Clinic
GO

Create Table CliniInfo
(
	ClinicID int primary key,
	YBCode nvarchar(100),
	YBLocalApi nvarchar(100)
)

begin --Description

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CliniInfo', @level2type=N'COLUMN',@level2name=N'ClinicID'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ҽ������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CliniInfo', @level2type=N'COLUMN',@level2name=N'YBCode'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ҽ���ӿڵ�ַ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CliniInfo', @level2type=N'COLUMN',@level2name=N'YBLocalApi'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������Ϣ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CliniInfo'


end


Create Table Employee
(	
	ID int primary key,
	BH bigint,
	ClinicID int,
	UserId int,
	RoleKeys nvarchar(100),
	Name nvarchar(200),
	Sex int,
	Phone nvarchar(100),
	BirthDay Date,
	SFZH nvarchar(100),
	YBCode nvarchar(100),	
	Imagepath nvarchar(200),	
	[State] int not null default(0),
	IsDelete int not null default(0),	
	CreateTime datetime not null default(getdate())
)

begin --Description

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ա��ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employee', @level2type=N'COLUMN',@level2name=N'ID'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ա�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employee', @level2type=N'COLUMN',@level2name=N'BH'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employee', @level2type=N'COLUMN',@level2name=N'ClinicID'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�û�ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employee', @level2type=N'COLUMN',@level2name=N'UserId'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ɫ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employee', @level2type=N'COLUMN',@level2name=N'Roles'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employee', @level2type=N'COLUMN',@level2name=N'Name'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�绰' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employee', @level2type=N'COLUMN',@level2name=N'Phone'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employee', @level2type=N'COLUMN',@level2name=N'Code'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ�ɾ��:0:����,-1:����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employee', @level2type=N'COLUMN',@level2name=N'State'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ�ɾ��:0:����,-1:ɾ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employee', @level2type=N'COLUMN',@level2name=N'IsDelete'


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ա����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employee'

end


Create Table Enum
(	
	ClinicID int,	
	Name nvarchar(200),
	GBNo nvarchar(200),
	EnumKey nvarchar(200),
	EnumValue nvarchar(200),
	IsDelete int
)

begin --Description

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=
N'TABLE',@level1name=N'Enum', @level2type=N'COLUMN',@level2name=N'ID'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ö������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Enum', @level2type=N'COLUMN',@level2name=N'Name'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Enum', @level2type=N'COLUMN',@level2name=N'GBNo'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Enum', @level2type=N'COLUMN',@level2name=N'EnumKey'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ֵ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Enum', @level2type=N'COLUMN',@level2name=N'EnumValue'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ�ɾ��:0:����,-1:ɾ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Enum', @level2type=N'COLUMN',@level2name=N'IsDelete'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ö��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Enum'

end


Create Table RoleMenu
(
	ClinicID int,
	RoleKey nvarchar(200),
	MenuIDs nvarchar(2000)
)

begin --Descritpion

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleMenu', @level2type=N'COLUMN',@level2name=N'ClinicID'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ɫID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleMenu', @level2type=N'COLUMN',@level2name=N'RoleKey'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˵�ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleMenu', @level2type=N'COLUMN',@level2name=N'MenuIDs'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ö��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleMenu'

end


