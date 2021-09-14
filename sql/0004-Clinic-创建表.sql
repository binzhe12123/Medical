Use Clinic
GO

Create Table CliniInfo
(
	ClinicID int primary key,
	YBCode nvarchar(100),
	YBLocalApi nvarchar(100)
)

begin --Description

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'机构id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CliniInfo', @level2type=N'COLUMN',@level2name=N'ClinicID'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'医保编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CliniInfo', @level2type=N'COLUMN',@level2name=N'YBCode'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'医保接口地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CliniInfo', @level2type=N'COLUMN',@level2name=N'YBLocalApi'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'机构信息表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CliniInfo'


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

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'员工ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employee', @level2type=N'COLUMN',@level2name=N'ID'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'员工编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employee', @level2type=N'COLUMN',@level2name=N'BH'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'机构ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employee', @level2type=N'COLUMN',@level2name=N'ClinicID'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employee', @level2type=N'COLUMN',@level2name=N'UserId'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employee', @level2type=N'COLUMN',@level2name=N'Roles'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employee', @level2type=N'COLUMN',@level2name=N'Name'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employee', @level2type=N'COLUMN',@level2name=N'Phone'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employee', @level2type=N'COLUMN',@level2name=N'Code'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否删除:0:正常,-1:禁用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employee', @level2type=N'COLUMN',@level2name=N'State'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否删除:0:正常,-1:删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employee', @level2type=N'COLUMN',@level2name=N'IsDelete'


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'员工表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employee'

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

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=
N'TABLE',@level1name=N'Enum', @level2type=N'COLUMN',@level2name=N'ID'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'枚举名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Enum', @level2type=N'COLUMN',@level2name=N'Name'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'国标号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Enum', @level2type=N'COLUMN',@level2name=N'GBNo'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Enum', @level2type=N'COLUMN',@level2name=N'EnumKey'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Enum', @level2type=N'COLUMN',@level2name=N'EnumValue'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否删除:0:正常,-1:删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Enum', @level2type=N'COLUMN',@level2name=N'IsDelete'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'枚举' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Enum'

end


Create Table RoleMenu
(
	ClinicID int,
	RoleKey nvarchar(200),
	MenuIDs nvarchar(2000)
)

begin --Descritpion

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'机构id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleMenu', @level2type=N'COLUMN',@level2name=N'ClinicID'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleMenu', @level2type=N'COLUMN',@level2name=N'RoleKey'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleMenu', @level2type=N'COLUMN',@level2name=N'MenuIDs'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'枚举' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleMenu'

end


