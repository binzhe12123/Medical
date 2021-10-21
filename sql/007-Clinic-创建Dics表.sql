Create Table Dics
(
	DicId int primary key,
	TenantId int,
	DicKey nvarchar(50),
	DicValue nvarchar(50),
	DicTypeid int,
	DicType nvarchar(50),
	SearchKey nvarchar(200),
	CreateTime datetime ,
	IsEnable int ,
	IsDelete int 
)



Insert into Dics(DicId,TenantId,DicKey,DicValue,DicTypeid,DicType,CreateTime,IsEnable,IsDelete)
Values(1,0,1,'抗感染类药物',1,'Drug.West',GETDATE(),1,1),
(2,0,2,'麻醉药',1,'Drug.West',GETDATE(),1,1),
(3,0,3,'神经系统类药物',1,'Drug.West',GETDATE(),1,1),
(4,0,4,'心血管系统类药物',1,'Drug.West',GETDATE(),1,1),
(5,0,5,'血液系统类药物',1,'Drug.West',GETDATE(),1,1),
(6,0,6,'呼吸系统类药物',1,'Drug.West',GETDATE(),1,1),
(7,0,7,'消化系统类药物',1,'Drug.West',GETDATE(),1,1),
(8,0,8,'泌尿系统类药物',1,'Drug.West',GETDATE(),1,1)

