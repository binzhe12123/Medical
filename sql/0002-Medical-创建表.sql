Use Medical
go


Create Table IDGlobal
(
	Name nvarchar(50),
	ID	int
)

begin --Description
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IDGlobal', @level2type=N'COLUMN',@level2name=N'Name'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ǰID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IDGlobal', @level2type=N'COLUMN',@level2name=N'ID'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ȫ��ID��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IDGlobal'

end

Create Table BHGlobal
(	
	Name nvarchar(50),	
	ClinicId int,
	BH bigint
)

begin --Description
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BHGlobal', @level2type=N'COLUMN',@level2name=N'Name'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BHGlobal', @level2type=N'COLUMN',@level2name=N'ClinicId'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ǰBH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BHGlobal', @level2type=N'COLUMN',@level2name=N'BH'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ȫ��ID��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BHGlobal'


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

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Id'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�û�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Name'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ա�(����)1:��2:Ů' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Sex'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'BirthDay'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���֤' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'SFZH'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�绰' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Phone'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�û���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'UserName'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����md5' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Password'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ȫ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'VirifyCOde'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��¼ƾ֤' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Token'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'״̬��0:������-1:����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'state'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ͷ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Imagepath'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'CreateTime'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ�ɾ��:0:����,-1:ɾ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'IsDelete'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�û���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User'

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
	[State] int,
	CreateTime datetime not null default(getdate()),
	IsDelete int not null default(0)	
)

begin --Descrition

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Clinic', @level2type=N'COLUMN',@level2name=N'Id'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Clinic', @level2type=N'COLUMN',@level2name=N'Code'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Clinic', @level2type=N'COLUMN',@level2name=N'Name'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Clinic', @level2type=N'COLUMN',@level2name=N'Category'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ͼƬ·��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Clinic', @level2type=N'COLUMN',@level2name=N'Imagepath'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʼʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Clinic', @level2type=N'COLUMN',@level2name=N'ServiceStart'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�������ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Clinic', @level2type=N'COLUMN',@level2name=N'ServiceEnd'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ�ɾ��:0:����,-1:����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Clinic', @level2type=N'COLUMN',@level2name=N'state'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Clinic', @level2type=N'COLUMN',@level2name=N'CreateTime'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ�ɾ��:0:����,-1:ɾ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Clinic', @level2type=N'COLUMN',@level2name=N'IsDelete'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Clinic'

end

Create Table UserClinic
(
	ID int primary key identity(1,1),
	ClinicID int,
	UserID int,
	Boss int,
	[State] int,
	CreateTime datetime not null default(getdate()),
	IsDelete int not null default(0)	
)


begin --Descrition

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserClinic', @level2type=N'COLUMN',@level2name=N'ID'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserClinic', @level2type=N'COLUMN',@level2name=N'ClinicID'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�û�ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserClinic', @level2type=N'COLUMN',@level2name=N'UserID'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ��ϰ�:0��,1:��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserClinic', @level2type=N'COLUMN',@level2name=N'Boss'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ�ɾ��:0:����,-1:����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserClinic', @level2type=N'COLUMN',@level2name=N'state'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserClinic', @level2type=N'COLUMN',@level2name=N'CreateTime'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ�ɾ��:0:����,-1:ɾ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserClinic', @level2type=N'COLUMN',@level2name=N'IsDelete'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�û�����������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserClinic'

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

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Department', @level2type=N'COLUMN',@level2name=N'ID'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Department', @level2type=N'COLUMN',@level2name=N'Name'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ҽ������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Department', @level2type=N'COLUMN',@level2name=N'BureauCode'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Զ������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Department', @level2type=N'COLUMN',@level2name=N'Code'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Department', @level2type=N'COLUMN',@level2name=N'Kind'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ񳣹�:0:��,1:��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Department', @level2type=N'COLUMN',@level2name=N'Star'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Department', @level2type=N'COLUMN',@level2name=N'Descrition'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ�ɾ��:0:����,-1:ɾ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Department', @level2type=N'COLUMN',@level2name=N'IsDelete'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ұ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Department'

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

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=
N'TABLE',@level1name=N'Enum', @level2type=N'COLUMN',@level2name=N'ID'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ö������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Enum', @level2type=N'COLUMN',@level2name=N'Name'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Enum', @level2type=N'COLUMN',@level2name=N'GBNo'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Enum', @level2type=N'COLUMN',@level2name=N'EnumKey'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ֵ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Enum', @level2type=N'COLUMN',@level2name=N'EnumValue'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ�ɾ��:0:����,-1:ɾ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Enum', @level2type=N'COLUMN',@level2name=N'IsDelete'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ö��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Enum'


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


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'ID'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Name'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Code'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'ParentCode'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'ParentName'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ǰ��·��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'RouteUrl'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ�ɾ��:0:����,-1:ɾ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'IsDelete'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˵���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu'


end



