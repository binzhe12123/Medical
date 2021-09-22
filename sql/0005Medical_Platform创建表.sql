


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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Platforms', @level2type=N'COLUMN',@level2name=N'PlatformId'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'平台名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Platforms', @level2type=N'COLUMN',@level2name=N'PlatformName'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'logo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Platforms', @level2type=N'COLUMN',@level2name=N'LogoImage'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ico' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Platforms', @level2type=N'COLUMN',@level2name=N'LogoIco'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'url' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Platforms', @level2type=N'COLUMN',@level2name=N'UrlAdd'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'服务电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Platforms', @level2type=N'COLUMN',@level2name=N'ServicePhone'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Platforms', @level2type=N'COLUMN',@level2name=N'Title'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标语口号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Platforms', @level2type=N'COLUMN',@level2name=N'Slogan'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备案信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Platforms', @level2type=N'COLUMN',@level2name=N'Record'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否可用:枚举' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Platforms', @level2type=N'COLUMN',@level2name=N'Enalbe'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'版本id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Platforms', @level2type=N'COLUMN',@level2name=N'VersionId'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Platforms', @level2type=N'COLUMN',@level2name=N'CreateTime'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否删除:枚举' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Platforms', @level2type=N'COLUMN',@level2name=N'IsDelete'


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'平台表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Platforms'

end



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