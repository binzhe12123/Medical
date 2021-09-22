


Create Table Platforms
(
	PlatformId int primary key,
	PlatformName nvarchar(200),
	LogoImage nvarchar(200),
	LogoIco nvarchar(200),
	UrlAdd nvarchar(200),
	ServicePhone nvarchar(50),
	Title nvarchar(50),
	Slogan nvarchar(200),
	Record nvarchar(200),
	Enalbe int,
	VersionId int,
	CreateTime datetime,
	IsDelete int	
)

begin --property remark
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Platforms', @level2type=N'COLUMN',@level2name=N'PlatformId'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ƽ̨����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Platforms', @level2type=N'COLUMN',@level2name=N'PlatformName'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'logo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Platforms', @level2type=N'COLUMN',@level2name=N'LogoImage'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ico' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Platforms', @level2type=N'COLUMN',@level2name=N'LogoIco'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'url' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Platforms', @level2type=N'COLUMN',@level2name=N'UrlAdd'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����绰' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Platforms', @level2type=N'COLUMN',@level2name=N'ServicePhone'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Platforms', @level2type=N'COLUMN',@level2name=N'Title'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ں�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Platforms', @level2type=N'COLUMN',@level2name=N'Slogan'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������Ϣ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Platforms', @level2type=N'COLUMN',@level2name=N'Record'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ����:ö��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Platforms', @level2type=N'COLUMN',@level2name=N'Enalbe'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�汾id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Platforms', @level2type=N'COLUMN',@level2name=N'VersionId'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Platforms', @level2type=N'COLUMN',@level2name=N'CreateTime'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ�ɾ��:ö��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Platforms', @level2type=N'COLUMN',@level2name=N'IsDelete'


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ƽ̨��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Platforms'

end



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