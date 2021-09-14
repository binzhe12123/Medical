Use Medical
go


Create Table IDGlobal
(
	Name nvarchar(50),
	ID	int
)

begin --Description
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IDGlobal', @level2type=N'COLUMN',@level2name=N'Name'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'当前ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IDGlobal', @level2type=N'COLUMN',@level2name=N'ID'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'全局ID表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IDGlobal'

end

Create Table BHGlobal
(	
	Name nvarchar(50),	
	ClinicId int,
	BH bigint
)

begin --Description
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BHGlobal', @level2type=N'COLUMN',@level2name=N'Name'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'机构ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BHGlobal', @level2type=N'COLUMN',@level2name=N'ClinicId'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'当前BH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BHGlobal', @level2type=N'COLUMN',@level2name=N'BH'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'全局ID表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BHGlobal'


end 


Create Table [User]
(
	Id int primary key,
	Name nvarchar(200),
	Sex int,
	BirthDay Date,	
	SFZH nvarchar(100),
	Phone nvarchar(100),
	UserName nvarchar(200),	
	[Password] nvarchar(100),	
	Imagepath nvarchar(200),
	VirifyCOde nvarchar(50),
	Token nvarchar(200),	
	[State] int,
	CreateTime datetime not null default(getdate()),
	IsDelete int not null default(0)
)

begin --Description

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Id'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Name'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别(国标)1:男2:女' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Sex'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出生年月' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'BirthDay'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'身份证' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'SFZH'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Phone'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'UserName'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码md5' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Password'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'安全码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'VirifyCOde'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录凭证' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Token'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态：0:正常，-1:禁用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'state'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'头像' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Imagepath'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'CreateTime'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否删除:0:正常,-1:删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'IsDelete'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User'

end

Create Table Clinic
(
	Id int primary key,	
	Code nvarchar(100),
	Name nvarchar(200),
	Category nvarchar(200),
	Imagepath nvarchar(200),
	ServiceStart datetime,
	ServiceEnd datetime,
	Phone nvarchar(100),
	Boss int,
	[State] int not null default(0),
	CreateTime datetime not null default(getdate()),
	IsDelete int not null default(0)	
)

begin --Descrition

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Clinic', @level2type=N'COLUMN',@level2name=N'Id'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Clinic', @level2type=N'COLUMN',@level2name=N'Code'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Clinic', @level2type=N'COLUMN',@level2name=N'Name'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'种类' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Clinic', @level2type=N'COLUMN',@level2name=N'Category'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图片路径' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Clinic', @level2type=N'COLUMN',@level2name=N'Imagepath'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'服务开始时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Clinic', @level2type=N'COLUMN',@level2name=N'ServiceStart'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'服务结束时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Clinic', @level2type=N'COLUMN',@level2name=N'ServiceEnd'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Clinic', @level2type=N'COLUMN',@level2name=N'Phone'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'老板' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Clinic', @level2type=N'COLUMN',@level2name=N'Boss'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否删除:0:正常,-1:禁用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Clinic', @level2type=N'COLUMN',@level2name=N'state'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Clinic', @level2type=N'COLUMN',@level2name=N'CreateTime'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否删除:0:正常,-1:删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Clinic', @level2type=N'COLUMN',@level2name=N'IsDelete'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'机构表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Clinic'

end

Create Table UserClinic
(
	ID int primary key identity(1,1),
	ClinicID int,
	UserID int,
	Boss int,
	[State] int not null default(0),
	CreateTime datetime not null default(getdate()),
	IsDelete int not null default(0)	
)


begin --Descrition

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自增主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserClinic', @level2type=N'COLUMN',@level2name=N'ID'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'机构ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserClinic', @level2type=N'COLUMN',@level2name=N'ClinicID'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserClinic', @level2type=N'COLUMN',@level2name=N'UserID'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否老板:0否,1:是' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserClinic', @level2type=N'COLUMN',@level2name=N'Boss'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否删除:0:正常,-1:禁用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserClinic', @level2type=N'COLUMN',@level2name=N'state'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserClinic', @level2type=N'COLUMN',@level2name=N'CreateTime'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否删除:0:正常,-1:删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserClinic', @level2type=N'COLUMN',@level2name=N'IsDelete'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户机构关联表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserClinic'

end

Create	Table Department
(
	ID int primary key,
	Name nvarchar(200),
	BureauCode nvarchar(100),
	Code nvarchar(100),
	Kind int,
	Star int,
	Descrition nvarchar(200),	
	CreateTime datetime not null default(getdate()),
	IsDelete int not null default(0)
)

begin --Description

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Department', @level2type=N'COLUMN',@level2name=N'ID'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'科室名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Department', @level2type=N'COLUMN',@level2name=N'Name'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'医保编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Department', @level2type=N'COLUMN',@level2name=N'BureauCode'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自定义编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Department', @level2type=N'COLUMN',@level2name=N'Code'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Department', @level2type=N'COLUMN',@level2name=N'Kind'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否常规:0:否,1:是' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Department', @level2type=N'COLUMN',@level2name=N'Star'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Department', @level2type=N'COLUMN',@level2name=N'Descrition'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否删除:0:正常,-1:删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Department', @level2type=N'COLUMN',@level2name=N'IsDelete'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'科室表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Department'

end


Create Table Enum
(
	ID int primary key,
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


Create Table Menu
(
	ID int primary key,
	Name nvarchar(200),
	Code nvarchar(100),
	ParentCode nvarchar(100),
	ParentName nvarchar(200),
	RouteUrl nvarchar(100),
	IsDelete int
)

begin --Description


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'ID'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Name'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Code'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'ParentCode'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'ParentName'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'前端路径' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'RouteUrl'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否删除:0:正常,-1:删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'IsDelete'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu'


end



