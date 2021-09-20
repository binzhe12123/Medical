Use Medical_Clinic
go



/****** Object:  View [dbo].[V_TableS]    Script Date: 09/11/2021 13:15:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[V_TableS]
AS
SELECT     A.name AS [Table], A.id, CAST(B.value AS VARCHAR(400)) AS TableName
FROM         sys.sysobjects AS A LEFT OUTER JOIN
                      sys.extended_properties AS B ON A.id = B.major_id AND B.minor_id = 0
WHERE     (A.xtype = 'U') AND (A.name <> 'dtproperties')

GO


/****** Object:  View [dbo].[V_COLUMNS]    Script Date: 09/11/2021 13:16:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[V_COLUMNS]
AS
SELECT     B.[Table], B.TableName, B.id AS TableId, A.name AS [Column], CAST(C.value AS VARCHAR(400)) AS ColumnName, D.name AS TypeName, A.length, A.isnullable, 
                      E.text AS DefaultValue
FROM         sys.syscolumns AS A INNER JOIN
                      dbo.V_TableS AS B ON A.id = B.id LEFT OUTER JOIN
                      sys.extended_properties AS C ON A.id = C.major_id AND A.colid = C.minor_id INNER JOIN
                      sys.systypes AS D ON A.xtype = D.xusertype LEFT OUTER JOIN
                      sys.syscomments AS E ON A.cdefault = E.id


GO




